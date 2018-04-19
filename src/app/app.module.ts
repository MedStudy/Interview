import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule} from '@angular/router';
import { MyMaterialModule } from './my-material.module';

import { AppRoutes} from './app.routes';

import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { HeaderComponent } from './header/header.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { ReposComponent} from './repos/repos.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    HeaderComponent,
    UserDetailComponent,
    ReposComponent
  ],
  imports: [
    MyMaterialModule,
    BrowserModule,
    FormsModule,
    HttpModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

