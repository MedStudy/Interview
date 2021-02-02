import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

import { Owner } from '../entities/owner.entity';

@Injectable()
export class OwnerService{
    public API = 'http://localhost:8080/api';

    constructor(private http: HttpClient) { }

    async getAllOwners(): Promise<Owner[]> {
        return await this.http.get<Owner[]>('https://localhost:44397/api/owners').toPromise();
        
    }

    async getOwnerById(id: number): Promise<Owner> {
        return await this.http.get<Owner>(`https://localhost:44397/api/owners/${id}`).toPromise();
        
    }

    async addOwner(owner: Owner): Promise<Owner> {
        return await this.http.post<Owner>('https://localhost:44397/api/owners', owner).toPromise();
    }

    async updateOwner(id, owner: Owner): Promise<Owner> {
        return await this.http.put<Owner>(`https://localhost:44397/api/owners/${id}`, owner).toPromise();
    }

    async deleteOwner(id) {
        return await this.http.delete<Owner>(`https://localhost:44397/api/owners/${id}`).toPromise();
    }
}