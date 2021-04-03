import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-editowner',
  templateUrl: './editowner.component.html',
  styleUrls: ['./editowner.component.css'],
})
export class EditownerComponent implements OnInit {
  submitted: boolean = false;
  _ownersModel: FormGroup = new FormGroup({});
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private crudservice: CrudServiceService,
    private formgroup: FormBuilder
  ) {}

  ngOnInit(): void {
    this._ownersModel = this.formgroup.group({
      id:new FormControl(-1),
      first_name: new FormControl('', [
        Validators.required,
        Validators.maxLength(50),
      ]),
      last_name: new FormControl('', [
        Validators.required,
        Validators.maxLength(50),
      ]),
    });
    this.fetchowner(parseInt(this.route.snapshot.paramMap.get('id')));    
  }
  fetchowner(id: number) {
    this._ownersModel.reset();
    this._ownersModel.updateValueAndValidity();
    this.crudservice.getparticularowners(id).subscribe(
      (response: any) => {
        this._ownersModel.setValue(response);
        this._ownersModel.updateValueAndValidity();
      },
      (error) => {
        alert('Something went wrong!!');
      }
    );
  }
  viewlist(){
    this.router.navigate(['/owners']);
  }
  editOwner() {
    if (this._ownersModel.valid) {
    this.submitted = false;

    this.crudservice.updateowner(this._ownersModel.value).subscribe(
      (response: any) => {
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
  else this._ownersModel.markAllAsTouched();
}
}
