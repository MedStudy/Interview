import { Component, OnInit } from '@angular/core';
import { ownersModel } from 'src/app/models/ownerModel';
import { petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-add-pet',
  templateUrl: './add-pet.component.html',
  styleUrls: ['./add-pet.component.css'],
})
export class AddPetComponent implements OnInit {
  submitted: boolean = false;
  _ownersmodel: ownersModel = new ownersModel();
  _petsModel: petsModel = new petsModel();
  constructor(private crudservice: CrudServiceService) {}

  ngOnInit(): void {
    this.crudservice.getowners().subscribe((rr: any) => {
      this._ownersmodel = rr;
    });
  }
  addpet() {
    this._petsModel = new petsModel();
    this.submitted = false;
  }
  newpet() {
    this.submitted = false;
    this._petsModel.owner_id = parseInt(this._petsModel.owner_id.toString());
    this._petsModel.age = parseInt(this._petsModel.age.toString());
    this.crudservice.createpet(this._petsModel).subscribe(
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
