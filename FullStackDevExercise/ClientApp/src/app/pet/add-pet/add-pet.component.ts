import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';
import { checkcustomrequired } from 'src/app/validators/checkcustomrequired';

@Component({
  selector: 'app-add-pet',
  templateUrl: './add-pet.component.html',
  styleUrls: ['./add-pet.component.css'],
})
export class AddPetComponent implements OnInit {
  submitted: boolean = false;
  _ownersmodel: ownersModel[] = [];
  _petsModel: FormGroup = new FormGroup({});
  constructor(
    private crudservice: CrudServiceService,
    private router: Router,
    private formgroup: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initform(new petsModel());

    this.crudservice.getowners().subscribe((rr: any) => {
      setTimeout(() => {
        this._ownersmodel = rr;
      }, 0);
    });
  }
  initform(pets : petsModel) {
    this._petsModel = this.formgroup.group({
      id: new FormControl(pets.id),
      owner_id: new FormControl(pets.owner_id, [
        Validators.required,checkcustomrequired()
      ]),
      type: new FormControl(pets.type, [
        Validators.required,
        Validators.maxLength(50),
      ]),
      name: new FormControl(pets.name, [
        Validators.required,
        Validators.maxLength(50),
      ]),
      age: new FormControl(pets.age, [
        Validators.required,
        Validators.max(99),
        Validators.min(1),
      ]),
    });
  }
  addpet() {
    this.initform(new petsModel());
    this._petsModel.updateValueAndValidity();
    this.submitted = false;
  }
  viewall() {
    this.router.navigate(['/pets']);
  }
  newpet() {
    if (this._petsModel.valid) {
      this._petsModel
        .get('owner_id')
        .patchValue(parseInt(this._petsModel.get('owner_id').value));
      this.submitted = false;
      this.crudservice.createpet(this._petsModel.value).subscribe(
        (response: any) => {
          this.submitted = true;
        },
        (error) => {
          this.submitted = false;
          alert('Something went wrong!!');
        }
      );
    } else {
      this._petsModel.markAllAsTouched();
    }
  }
}
