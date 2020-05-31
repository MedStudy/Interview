import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { PetListComponent } from './pet-list/pet-list.component';


const routes: Routes = [
  // {
  //   path: 'owners',
  //   component: OwnerComponent
  // },
  // {
  //   path: 'pets',
  //   component: PetComponent
  // },
  {
    path: '',
    pathMatch: "full",
    component: AppointmentListComponent,
  },
  {
    path: 'appointment/update',
    component: AppointmentComponent,
  },
  {
    path: 'appointment/update/:id',
    component: AppointmentComponent,
  },
  {
    path: 'appointment/list',
    redirectTo: '',
  },
  {
    path: 'owner/list',
    component: OwnerListComponent,
  },
  {
    path: 'pet/list',
    component: PetListComponent,
  },
  {
    path: '**',
    redirectTo: '',
  }
];

@NgModule({
  imports:  [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
