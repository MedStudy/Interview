import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LookupService {
  apiRoot = 'https://api.github.com/search/';

  constructor(private http: HttpClient) {}

  search(term: string): Promise<any> {
    return new Promise((resolve, reject) => {
      const apiURL = `${this.apiRoot}users?q=${term}`;
      this.http.get(apiURL)
        .subscribe(res => resolve(res), error => reject(console.log(error)));
    }, );
  }
}
