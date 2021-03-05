import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VetsService {
  constructor(private http: HttpClient) {}

  public getVetAvailability(datetime: string): Observable<Array<any>> {
    return this.http.get<any>(`/api/vet?dateTime=${datetime}`);
  }
}
