import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule} from '@angular/router';
import { MyMaterialModule } from './my-material.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutes} from './app.routes';
import {MatButtonModule, MatCheckboxModule} from '@angular/material';
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { GithubapiService } from './services/githubapi.service';
import {MatInputModule} from '@angular/material/input';
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
    MatButtonModule, MatCheckboxModule,MatInputModule,
    FormsModule,
    HttpModule
  ],
  providers: [GithubapiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
