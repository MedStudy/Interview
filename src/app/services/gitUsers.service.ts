import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ConfigService } from './config.service';

@Injectable()
export class GitUsersService {

  constructor(private configService: ConfigService, private http: Http) {
  }

  public getUsers(searchText: string): Observable<SearchResult> {
    // Since git API don't handle empty string
    if (!searchText) {
      return this.handleError('Invalid input');
    }
    const url = this.configService.getGitEndpoint() + '/search/users?q=' + searchText;
    return this.http.get(url)
      .map((resp) => resp.json())
      .map((searchResponse) =>
        searchResponse.incomplete_results ? this.handleError('Incomplete results') : searchResponse as SearchResult)
      .catch(this.handleError);
  }

  // Common error handler
  private handleError(error: Response | string): Observable<any> {
    let errMsg: string;
    if (error instanceof Response) {
      errMsg = JSON.stringify(error.json());
    } else {
      errMsg = error;
    }
    console.error('In GitUserService ' + errMsg);
    return Observable.throw(errMsg);
  }
}

export class SearchResult {
  total_count: string;
  items: object;
}
