import { Component, OnInit } from '@angular/core';
import { DataServiceService } from '../data-service.service';
import { Owner } from '../owner.model';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {

  constructor(private dataservice: DataServiceService) { }

  owners: Owner[] = [];
  ngOnInit(): void {
    this.getOwners();
  }

  getOwners(){
    this.dataservice.GetOwners(0).subscribe((res: Owner[]) => {
      this.owners = res
    });
  }

}
