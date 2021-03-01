import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { HttpClient } from '@angular/common/http'; //TODO create a generic class for HTTP operations with error handling

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  //private http: HttpClient
  constructor() { }
  appointments: Array<Appointment> = [
    { id: 1, slotFrom: 91, slotTo: 93, appointmentDate: null, petId: null },
    { id: 2, slotFrom: 102, slotTo: 103, appointmentDate: null, petId: null }
    // { id: 3, slotFrom: 110, slotTo: 110, appointmentDate: null, petId: null },
    // { id: 4, slotFrom: 112, slotTo: 130, appointmentDate: null, petId: null }
  ];

  //TODO Remove this method once the server side coding & Sql is completed. 
  getNextId() {
    return (Math.max.apply(Math, this.appointments.map(function (o) { return o.id; }))) + 1;
  }

  getAll() {
    return of(this.appointments);
  }

  save(data: Appointment): Observable<any> {
    this.appointments.push(data);
    return of(this.appointments);
    // return this.http
    //   .post<{ data: Review }>(`api/v1/reviews`, params)
    //   .pipe(map(res => res.data));
    //TODO create a generic class for HTTP operations with error handling
    //data.slotFrom = this.http.encodeDate(appointment.slotFrom);
    //data.slotTo = this.http.encodeDate(appointment.slotTo);
    //return this.http.post<Appointment, Appointment>(this.http.resolveApiUrl("appointments"), data);
  }
}
