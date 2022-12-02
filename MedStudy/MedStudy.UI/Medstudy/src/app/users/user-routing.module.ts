import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { UsersListComponent } from './users-list/users-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpService } from '../common/http-service.service';
import { SharedService } from '../common/shared-service.service';
import { AgGridModule } from 'ag-grid-angular';
import { UserService } from './user-service.service';


const routes:Route[] = [{path:"",component:UsersListComponent}];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,FormsModule,ReactiveFormsModule,
    RouterModule.forChild(routes),AgGridModule
  ],
  providers:[SharedService,UserService]
})
export class UserRoutingModule { }
