import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

import { Pet } from '../entities/pet.entity';

@Injectable()
export class PetService{
    public API = 'http://localhost:8080/api';

    constructor(private http: HttpClient) { }

    async getAllPets(): Promise<Pet[]> {
        return await this.http.get<Pet[]>('https://localhost:44397/api/pets').toPromise();
        
    }

    async getPetById(id: number): Promise<Pet> {
        return await this.http.get<Pet>(`https://localhost:44397/api/pets/${id}`).toPromise();
        
    }

    async addPet(pet: Pet): Promise<Pet> {
        return await this.http.post<Pet>('https://localhost:44397/api/pets', pet).toPromise();
    }

    async updatePet(id, pet: Pet): Promise<Pet> {
        return await this.http.put<Pet>(`https://localhost:44397/api/pets/${id}`, pet).toPromise();
    }

    async deletePet(id) {
        return await this.http.delete<Pet>(`https://localhost:44397/api/pets/${id}`).toPromise();
    }
}