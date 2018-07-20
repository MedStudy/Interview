import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import {ConstantsService} from './constants.service';
import {SearchResults} from '../models/git-user.model';

@Injectable()
export class SearchService {
  constructor(private http: HttpClient) { }

  getByUserName(userName): Observable<SearchResults> {
    return  this.http.get(ConstantsService.GIT_SEARCH_API + userName);
  }

  getMoreUserdata(url): Observable<any> {
    return this.http.get(url)
      .catch((error: any) => Observable.throw(error.status));
  }

}
