import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pet } from 'src/app/shared-services/models/pet';
import { BackendService } from '../../shared-services/services/backend.service.service'

@Injectable({
  providedIn: 'root'
})
export class PetsService {
  constructor(private backend: BackendService) {
   }

   getAllPets(): Observable<Pet[]> {
    return this.backend.get(this.backend.getApiUrl("pets/GetAllPets"));
  }

  getPetById(id: number): Observable<Pet>{
    return this.backend.get(this.backend.getApiUrl("pets/GetPetById",id.toString()));
  }

  createPet(data: Pet): Observable<Pet> {
    return this.backend.post<Pet, Pet>(this.backend.getApiUrl("pets/CreatePet"), data);
  }

  updatePet(data: Pet) : Observable<Pet> {
    return this.backend.put<Pet, Pet>(this.backend.getApiUrl("pets/UpdatePet", data.id.toString()), data);
  }

  deletePet(id: number): Observable<boolean> {
    return this.backend.delete<boolean>(this.backend.getApiUrl("pets/DeletePet", id.toString()))
  }

}
