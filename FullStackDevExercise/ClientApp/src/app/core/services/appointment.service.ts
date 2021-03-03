import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { HttpClient } from '@angular/common/http'; //TODO create a generic class for HTTP operations with error handling
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http: HttpClient) { }
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

  /*getAll() {
    //let bookings = this.appointments.filter(c => c.appointmentDate == date);
    return of(this.appointments);
  }*/

  getByDate(date: any): Observable<Array<Appointment>> {
    return this.http
      .get<Array<Appointment>>(`api/appointment/by-date/${date}`)
      .pipe(map(resp => resp));
  }

  //TODO create a generic class for HTTP operations with error handling
  save(data: Appointment): Observable<any> {
    /**** Mock code 
    //this.appointments.push(data);
    //return of(this.appointments); ***/
     return this.http
       .post<any>(`api/Appointment`, data)
       .pipe(map(res => res));
  }
}
