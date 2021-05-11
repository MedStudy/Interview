import { Component, OnInit } from '@angular/core';
import { Owner } from 'src/app/shared-services/models/owner';
import  { OwnersService } from '../../services/owners.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  owners : Promise<Owner[]>;
  constructor(private ownerService : OwnersService) { }

  ngOnInit(): void {
     this.owners =  this.ownerService.getOwners().toPromise();
    this.owners.then( data => {
      data.forEach(owner => {
         console.log(owner.id + " " + owner.firstName + " " + owner.lastName );
      });
    } );
  }

}
