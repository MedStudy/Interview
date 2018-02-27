import { Injectable } from '@angular/core';
import { HttpParams, HttpClient, httpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MainService {

  constructor(private http: HttpClient) { }

  getUsers(id: string): Observable<any> {

    id = id.trim();
    const options = id ? { params: new HttpParams().set('q', id) } : {};
    const URL: string = 'https://api.github.com/search/users';

    return this.http.get(URL, options);

  }

  private handleError(response: httpResponse<any> | any){

    console.error('there was an error in the response', response);

  }

}
