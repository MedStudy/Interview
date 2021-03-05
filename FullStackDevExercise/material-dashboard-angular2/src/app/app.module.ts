import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AgmCoreModule } from '@agm/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';
import {
  AppointmentEditorComponent
} from './appointment-editor/appointment-editor.component';
import {
  AppointmentListComponent
} from './appointment-list/appointment-list.component';
import { ComponentsModule } from './components/components.module';
import {
  AdminLayoutComponent
} from './layouts/admin-layout/admin-layout.component';
import { OwnerEditorComponent } from './owner-editor/owner-editor.component';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { PetEditorComponent } from './pet-editor/pet-editor.component';
import { PetListComponent } from './pet-list/pet-list.component';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    MatFormFieldModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'YOUR_GOOGLE_MAPS_API_KEY'
    })
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    PetListComponent,
    PetEditorComponent,
    OwnerListComponent,
    OwnerEditorComponent,
    AppointmentListComponent,
    AppointmentEditorComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
