import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {SearchResults} from '../models/git-user.model';
import {SearchService} from '../services/search.service';
import {LoadingIndicatorService} from '../services/loading-indicator.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  searchResults$: Observable<SearchResults>;
  errorMessage: String = null;
  isLoading$: Observable<boolean>;

  constructor(private searchSrv: SearchService,
              private indicator: LoadingIndicatorService) {
    this.isLoading$ = indicator.onLoadingChanged.asObservable()
  }

  ngOnInit() {

  }

  onSearchResults(results: Observable<SearchResults>): void {
    this.searchResults$ = results.catch((error: any) => {
      console.log('Error: ', error.statusText);
      this.errorMessage = error.statusText;
      return Observable.throw(error.status)
    });
  }

  getAdditionalInfo(url: string): any {
    return this.searchSrv.getMoreUserdata(url);
  }
}
