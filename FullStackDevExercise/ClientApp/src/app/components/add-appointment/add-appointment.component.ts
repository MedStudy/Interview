import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Appointment } from 'src/app/entities/appointment.entity';
import { AppointmentService } from 'src/app/services/appointment.service';

@Component({
  selector: 'app-appointment-owner',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.css']
})
export class AddAppointmentComponent implements OnInit {

  activeForm = this.formBuilder1.group({
    id: { value: 0, disabled: true},
    client_Name: ['', [Validators.required]],
    pet_Type: ['', [Validators.required]],
    age: [0, [Validators.required]],
    appointment_Date: ['', Validators.required]
  })

  constructor(private formBuilder1: FormBuilder,
    private appointmentService: AppointmentService,
    public dialogRef: MatDialogRef<AddAppointmentComponent>)
     { }
  
  ngOnInit(): void {
  }

  onCancel(){
    this.dialogRef.close();
  }

  async addAppointment(){
    var obj: Appointment= {
      id: this.activeForm.get('id').value,
      client_Name: this.activeForm.get('client_Name').value,
      pet_Type: this.activeForm.get('pet_Type').value,
      age: this.activeForm.get('age').value,
      appointment_Date: this.activeForm.get('appointment_Date').value,
  };
    var response = await this.appointmentService.addAppointment(obj);
    this.dialogRef.close(response);
  }
}