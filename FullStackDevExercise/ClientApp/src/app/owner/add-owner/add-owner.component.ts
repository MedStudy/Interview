import { Component, OnInit } from '@angular/core';
import { ownersModel } from 'src/app/models/ownerModel';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-add-owner',
  templateUrl: './add-owner.component.html',
  styleUrls: ['./add-owner.component.css'],
})
export class AddOwnerComponent implements OnInit {
  submitted: boolean = false;
  _ownersModel: ownersModel = new ownersModel();
  constructor(private crudservice: CrudServiceService) {}

  ngOnInit(): void {}
  addowner()
  {
    this._ownersModel = new ownersModel();
    this.submitted = false;
  }
  newOwner() {
    this.submitted = false;

    this.crudservice.createowner(this._ownersModel).subscribe(
      (response: any) => {
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
}
