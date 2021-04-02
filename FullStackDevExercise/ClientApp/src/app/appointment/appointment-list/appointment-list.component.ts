import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { appointmentListModel } from 'src/app/models/appointmentModel';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css'],
})
export class AppointmentListComponent implements OnInit {
  submitted: boolean = false;
  _appointmentsModel: appointmentListModel[] = [new appointmentListModel()];

  constructor(
    private crudservice: CrudServiceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetappointments();
  }
  fetappointments() {
    this._appointmentsModel = [];
    this.crudservice.getappointments().subscribe(
      (response: any) => {
        this._appointmentsModel = response;
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
  edit(id: number) {
    this.router.navigate(['/appointmentedit', id]);
  }
  delete(id: number) {
    let a = confirm('Are you sure, you want to delete pet with id=' + id);
    if (a) {
      this.crudservice.deleteparticularappointments(id).subscribe(
        (response: any) => {
          this.submitted = false;
          this.fetappointments();
          alert('Appointment deleted successfully !!');
        },
        (error) => {
          this.submitted = false;
          alert('Something went wrong!!');
        }
      );
    } else {
      // user cancel the delete operation
    }
  }
}
