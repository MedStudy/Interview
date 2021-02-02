import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Appointment } from 'src/app/entities/appointment.entity';
import { AppointmentService } from 'src/app/services/appointment.service';
import { AppointmentUpdateCardComponent } from '../appointment-update-card/appointment-update-card.component';
import { AddAppointmentComponent } from '../add-appointment/add-appointment.component';

@Component({
  selector: 'app-appointment',
	templateUrl: 'appointment.component.html'
})

export class AppointmentComponent implements OnInit, AfterViewInit {
	appointments: Appointment[];
	displayedColumns: string[] = ['id', 'client_name', 'pet_type', 'age', 'appointment_date', 'edit', 'remove'];
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

	constructor(
		private appoinmentService: AppointmentService,
    private router: Router,
    public dialog: MatDialog
	) { }

	async ngOnInit() {
    this.appointments = await this.appoinmentService.getAllAppointments();
    this.dataSource = new MatTableDataSource<any>(this.appointments);

  }

  ngAfterViewInit(){
    if(!!this.appointments){
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    }
  }
  
  async updateAppointment(id: any){
    // add update card here
    var appointment = this.appointments.find(x => x.id == id);
    const dialogRef = this.dialog.open(AppointmentUpdateCardComponent, {
      width: '450px',
      height: '350px',
      data: {id: appointment.id, client_Name: appointment.client_Name, pet_Type: appointment.pet_Type, age: appointment.age, appointment_Date: appointment.appointment_Date }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(!!result){
        this.appoinmentService.updateAppointment(result.id, result);
        let index = this.appointments.findIndex(x => x.id == result.id);
        this.appointments[index] = result;
        this.dataSource = new MatTableDataSource<any>(this.appointments);
      }
      
    });
  }

  addAppointment(){
    // add card here
    const dialogRef = this.dialog.open(AddAppointmentComponent, {
      width: '400px',
      height: '350px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(!!result){
        console.log('The dialog was closed');
        this.appointments.push(result);
        this.dataSource = new MatTableDataSource<any>(this.appointments);
      }
        
      
    });
  }

  async deleteAppointment(id: number){
    // delete owner here
    this.appoinmentService.deleteAppointment(id);
    let index = this.appointments.findIndex(x => x.id == id);
    this.appointments.splice(index, 1);
    this.dataSource = new MatTableDataSource<any>(this.appointments);
  }

  applyFilter(value: any){
    console.log(typeof(value));
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
}