import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule} from '@angular/router';
import { MyMaterialModule } from './my-material.module';

import { AppRoutes} from './app.routes';

import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import {UiComponentsModule} from './ui/ui-components.module';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {LoadingIndicatorInterceptor, LoadingIndicatorService} from './services/loading-indicator.service';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    MyMaterialModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    UiComponentsModule
  ],
  exports: [
    MyMaterialModule
  ],
  providers: [
    LoadingIndicatorService,
    {
      provide: HTTP_INTERCEPTORS,
      useFactory: ( service: LoadingIndicatorService ) => new LoadingIndicatorInterceptor( service ),
      multi: true,
      deps: [ LoadingIndicatorService ]
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
