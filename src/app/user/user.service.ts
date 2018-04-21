import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
// import { APPCONFIG } from 'app/config';

import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';
import {User} from './models/user.model';
import {UserSearchResult } from './models/user-search-result.model';
@Injectable()
export class UserService {

    // private url = APPCONFIG.baseUrls.dashboard;
    private url = 'https://api.github.com/search/users?q=';
    constructor(private http: Http, private httpClient: HttpClient) {}

    async find(userPartial: string): Promise<UserSearchResult> {
        const searchUrl = this.url + userPartial;

        const userSearhOutputAwaitable: Observable<UserSearchResult> =
            <Observable<UserSearchResult>>this.httpClient
                .get(searchUrl);
                // .catch(err => console.log(err));
                // .catch(err => this.messageLoggingService.catchErrorMessage(err));

        const usersSearchOutput: UserSearchResult = await userSearhOutputAwaitable.toPromise();
        return usersSearchOutput;
    }
}
