import { Component, OnInit } from '@angular/core';

import { AppointmentsService } from '../appointments.service';

@Component({
  selector: 'app-appointment-editor',
  templateUrl: './appointment-editor.component.html',
  styleUrls: ['./appointment-editor.component.css']
})
export class AppointmentEditorComponent implements OnInit {
  constructor(private appointmentService: AppointmentsService) {}

  ngOnInit(): void {}
}
