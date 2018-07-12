import { Component, OnInit } from '@angular/core';
import { SearchService } from '../search/search.service';
import { I18nPluralPipe } from '@angular/common';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  providers: [SearchService]
})

export class MainComponent implements OnInit {

  public searchVal: string;
  public searchResults: Array<Object>;
  public hasSearched: boolean;

  constructor(private searchService: SearchService) {
    this.searchVal = "";
    this.searchResults = [];
    this.hasSearched = false;
  }

  searchUsers() {
    if (this.searchVal) {
      this.searchService.searchUsers(this.searchVal).subscribe(
        results => {
          this.searchResults = results;
        },
        error => {
          this.searchResults = [];
          console.error(error);
        }
      );
    } else {
      this.searchResults = [];
    }
  }

  onSubmit() { 
    this.hasSearched = true; 
    this.searchUsers() 
  }


  ngOnInit() {
  }

}
