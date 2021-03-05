import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {
  constructor(private http: HttpClient) {}

  public listAppointments(): Observable<Array<any>> {
    return this.http.get<any>('api/schedule');
  }
}
