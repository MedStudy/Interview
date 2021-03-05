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
  public getTimes(): Array<string> {
    return ['10:00 am', '11:00 am', '1:00 pm', '2:00 pm', '3:00 pm', '4:00 pm'];
  }
  public saveAppointment(
    ownerId: number,
    petId: number,
    vetId: number,
    dateTime: string
  ): Observable<any> {
    return this.http.put('api/schedule', {
      OwnerId: ownerId,
      PetId: petId,
      VetId: vetId,
      AppointmentTime: dateTime
    });
  }
}
