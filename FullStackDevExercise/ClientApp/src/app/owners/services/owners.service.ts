import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Owner } from 'src/app/shared-services/models/owner';
import {BackendService} from '../../shared-services/services/backend.service.service'

@Injectable({
  providedIn: 'root'
})
export class OwnersService {
  constructor(private backend: BackendService) {
   }

   getOwners(): Observable<Owner[]> {
    return this.backend.get(this.backend.getApiUrl("owners/GetAllOwners"));
  }

  createOwner(data: Owner): Observable<Owner> {
    return this.backend.post<Owner, Owner>(this.backend.getApiUrl("owners/CreateOwner"), data);
  }

  updateOwner(data: Owner) : Observable<Owner> {
    return this.backend.put<Owner, Owner>(this.backend.getApiUrl("owners/UpdateOwner", data.id.toString()), data);
  }

  deleteOwner(id: number): Observable<boolean> {
    return this.backend.delete<boolean>(this.backend.getApiUrl("owners/DeleteOwner", id.toString()))
  }

}
