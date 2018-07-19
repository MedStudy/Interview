import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {SearchResults} from '../models/git-user.model';
import {SearchService} from '../services/search.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  searchResults$: Observable<SearchResults>;

  constructor(private searchSrv: SearchService) { }

  ngOnInit() {
  }

  getAdditionalInfo(url: string): any {
    return this.searchSrv.getMoreUserdata(url);
  }
}
