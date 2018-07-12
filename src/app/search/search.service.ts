import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Injectable } from '@angular/core';

@Injectable()
export class SearchService {
    private apiRoot: string = 'https://api.github.com/search/users';

    constructor(public http: HttpClient) {
    }

    searchUsers(term) {
        console.log("SDAS")
            let apiURL = this.apiRoot + "?q=" + term;
            return this.http.get(apiURL)
            .map((res: Response) => res)
            .catch(this.handleError);
    }

    // TODO: Beef up the error handling
    private handleError(error: Response) {
        console.log(error)
        let errMsg = "Error searching";
        return Observable.throw(errMsg);
      }
}