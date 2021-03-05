import { Component, OnInit } from '@angular/core';

import { OwnersService } from 'app/services';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  constructor(private ownerService: OwnersService) {}
  public owners: Array<any>;
  public isEditing = false;
  ngOnInit(): void {
    this.ownerService.getOwners().subscribe(x => {
      console.log(x);
      this.owners = x;
    });
  }
  public remove(item: any) {}
  public onSave() {}
}
