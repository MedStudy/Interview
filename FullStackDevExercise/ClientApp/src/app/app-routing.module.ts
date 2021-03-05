import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {
  AppointmentListComponent
} from './appointment-list/appointment-list.component';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { PetListComponent } from './pet-list/pet-list.component';

const routes: Routes = [
  { path: 'owners', component: OwnerListComponent },
  { path: 'pets', component: PetListComponent },
  { path: 'appointments', component: AppointmentListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
