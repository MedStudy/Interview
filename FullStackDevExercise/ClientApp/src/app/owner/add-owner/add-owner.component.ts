import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-add-owner',
  templateUrl: './add-owner.component.html',
  styleUrls: ['./add-owner.component.css'],
})
export class AddOwnerComponent implements OnInit {
  submitted: boolean = false;
  _ownersModel: FormGroup = new FormGroup({});
  constructor(
    private crudservice: CrudServiceService,
    private router: Router,
    private formgroup: FormBuilder
  ) {}

  ngOnInit(): void {
    this._ownersModel = this.formgroup.group({
      first_name: new FormControl('', [
        Validators.required,
        Validators.maxLength(50),
      ]),
      last_name: new FormControl('', [
        Validators.required,
        Validators.maxLength(50),
      ]),
    });
  }
  addowner() {  
    this.submitted = false;
  }
  viewall() {
    this.router.navigate(['/owners']);
  }
  newOwner() {
    if (this._ownersModel.valid) {
      this.submitted = false;

      this.crudservice.createowner(this._ownersModel.value).subscribe(
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
