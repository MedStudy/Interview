import { Component, OnInit } from '@angular/core';
import { Appointment } from '../appointment.model';
import { DataServiceService } from '../data-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {

  appointment;
  appointmentId: number;
  datetimeformatted: any;
  constructor(private dataservice: DataServiceService, private route:ActivatedRoute, private router: Router) { 
    this.appointment = new Appointment();
  }

  ngOnInit(): void {
    const datePipe = new DatePipe('en-US');
    this.route.params.subscribe( params => {
      this.appointmentId = params['id']
      if(this.appointmentId){
        this.dataservice.GetAppointments(this.appointmentId).pipe(map(resp => resp as Appointment[])).subscribe((res) =>{
          this.appointment = res[0];
          this.datetimeformatted = datePipe.transform(this.appointment.appointmentDate, 'yyyy-MM-dd');
        });
      }
    });
  }

  addAppointment(){
    let date = new Date(this.datetimeformatted);
    let value = date.getTime();
    this.appointment.appointmentDate = value.toString();
    this.dataservice.addAppointment(this.appointment).subscribe(res => {
      if(res > 0){
        this.router.navigate(['appointment/list/'])
      }
    });
  }

}
