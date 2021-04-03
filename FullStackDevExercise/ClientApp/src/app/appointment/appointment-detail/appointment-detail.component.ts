import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { appointmentModel } from 'src/app/models/appointmentModel';
import { ownersModel } from 'src/app/models/ownerModel';
import { petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';
import { checkcustomrequired } from 'src/app/validators/checkcustomrequired';

@Component({
  selector: 'app-appointment-detail',
  templateUrl: './appointment-detail.component.html',
  styleUrls: ['./appointment-detail.component.css']
})
export class AppointmentDetailComponent implements OnInit {
  submitted: boolean = false;
  _ownersmodel: ownersModel[] = [];
  _petsmodel: petsModel[] = [];
  _petsmodelAll: petsModel[] = [];
  _appointmentModel: FormGroup = new FormGroup({});
  timearrayfrom: { text: string; value: number }[] = [];
  timearrayto: { text: string; value: number }[] = [];
  constructor(private crudservice: CrudServiceService,
    private route: ActivatedRoute,
    private router: Router,
    private formgroup: FormBuilder) {}

  ngOnInit(): void {
    this.initform(new appointmentModel());
    for (let i = 8; i < 23; i++) {
      this.timearrayfrom.push({
        text: i.toString().padStart(2, '0') + ':00',
        value: i,
      });
    }
    this.crudservice.getowners().subscribe((rr: any) => {
      this._ownersmodel = rr;
      this.crudservice.getpets().subscribe(
        (response: any) => {
          this._petsmodelAll = response;
          //fetcha ppointment
          this.fetchappointment(parseInt(this.route.snapshot.paramMap.get('id')));
        },
        (error) => {
          alert('Something went wrong!!');
        }
      );
    });
  }
  initform(appointmentdata: appointmentModel) {
    this._appointmentModel = this.formgroup.group({
      id: new FormControl(appointmentdata.id),
      owner_id: new FormControl(appointmentdata.owner_id, [
        Validators.required, checkcustomrequired()
      ]),
      pet_id: new FormControl(appointmentdata.pet_id, [Validators.required,checkcustomrequired()]),
      date: new FormControl(appointmentdata.date, [Validators.required]),
      fromtime: new FormControl(appointmentdata.fromtime, [
        Validators.required,checkcustomrequired()
      ]),
      totime: new FormControl(appointmentdata.totime, [Validators.required,checkcustomrequired()]),
    });
  }
  fetchappointment(id: number) {
    this.initform(new appointmentModel());
   
      this.crudservice.getparticularappointments(id).subscribe(
        (response: any) => {
          this.initform(response);
          this.changefrom();
          this.filterpets();
          this.initform(response);
        },
        (error) => {
          alert('Something went wrong!!');
        }
      );
  }
  filterpets()
    {
      this._petsmodel= this._petsmodelAll.filter(a=> a.owner_id == this._appointmentModel.get('owner_id').value);  
      this._appointmentModel.get('pet_id').patchValue('0');    
    }
  changefrom() {
    this.timearrayto = [];
    if (parseInt(this._appointmentModel.get('fromtime').value) < 23) {
      for (
        let i = parseInt(this._appointmentModel.get('fromtime').value) + 1;
        i < 23;
        i++
      ) {
        this.timearrayto.push({
          text: i.toString().padStart(2, '0') + ':00',
          value: i,
        });
      }
      this._appointmentModel.get('totime').patchValue('0');
    }
  }
  addappointment() {
    if (this._appointmentModel.valid) {
    this.submitted = false;
    this._appointmentModel
    .get('owner_id')
    .patchValue(parseInt(this._appointmentModel.get('owner_id').value));
  this._appointmentModel
    .get('pet_id')
    .patchValue(parseInt(this._appointmentModel.get('pet_id').value));
  this._appointmentModel
    .get('fromtime')
    .patchValue(parseInt(this._appointmentModel.get('fromtime').value));
  this._appointmentModel
    .get('totime')
    .patchValue(parseInt(this._appointmentModel.get('totime').value));
  this._appointmentModel
    .get('date')
    .patchValue(this._appointmentModel.get('date').value.toString());
    this.crudservice.updateappointment(this._appointmentModel.value).subscribe(
      (response: any) => {
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
    }
    else {
      this._appointmentModel.markAllAsTouched();
      this._appointmentModel.updateValueAndValidity();
    }
  }
  addnewappointment() {
    this.initform(new appointmentModel());
    this.router.navigate(['/appointments']);
  }
}
