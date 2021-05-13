import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PetHomeComponent } from './components/home/home.component';
import { SharedServicesModule } from '../shared-services/shared-services.module';



@NgModule({
  declarations: [PetHomeComponent],
  imports: [
    CommonModule,
    SharedServicesModule
  ],
  exports:[
    PetHomeComponent
  ]
})
export class PetsModule { }
