import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { routing } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSliderModule } from '@angular/material/slider';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './components/admin/admin.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatNativeDateModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon'
import { MatSortModule } from '@angular/material/sort';
import { OwnerUpdateCardComponent } from './components/owner-update-card/owner-update-card.component';
import { OwnerComponent } from './components/owner/owner.component';
import { OwnerService } from './services/owner.service';
import { AddOwnerComponent } from './components/add-owner/add-owner.component';
import { PetService } from './services/pet.service';
import { PetComponent } from './components/pet/pet.component';
import { AddPetComponent } from './components/add-pet/add-pet.component';
import { PetUpdateCardComponent } from './components/pet-update/pet-update-card.component';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { AppointmentService } from './services/appointment.service';
import { AppointmentUpdateCardComponent } from './components/appointment-update-card/appointment-update-card.component';
import { AddAppointmentComponent } from './components/add-appointment/add-appointment.component';
import { AppointmentComponent } from './components/appointment/appointment.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    OwnerUpdateCardComponent,
    OwnerComponent,
    AddOwnerComponent,
    PetComponent,
    AddPetComponent,
    PetUpdateCardComponent,
    AppointmentComponent,
    AddAppointmentComponent,
    AppointmentUpdateCardComponent
  ],
  imports: [
    BrowserModule,
    routing,
    BrowserAnimationsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatTableModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatDialogModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatSortModule,
    MatExpansionModule,
    MatIconModule,
    HttpClientModule
  ],
  providers: [
    PetService,
    OwnerService,
    HttpClient,
    AppointmentService
  ],
  entryComponents: [
    OwnerUpdateCardComponent,
    AddOwnerComponent,
    AddPetComponent,
    PetUpdateCardComponent,
    AppointmentUpdateCardComponent,
    AddAppointmentComponent
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }