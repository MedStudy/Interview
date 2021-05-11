import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MetaService } from './services/meta.service';
import { BackendService } from './services/backend.service.service';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AppHeaderComponent } from './components/appheader/appheader.component';
import { MaterialModule } from './material/material.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [NavBarComponent, AppHeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [
    MetaService,
    BackendService
  ],
  exports:[
    NavBarComponent,
    AppHeaderComponent,
    MaterialModule
  ]
})
export class SharedServicesModule { }
