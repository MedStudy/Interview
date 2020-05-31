import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { HttpClientModule } from '@angular/common/http';
import { NiceDatePipe } from './nice-date.pipe';
import { PetComponent } from './pet/pet.component';
import { OwnerComponent } from './owner/owner.component';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { PetListComponent } from './pet-list/pet-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AppointmentListComponent,
    AppointmentComponent,
    NiceDatePipe,
    PetComponent,
    OwnerComponent,
    OwnerListComponent,
    PetListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
