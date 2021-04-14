using FSDExercise.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FullStackDevExercise.Middleware
{
  public class ErrorHandlerMiddleware
    {
      private readonly RequestDelegate _next;
      private readonly ILogger<ErrorHandlerMiddleware> _logger;  
      private readonly IConfiguration _configSetting;

      public ErrorHandlerMiddleware(RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger,
        IConfiguration config)
      {
        _next = next;
        _logger = logger;
        _configSetting = config;
      }

      public async Task Invoke(HttpContext httpContext)
      {
          try
          {
            await _next(httpContext);
            if (httpContext.Response.StatusCode > 399 && !httpContext.Response.HasStarted)
            {
              if (httpContext.Response.StatusCode == 404 && httpContext.Request.Path.Value.Equals("/"))
              {
                
              }
              else
              {
                throw new HttpStatusCodeException((HttpStatusCode)httpContext.Response.StatusCode);
              }
            }
          }
          catch (OperationCanceledException ex)
          {
            
          }
          catch (Exception e)
          {
            await HandleExceptionAsync(httpContext, e);
          }
          finally
          {
            
          }
        }

      private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
      {
        var requestInfo = $"HTTP: {httpContext.Request.Method} Path: {httpContext.Request.Path.ToString()}.";
        var errorMessage = string.Empty;
        ExceptionDetails result = null;
        int statusCode = 0;

        if (exception is HttpStatusCodeException ex1)
        {
          errorMessage = $"{requestInfo} {ex1.Message}";
          result = new ExceptionDetails()
          {
            Message = errorMessage,
            StatusCode = (int)ex1.StatusCode            
          };
          statusCode = (int)ex1.StatusCode;
        }
        else
        {
          errorMessage = $"{requestInfo} {exception.Message}";
          result = new ExceptionDetails()
          {
            Message = errorMessage,
            StatusCode = (int)HttpStatusCode.InternalServerError            
          };
          statusCode = (int)HttpStatusCode.InternalServerError;
        }

        _logger.LogError(exception, errorMessage);
        // override result message to cover actual exception
        if (_configSetting["ActualDetailedErrorInResponse"] != null && !bool.Parse(_configSetting["ActualDetailedErrorInResponse"]))
        {
          result.Message = "Something went wrong";
        }

        if (!httpContext.Response.HasStarted)
        {
          var jsonSerializerSettings = new JsonSerializerSettings
          {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
          };
          httpContext.Response.ContentType = "application/json";
          httpContext.Response.StatusCode = statusCode;
          await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result, jsonSerializerSettings));
        }

        return;
      }
    }  
}
