import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MyMaterialModule} from '../my-material.module';
import {SearchComponent} from './search/search.component';
import {UserCardComponent} from './user-card/user-card.component';
import {SearchService} from '../services/search.service';
import {ServicesModule} from '../services/services.module';
import {LoadingComponent} from './loading/loading.component';

@NgModule({
  imports: [
    CommonModule,
    MyMaterialModule,
    ServicesModule
  ],
  declarations: [
    SearchComponent,
    UserCardComponent,
    LoadingComponent
  ],
  exports: [
    MyMaterialModule,
    ServicesModule,
    SearchComponent,
    UserCardComponent,
    LoadingComponent
  ],
  providers: [
    SearchService
  ]
})
export class UiComponentsModule { }
