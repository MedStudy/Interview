import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MyMaterialModule} from '../my-material.module';
import {SearchComponent} from './search/search.component';
import {UserCardComponent} from './user-card/user-card.component';
import {SearchService} from '../services/search.service';
import {ServicesModule} from '../services/services.module';

@NgModule({
  imports: [
    CommonModule,
    MyMaterialModule,
    ServicesModule
  ],
  declarations: [
    SearchComponent,
    UserCardComponent
  ],
  exports: [
    MyMaterialModule,
    ServicesModule,
    SearchComponent,
    UserCardComponent
  ],
  providers: [
    SearchService
  ]
})
export class UiComponentsModule { }
