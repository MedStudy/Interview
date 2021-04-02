import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddAppointmentComponent } from './appointment/add-appointment/add-appointment.component';
import { AppointmentDetailComponent } from './appointment/appointment-detail/appointment-detail.component';
import { AppointmentListComponent } from './appointment/appointment-list/appointment-list.component';
import { AddOwnerComponent } from './owner/add-owner/add-owner.component';
import { EditownerComponent } from './owner/editowner/editowner.component';
import { OwnerListComponent } from './owner/owner-list/owner-list.component';
import { AddPetComponent } from './pet/add-pet/add-pet.component';
import { EditpetComponent } from './pet/editpet/editpet.component';
import { PetListComponent } from './pet/pet-list/pet-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'owners', pathMatch: 'full' },
  { path: 'owners', component: OwnerListComponent },
  { path: 'owners/add', component: AddOwnerComponent },
  { path: 'owneredit/:id', component: EditownerComponent },

  { path: 'pets', component: PetListComponent },
  { path: 'pets/add', component: AddPetComponent },
  { path: 'petedit/:id', component: EditpetComponent },

  { path: 'appointments', component: AppointmentListComponent },
  { path: 'appointments/add', component: AddAppointmentComponent },
  { path: 'appointment/:id', component: AppointmentDetailComponent },

  { path: '**', component: PetListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
