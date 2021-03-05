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
  ngOnInit(): void {
    this.ownerService.getOwners().subscribe(x => {
      this.owners = x;
    });
  }

  public setPets(event: any) {
    console.log(event);
    if (this.selectedOwner) {
      this.petService.getPets().subscribe(x => {
        this.pets = x.filter(x => x.owner.id === this.selectedOwner.id);
      });
    }
  }
  public MakeReservation() {}
}
