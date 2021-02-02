import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Appointment } from 'src/app/entities/appointment.entity';

@Component({
  selector: 'app-appointment-update-card',
  templateUrl: './appointment-update-card.component.html',
  styleUrls: ['./appointment-update-card.component.css']
})
export class AppointmentUpdateCardComponent {

  constructor(
    public dialogRef: MatDialogRef<AppointmentUpdateCardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Appointment) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
