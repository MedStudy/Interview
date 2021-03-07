import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

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
    this.getAppointments().subscribe();
  }
  public onSave() {
    this.getAppointments().subscribe();
  }
  public remove(a: any) {
    console.log('remove', a);
    this.appointmentService.removeAppointment(a.id).subscribe(x => {
      this.getAppointments().subscribe();
    });
  }

  private getAppointments(): Observable<any> {
    return this.appointmentService.listAppointments().pipe(
      tap(x => {
        this.appointments = x;
      })
    );
  }
}
