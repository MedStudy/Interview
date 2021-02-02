import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

import { Appointment } from '../entities/appointment.entity';

@Injectable()
export class AppointmentService{
    public API = 'http://localhost:8080/api';

    constructor(private http: HttpClient) { }

    async getAllAppointments(): Promise<Appointment[]> {
        return await this.http.get<Appointment[]>('https://localhost:44397/api/appointments').toPromise();
        
    }

    async getAppointmentById(id: number): Promise<Appointment> {
        return await this.http.get<Appointment>(`https://localhost:44397/api/appointments/${id}`).toPromise();
        
    }

    async addAppointment(appointment: Appointment): Promise<Appointment> {
        return await this.http.post<Appointment>('https://localhost:44397/api/appointments', appointment).toPromise();
    }

    async updateAppointment(id, appointment: Appointment): Promise<Appointment> {
        return await this.http.put<Appointment>(`https://localhost:44397/api/appointments/${id}`, appointment).toPromise();
    }

    async deleteAppointment(id) {
        return await this.http.delete<Appointment>(`https://localhost:44397/api/appointments/${id}`).toPromise();
    }
}