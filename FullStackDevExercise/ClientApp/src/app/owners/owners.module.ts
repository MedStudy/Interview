import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { routes } from './owners.routes';
import { OwnersService } from './services/owners.service'
import { SharedServicesModule } from '../shared-services/shared-services.module';
import { MaterialModule } from '../shared-services/material/material.module';
import { PetsModule } from '../pets/pets.module';
import { OwnerDialogComponent } from './components/dialog/owner-dialog/owner-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [HomeComponent, OwnerDialogComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PetsModule,
    MaterialModule,
    SharedServicesModule,
    RouterModule.forChild(routes)
  ],
  providers:[
    OwnersService,
  ],
  exports:[
    FormsModule,
    ReactiveFormsModule
  ]
})
export class OwnersModule { }
