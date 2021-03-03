import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DailyScheduleComponent } from './scheduler/daily-schedule/daily-schedule.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { AppointmentEditorComponent } from './scheduler/appointment-editor/appointment-editor.component';
import { SlotCellComponent } from './scheduler/slot-cell/slot-cell.component';
import { ArrayFirstOrDefaultPipe } from './core/extensions/array-first-or-default.pipe';

@NgModule({
  declarations: [
    AppComponent,
    DailyScheduleComponent,
    AppointmentEditorComponent,
    SlotCellComponent,
    ArrayFirstOrDefaultPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ArrayFirstOrDefaultPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
