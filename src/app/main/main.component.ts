import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../shared/profile.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent implements OnInit {
  profiles: any[];
  profilesFound: boolean = false;
  searching: boolean = false;
  profileTotal: number = 0;

  queryString: string = '';
  currentPage: number = 1;
  totalPages: number = 0;

  validQuery: boolean = true;

  constructor(private _profileService: ProfileService) { }

  getPrevPage() {
    // TODO - more robust paging
    if (this.currentPage > 1) {
      const prevPage = this.currentPage - 1;

      this.findProfiles (
        this.queryString, prevPage
      )
    }
  }
  
  getNextPage() {
    // TODO - more robust paging
    if (this.currentPage < this.totalPages) {
      const nextPage = this.currentPage + 1;

      this.findProfiles (
        this.queryString, nextPage
      )
    }
  }

  findProfiles (query: string, page: number = 1, perPage = 10) {
    const regexp = /^[a-zA-Z0-9-]+$/;

    if (query.search(regexp) === -1) {
      this.validQuery = false;
    } else {
      this.validQuery = true;
      this.searching = true;
      this.queryString = query;
      this.currentPage = page;
  
      return this._profileService.getProfiles(query, page, perPage).subscribe (
        data => this.handleSuccess(data, perPage),
        error => this.handleError(error),
        () => this.searching = false
      )
    }
  }

  handleSuccess (data, perPage) {
    this.profileTotal = data.total_count;
    this.searching = false;

    if (this.profileTotal === 0) {
      this.profilesFound = false;
      this.profiles = [];
      this.totalPages = 0;
    } else {
      this.profilesFound = true;
      this.profiles = data.items;
      this.totalPages = Math.ceil(this.profileTotal / perPage);
    }
  }

  handleError (error) {
    // TODO - more robust error handling
    this.profilesFound = false;
    this.searching = false;
    this.profileTotal = 0;
    this.totalPages = 0;
  }

  ngOnInit() {
  }

}
