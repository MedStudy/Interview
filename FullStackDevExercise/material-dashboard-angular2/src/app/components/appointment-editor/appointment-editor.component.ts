import { Component, OnInit } from '@angular/core';

import {
  AppointmentsService,
  OwnersService,
  PetsService,
  VetsService
} from 'app/services';

@Component({
  selector: 'app-appointment-editor',
  templateUrl: './appointment-editor.component.html',
  styleUrls: ['./appointment-editor.component.css']
})
export class AppointmentEditorComponent implements OnInit {
  constructor(
    private appointmentService: AppointmentsService,
    private ownerService: OwnersService,
    private petService: PetsService,
    private vetService: VetsService
  ) {}

  public selectedOwner: any;
  public owners: Array<any>;
  public pets: Array<any>;
  public times: Array<string>;
  public vets: Array<any>;
  ngOnInit(): void {
    this.ownerService.getOwners().subscribe(x => {
      this.owners = x;
    });
    this.times = this.appointmentService.getTimes();
  }

  public setPets(event: any) {
    console.log(event);

    this.petService.getPets().subscribe(x => {
      this.pets = x.filter(x => x.owner.id === event.value);
    });
  }
  public setVet(event: any) {
    this.vetService.getVetAvailability('').subscribe(x => {
      this.vets = x;
    });
  }
  public MakeReservation() {
    console.log('making appointment');
    this.appointmentService.saveAppointment(1, 1, 1, '03/10/2021 11:00 am').subscribe(x => {
      console.log('saved');
    });
  }
}
