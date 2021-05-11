import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { routes } from './owners.routes';
import { OwnersService } from './services/owners.service'
import { SharedServicesModule } from '../shared-services/shared-services.module';



@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    SharedServicesModule,
    RouterModule.forChild(routes)
  ],
  providers:[
    OwnersService
  ]
})
export class OwnersModule { }
