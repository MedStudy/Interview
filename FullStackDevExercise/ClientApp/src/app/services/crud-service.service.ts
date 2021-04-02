import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const owner_baseUrl = 'https://localhost:44397/api/owners';
const pet_baseUrl = 'https://localhost:44397/api/pets';

@Injectable({
  providedIn: 'root',
})
export class CrudServiceService {
  constructor(private http: HttpClient) {}

  getowners() {
    return this.http.get(owner_baseUrl + '/getAll');
  }
  getparticularowners(id) {
    return this.http.get(owner_baseUrl + '/get/' + id);
  }
  createowner(ownerData) {
    return this.http.post(owner_baseUrl + '/create', ownerData);
  }
  updateowner(ownerData) {
    return this.http.put(owner_baseUrl + '/update', ownerData);
  }
  deleteparticularowners(id) {
    return this.http.delete(owner_baseUrl + '/delete/' + id);
  }

  getappointments() {
    return this.http.get(owner_baseUrl + '/appointments');
  }
  getparticularappointments(id) {
    return this.http.get(owner_baseUrl + '/appointments/' + id);
  }
  createappointment(appointmentData) {
    return this.http.post(owner_baseUrl + '/appointments', appointmentData);
  }
  updateappointment(id, appointmentData) {
    return this.http.put(
      owner_baseUrl + '/appointments/' + id,
      appointmentData
    );
  }
  deleteparticularappointments(id) {
    return this.http.delete(owner_baseUrl + '/pets/' + id);
  }

  getpets() {
    return this.http.get(pet_baseUrl + '/getAll');
  }
  getparticularpets(id) {
    return this.http.get(pet_baseUrl + '/get/' + id);
  }
  createpet(petData) {
    return this.http.post(pet_baseUrl + '/create', petData);
  }
  updatepet(petData) {
    return this.http.put(pet_baseUrl + '/update', petData);
  }
  deleteparticularpets(id) {
    return this.http.delete(pet_baseUrl + '/delete/' + id);
  }
}