import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { petsListModel, petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';
import { checkcustomrequired } from 'src/app/validators/checkcustomrequired';

@Component({
  selector: 'app-editpet',
  templateUrl: './editpet.component.html',
  styleUrls: ['./editpet.component.css'],
})
export class EditpetComponent implements OnInit {
  submitted: boolean = false;
  _petsModel: FormGroup = new FormGroup({});
  _ownersmodel: ownersModel[] = [];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private crudservice: CrudServiceService,
    private formgroup: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initform(new petsModel());
    this.fetchpet(parseInt(this.route.snapshot.paramMap.get('id')));
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
  fetchpet(id: number) {
    this.crudservice.getowners().subscribe((rr: any) => {
      this._ownersmodel = rr;
      this.crudservice.getparticularpets(id).subscribe(
        (response: any) => {
         this.initform(response);
        },
        (error) => {
          alert('Something went wrong!!');
        }
      );
    });
  }
  viewlist() {
    this.router.navigate(['/pets']);
  }
  editpet() {
    if (this._petsModel.valid) {
      this._petsModel
        .get('owner_id')
        .patchValue(parseInt(this._petsModel.get('owner_id').value));
      this.submitted = false;
      this.crudservice.updatepet(this._petsModel.value).subscribe(
        (response: any) => {
          this.submitted = true;
        },
        (error) => {
          this.submitted = false;
          alert('Something went wrong!!');
        }
      );
    } else this._petsModel.markAllAsTouched();
  }
}
