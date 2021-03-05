import { Component, OnInit } from '@angular/core';

import { OwnersService } from '../owners.service';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  constructor(private ownerService: OwnersService) {}
  public owners: Array<any>;
  ngOnInit(): void {
    this.ownerService.getOwners().subscribe(x => {
      console.log(x);
      this.owners = x;
    });
  }
}
