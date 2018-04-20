import { Component, OnInit } from '@angular/core';
import { LookupService } from '../services/lookup.service';
import { Profile } from '../models/profile';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  loading: boolean;
  searchResults: Array<Profile> = [];
  totalCount = 0;

  constructor(private lookupService: LookupService) { }

  ngOnInit() {
  }

  searchProfiles (term: string): void {
    this.loading = true;
    this.lookupService.search(term).then( (results) => {
      this.searchResults = results.items;
      this.totalCount = results.total_count;
      this.loading = false;
    });
  }
}
