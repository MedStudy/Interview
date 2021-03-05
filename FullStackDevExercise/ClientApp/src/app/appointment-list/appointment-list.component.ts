import { Component, OnInit } from '@angular/core';

import { AppointmentsService } from '../appointments.service';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {
  constructor(private appointmentService: AppointmentsService) {}

  ngOnInit(): void {}
}
