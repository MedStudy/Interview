import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ProfileService {
    private query: string;
    private API_KEY: string = environment.GITHUB_API.key;
    private API_URL: string = environment.GITHUB_API.url;
    private URL: string = this.API_URL + "?key=" + this.API_KEY;

    constructor (private _http: Http) { }

    getProfiles(query, page = 1, perPage = 10) {
        return this._http.get(this.URL + "&q=" + query + "&page=" + page + "&per_page=" + perPage)
            .map(res => res.json())
    }
}