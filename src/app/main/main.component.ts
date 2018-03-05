import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { GitUsersService, SearchResult } from '../services/gitUsers.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  private searchText: string;
  private searchResults: Observable<SearchResult>;

  constructor(private gitUsersService: GitUsersService) {
  }

  ngOnInit() {
    this.searchText = '';
  }

  private searchUsers(): void {
    this.searchResults = this.gitUsersService.getUsers(this.searchText);
  }

}
