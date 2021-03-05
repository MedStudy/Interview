import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
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
  AppointmentEditorComponent,
  AppointmentListComponent,
  OwnerEditorComponent,
  OwnerListComponent,
  PetEditorComponent,
  PetListComponent
} from './components';
import { ComponentsModule } from './components/components.module';
import {
  AdminLayoutComponent
} from './layouts/admin-layout/admin-layout.component';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatSelectModule,
    MatTooltipModule,
    HttpClientModule,
    ComponentsModule,
    MatNativeDateModule,
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
