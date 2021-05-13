import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MetaService } from './services/meta.service';
import { BackendService } from './services/backend.service.service';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AppHeaderComponent } from './components/appheader/appheader.component';
import { MaterialModule } from './material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';



@NgModule({
  declarations: [NavBarComponent, AppHeaderComponent, DeleteDialogComponent],
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
    MaterialModule,
    DeleteDialogComponent
  ]
})
export class SharedServicesModule { }
