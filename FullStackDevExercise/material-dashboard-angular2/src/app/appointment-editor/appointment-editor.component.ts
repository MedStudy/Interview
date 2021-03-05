import { Component, OnInit } from '@angular/core';

import { OwnersService } from 'app/owners.service';
import { PetsService } from 'app/pets.service';

import { AppointmentsService } from '../appointments.service';

@Component({
  selector: 'app-appointment-editor',
  templateUrl: './appointment-editor.component.html',
  styleUrls: ['./appointment-editor.component.css']
})
export class AppointmentEditorComponent implements OnInit {
  constructor(
    private appointmentService: AppointmentsService,
    private ownerService: OwnersService,
    private petService: PetsService
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
}
