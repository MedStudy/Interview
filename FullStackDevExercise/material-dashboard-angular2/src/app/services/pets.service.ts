import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PetsService {
  constructor(private http: HttpClient) {}

  public getPets(): Observable<Array<any>> {
    return this.http.get<any>('/api/pet');
  }
}
