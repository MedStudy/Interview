import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class GithubapiService {

 private _url = 'https://api.github.com/search/users?q=';

    constructor(private _http: Http) {

    }

		getdata(userName){
		    return this._http.get(this._url + userName)
				.map(res => res.json());
		}

		


}
