import { Injectable } from '@angular/core';
import { Appointment } from './appointment.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {
  URL: string = 'http://localhost:22917/api'
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin':'*'
    }),
  };

  addAppointment(appointment: Appointment) {
    return this.http.post(this.URL + '/appointment/AddAppointment/', appointment, this.httpOptions);
  }
  GetAppointments(id: number) {
    return this.http.get(this.URL + '/appointment/GetAppointments/' + id, this.httpOptions);
  }
  deleteAppointment(id: number){
    return this.http.get(this.URL + '/appointment/DeleteAppointment/' + id, this.httpOptions);
  }
  markCompleteAppointment(id: number){
    return this.http.get(this.URL + '/appointment/MarkCompleteAppointment/' + id, this.httpOptions);
  }
  GetOwners(id: number) {
    return this.http.get(this.URL + '/owner/GetOwners/' + id, this.httpOptions);
  } 
  GetPets(id: number) {
    return this.http.get(this.URL + '/pet/GetPets/' + id, this.httpOptions);
  }
}
