import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { catchError, map, Observable } from 'rxjs';
import { throwError as observableThrowError } from 'rxjs';
import { Configurations } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  baseURL:string = Configurations.baseURL;
  constructor(private http: HttpClient) { }

  getWithoutParams(urlPath:string):Observable<any>{
    return this.http.get(this.baseURL+urlPath,{headers:this.createHeaders()}).pipe(map(res=>res),
    catchError(err =>{
      const transformedError = this.transformError(err);
      return observableThrowError(transformedError);
    }));
  }

  postHttpMethod(urlPath: string, inputObject:any): Observable<any> {
    return this.http.post(this.baseURL + urlPath, inputObject, {
      headers: this.createHeaders()
    }).pipe(map(res => res),
      catchError(err => {
        const transformedError = this.transformError(err);
        return observableThrowError(transformedError);
      }), );
  }

  private transformError(err:any) {
    if (err.error) {
      err.statusText =  typeof err.error === 'string'? err.error : err.error.text;
    }
    return err;
  }

  private createHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json',
    });
  }
}
