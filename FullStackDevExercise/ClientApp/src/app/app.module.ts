import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddOwnerComponent } from './owner/add-owner/add-owner.component';
import { OwnerListComponent } from './owner/owner-list/owner-list.component';
import { AddPetComponent } from './pet/add-pet/add-pet.component';
import { PetListComponent } from './pet/pet-list/pet-list.component';
import { AddAppointmentComponent } from './appointment/add-appointment/add-appointment.component';
import { AppointmentDetailComponent } from './appointment/appointment-detail/appointment-detail.component';
import { AppointmentListComponent } from './appointment/appointment-list/appointment-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { EditownerComponent } from './owner/editowner/editowner.component';
import { EditpetComponent } from './pet/editpet/editpet.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    AddOwnerComponent,
    OwnerListComponent,
    AddPetComponent,
    PetListComponent,
    AddAppointmentComponent,
    AppointmentDetailComponent,
    AppointmentListComponent,
    EditownerComponent,
    EditpetComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
