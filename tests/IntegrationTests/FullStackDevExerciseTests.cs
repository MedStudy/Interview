using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using FullStackDevExercise.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IntegrationTests  
{
  public class FullStackDevExerciseTests : IClassFixture<CustomWebApplicationFactory<FullStackDevExercise.Startup>>
  {
    private readonly CustomWebApplicationFactory<FullStackDevExercise.Startup> _factory;
    private readonly HttpClient _client;

    public FullStackDevExerciseTests(CustomWebApplicationFactory<FullStackDevExercise.Startup> factory)
    {
      _factory = factory;
      _client = _factory.CreateClient();
    }

    [Theory]
    [InlineData("/api/Owner")]
    [InlineData("/api/Pet")]
    public async Task Get_ShouldReturnJson(string url)
    {
      // Arrange

      // Act
      var response = await _client.GetAsync(url);

      // Assert
      response.EnsureSuccessStatusCode(); // Status Code 200-299
      Assert.Equal("application/json; charset=utf-8",
          response.Content.Headers.ContentType.ToString());

      var json = await response.Content.ReadAsStringAsync();
      json.Should().NotBeNullOrEmpty();

      var jarray = JArray.Parse(json);
      jarray.Should().NotBeNullOrEmpty().And.HaveCountGreaterOrEqualTo(1);
    }

    [Theory]
    [InlineData("/api/Owner/1")]
    [InlineData("/api/Pet/1")]
    public async Task GetSingle_ShouldReturnJson(string url)
    {
      // Arrange

      // Act
      var response = await _client.GetAsync(url);

      // Assert
      response.EnsureSuccessStatusCode(); // Status Code 200-299
      Assert.Equal("application/json; charset=utf-8",
          response.Content.Headers.ContentType.ToString());

      var json = await response.Content.ReadAsStringAsync();
      json.Should().NotBeNullOrEmpty();

      var jObject = JObject.Parse(json);
      jObject.Should().NotBeNull();
    }

    [Fact]
    public async Task OwnerPostDelete_ShouldSucceed()
    {
      var owner = await _client.CreateOwnerAsync();
      owner.Should().NotBeNull();
      owner.Id.Should().BeGreaterThan(0);
      var deleted = await _client.DeleteOwnerAsync(owner);
      deleted.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task PetPostDelete_ShouldSucceed()
    {
      var owner = await _client.CreateOwnerAsync();
      owner.Should().NotBeNull();
      owner.Id.Should().BeGreaterThan(0);

      var pet = await _client.CreatePetAsync(owner);
      pet.Should().NotBeNull();
      pet.Id.Should().BeGreaterThan(0);
      var deleted = await _client.DeleteOwnerAsync(owner);
      deleted.IsSuccessStatusCode.Should().BeTrue();
      deleted = await _client.DeletePetAsync(pet);
      deleted.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task FullAppointmentTest()
    {
      var owner = await _client.CreateOwnerAsync();
      owner.Should().NotBeNull();
      owner.Id.Should().BeGreaterThan(0);

      var pet = await _client.CreatePetAsync(owner);
      pet.Should().NotBeNull();
      pet.Id.Should().BeGreaterThan(0);

      var vets = await _client.GetAsync<List<VetModel>>($"/api/Vet?dateTime=11/5/1955 10:00 am");
      vets.Should().HaveCountGreaterOrEqualTo(1);

      var appointment = await _client.CreateAppointmentAsync(owner, pet, vets.FirstOrDefault(), "06/23/2021 11:00 am");
      appointment.Should().NotBeNull();
      appointment.Id.Should().BeGreaterThan(0);

      var appointments = await _client.GetAsync<List<AppointmentModel>>("/api/Schedule");
      appointments.Should().HaveCountGreaterOrEqualTo(1);

      var deleted = await _client.DeleteOwnerAsync(owner);
      deleted.IsSuccessStatusCode.Should().BeTrue();
      deleted = await _client.DeletePetAsync(pet);
      deleted.IsSuccessStatusCode.Should().BeTrue();
      deleted = await _client.DeleteAppointmentAsync(appointment);
      deleted.IsSuccessStatusCode.Should().BeTrue();
    }
  }

  public static class HttpContentHelper
  {
    public static HttpContent FromModel<T>(T model)
    {
      return new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
    }

    public static async Task<T> ToModel<T>(this HttpResponseMessage httpResponseMessage)
    {
      if (httpResponseMessage.IsSuccessStatusCode)
      {
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
      }
      return default(T);
    }

    public static async Task<T> GetAsync<T>(this HttpClient client, string url)
    {
      var response = await client.GetAsync(url);
      return await response.ToModel<T>();
    }

    public static async Task<OwnerModel> CreateOwnerAsync(this HttpClient client)
    {
      var response = await client.PostAsync("/api/Owner", HttpContentHelper.FromModel(new OwnerViewModel { FirstName = "Test", LastName = "Test" }));
      return await response.ToModel<OwnerModel>();
    }

    public static async Task<AppointmentModel> CreateAppointmentAsync(this HttpClient client, OwnerModel ownerModel, PetModel petModel, VetModel vetModel, string dateTime)
    {
      var response = await client.PutAsync("/api/Schedule", HttpContentHelper.FromModel(new CreateScheduleRequest
      {
        AppointmentTime = dateTime,
        OwnerId = ownerModel.Id,
        PetId = petModel.Id,
        VetId = vetModel.Id
      }));
      return await response.ToModel<AppointmentModel>();
    }

    public static async Task<PetModel> CreatePetAsync(this HttpClient client, OwnerModel ownerModel)
    {
      var response = await client.PostAsync("/api/Pet", HttpContentHelper.FromModel(new PetViewModel { Age = 1, Name = "test", OwnerId = ownerModel.Id, Type = "dog" }));
      return await response.ToModel<PetModel>();
    }

    public static async Task<HttpResponseMessage> DeletePetAsync(this HttpClient client, PetModel petModel)
    {
      return await client.DeleteAsync($"/api/Pet/{petModel.Id}");
    }

    public static async Task<HttpResponseMessage> DeleteOwnerAsync(this HttpClient client, OwnerModel ownerModel)
    {
      return await client.DeleteAsync($"/api/Owner/{ownerModel.Id}");
    }

    public static async Task<HttpResponseMessage> DeleteAppointmentAsync(this HttpClient client, AppointmentModel appointmentModel)
    {
      return await client.DeleteAsync($"/api/Schedule/{appointmentModel.Id}");
    }
  }
}
