import { Component, OnInit } from '@angular/core';
import { appointmentModel } from 'src/app/models/appointmentModel';
import { ownersModel } from 'src/app/models/ownerModel';
import { petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.css'],
})
export class AddAppointmentComponent implements OnInit {
  submitted: boolean = false;
  _ownersmodel: ownersModel = new ownersModel();
  _petsmodel: petsModel = new petsModel();
  _appointmentModel: appointmentModel = new appointmentModel();
  timearrayfrom: { text: string; value: number }[] = [];
  timearrayto: { text: string; value: number }[] = [];
  constructor(private crudservice: CrudServiceService) {}

  ngOnInit(): void {
    for (let i = 0; i < 24; i++) {
      if (i < 12)
        this.timearrayfrom.push({
          text: i.toString().padStart(2, '0') + ':00',
          value: i,
        });
    }
    this.crudservice.getowners().subscribe((rr: any) => {
      this._ownersmodel = rr;
      this.crudservice.getpets().subscribe(
        (response: any) => {
          this._petsmodel = response;
        },
        (error) => {
          alert('Something went wrong!!');
        }
      );
    });
  }
  changefrom() {
    this.timearrayto = [];
    if (this._appointmentModel.fromtime < 23)
    {
      for (let i = (parseInt(this._appointmentModel.fromtime.toString()) + 1); i < 24; i++) {
        this.timearrayto.push({
          text: i.toString().padStart(2, '0') + ':00',
          value: i,
        });
      }
    }
  }
  addappointment() {
    this.submitted = false;
    this._appointmentModel.owner_id = parseInt(
      this._appointmentModel.owner_id.toString()
    );
    this._appointmentModel.pet_id = parseInt(
      this._appointmentModel.pet_id.toString()
    );
    this._appointmentModel.fromtime = parseInt(
      this._appointmentModel.fromtime.toString()
    );
    this._appointmentModel.totime = parseInt(
      this._appointmentModel.totime.toString()
    );
    this._appointmentModel.date = this._appointmentModel.date.toString();
    this.crudservice.createappointment(this._appointmentModel).subscribe(
      (response: any) => {
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
  addnewappointment() {
    this._appointmentModel = new appointmentModel();
    this.submitted = false;
  }
}
