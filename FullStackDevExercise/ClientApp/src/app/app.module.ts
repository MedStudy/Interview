import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { SharedServicesModule } from './shared-services/shared-services.module'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedServicesModule,
    BrowserAnimationsModule
  ],
  providers: [],
  exports : [
    SharedServicesModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
