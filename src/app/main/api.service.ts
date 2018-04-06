import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';

//INTERFACE TO HOLD JSON OBJECT PROPERTIES
 export interface IApi{
  total_count;
  items;
}

@Injectable()
export class api {
    constructor(private http: HttpClient) {}

    //USING THE USER SUPPLIED SEARCH NAME CALL THE GITHUB API
    //LOAD RETURN DATA INTO INTERFACE
    getUsers(name): Observable<IApi> {
      return this.http.get<IApi>('https://api.github.com/search/users?q=' + name);
    }
}