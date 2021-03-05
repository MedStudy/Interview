import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { OwnerEditorComponent } from './owner-editor/owner-editor.component';
import { PetListComponent } from './pet-list/pet-list.component';
import { PetEditorComponent } from './pet-editor/pet-editor.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AppointmentEditorComponent } from './appointment-editor/appointment-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    OwnerListComponent,
    OwnerEditorComponent,
    PetListComponent,
    PetEditorComponent,
    AppointmentListComponent,
    AppointmentEditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatTabsModule,
    MatIconModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
