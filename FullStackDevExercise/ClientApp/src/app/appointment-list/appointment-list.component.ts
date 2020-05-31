import { Component, OnInit } from '@angular/core';
import { Appointment } from '../appointment.model';
import { DataServiceService } from '../data-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {

  appointments: Appointment[] = [];
  constructor(private dataservice: DataServiceService, private router: Router) { }

  ngOnInit(): void {
    this.getAppointments();
  }

  getAppointments(){
    this.dataservice.GetAppointments(0).subscribe((res: Appointment[]) => {
      this.appointments = res
    });
  }

  onEdit(id: number){
    this.router.navigate(['appointment/update/'+ id])
  }
  
  onDelete(id: number){
    this.dataservice.deleteAppointment(id).subscribe(res =>{
      if(res==1){
        this.getAppointments();
      }
    })
  }
  onComplete(id: number){
    this.dataservice.markCompleteAppointment(id).subscribe(res =>{
      if(res==1){
        this.getAppointments();
      }
    })
  }

}
