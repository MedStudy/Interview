import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalendarComponent } from './components/calendar/calendar.component';
import {AppComponent} from './app.component';
import { ViewOwnerComponent } from './components/view-owners/view-owners.component';

import { CreateOwnerComponent } from './components/create-owner/create-owner.component';
import { HomeComponent } from './components/home/home.component';
import { AppointmentFormComponent } from './components/appointment-form/appointment-form.component';
import { PetFormComponent } from './components/pet-form/pet-form.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
{
  path: 'pets',
  component: PetFormComponent
},
{
  path: 'home',
  component: HomeComponent
},
{
  path: 'appointment',
  component: AppointmentFormComponent
},
{ path: 'owner',
 component: CalendarComponent
}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
