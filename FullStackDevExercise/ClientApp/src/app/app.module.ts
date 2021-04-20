import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {  ReactiveFormsModule } from '@angular/forms';

import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule} from '@angular/material/dialog';
import {MatDatepickerModule } from '@angular/material/datepicker';
import {MatTableModule} from '@angular/material/table';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { MediaMatcher } from '@angular/cdk/layout';


import { CalendarComponent } from './components/calendar/calendar.component';
import { AppointmentFormComponent } from './components/appointment-form/appointment-form.component';
import { HomeComponent } from './components/home/home.component';
import { CreateOwnerComponent } from './components/create-owner/create-owner.component';
import { ViewOwnerComponent } from './components/view-owners/view-owners.component';


import { PetFormComponent } from './components/pet-form/pet-form.component';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CalendarComponent,
    AppointmentFormComponent,
    HomeComponent, CreateOwnerComponent,
    ViewOwnerComponent,
     PetFormComponent
  ],
  imports: [
    
    BrowserModule,
    HttpClientModule,
    MatButtonToggleModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatTabsModule,
    MatNativeDateModule,
    MatTableModule,
    MatDialogModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    MatInputModule
  ],
providers: [MediaMatcher,
    MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
