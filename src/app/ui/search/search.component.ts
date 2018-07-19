import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {SearchService} from '../../services/search.service';
import {Observable} from 'rxjs/Observable';
import {SearchResults} from '../../models/git-user.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  @Output() searchResults: EventEmitter<any> = new EventEmitter<any>();

  constructor(private searchSrv: SearchService) { }

  ngOnInit() {
  }

  searchByUsername(username: string): void {
    this.searchResults.emit({searchResults$: this.searchSrv.getByUserName(username)});
  }
sendClear(): void{
    console.log('Clear...')
}
}
