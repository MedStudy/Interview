import { Component, OnInit } from '@angular/core';

import { AppointmentsService } from 'app/services';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {
  constructor(private appointmentService: AppointmentsService) {}

  public isEditing = false;
  public appointments: Array<any>;
  ngOnInit(): void {
    this.appointmentService.listAppointments().subscribe(x => {
      this.appointments = x;
    });
  }
}
