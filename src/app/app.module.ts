import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule} from '@angular/router';
import { MyMaterialModule } from './my-material.module';
import { MainService } from './main/main.service';
import { AppRoutes} from './app.routes';
import { LimitToPipe } from './shared/limit-to.pipe'

import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    LimitToPipe
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    MyMaterialModule,
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [MainService],
  bootstrap: [AppComponent]
})
export class AppModule { }
