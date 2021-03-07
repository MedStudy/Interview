import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { combineLatest, Observable } from 'rxjs';

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
  @Output()
  saved = new EventEmitter();

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
  public isError = false;
  public errors: Array<string>;

  public owners$: Observable<any>;
  public datetime$: Observable<any>;

  private owner = new FormControl(undefined, Validators.required);
  private pet = new FormControl(undefined, Validators.required);
  private vet = new FormControl(undefined, Validators.required);
  private date = new FormControl(undefined, Validators.required);
  private time = new FormControl(undefined, Validators.required);

  private currentTime: any;
  private currentDate: any;

  public form: FormGroup = new FormGroup({
    owner: this.owner,
    pet: this.pet,
    vet: this.vet,
    date: this.date,
    time: this.time
  });

  ngOnInit(): void {
    this.owners$ = this.ownerService.getOwners();
    this.times = this.appointmentService.getTimes();
    this.datetime$ = combineLatest(this.date.valueChanges, this.time.valueChanges);
    this.datetime$.subscribe(x => {
      if (x.length === 2) {
        this.currentDate = x[0];
        this.currentTime = x[1];
        this.setAvailability();
      }
    });

    this.owner.valueChanges.subscribe(o => {
      this.petService.getPets().subscribe(x => {
        this.pets = x.filter(x => x.owner.id === o);
      });
      this.setAvailability();
    });
    this.pet.valueChanges.subscribe(o => {
      console.log('pet', o);
      console.log(`${this.currentDate} ${this.currentTime}`);
    });
  }

  public MakeReservation() {
    if (this.form.valid) {
      console.log('making appointment');
      console.log(this.form.getRawValue());
      const fv = this.form.getRawValue();

      var dt = `${fv.date.getMonth() + 1}/${fv.date.getDate()}/${fv.date.getFullYear()} ${fv.time}`;

      this.appointmentService.saveAppointment(fv.owner, fv.pet, fv.vet, dt).subscribe(
        x => {
          console.log('saved');
          this.saved.emit(undefined);
          if (x.status !== 200) {
            this.isError = true;
            this.errors = x.errorMessages;
          } else {
            this.isError = false;
            this.errors = [];
            this.form.reset();
          }
        },
        e => {
          console.log('error', e);
          this.isError = true;
          if (e.error.errorMessages) {
            this.isError = true;
            this.errors = e.error.errorMessages;
          }
        }
      );
    }
  }

  private setAvailability() {
    var dt = `${this.currentDate.getMonth() +
      1}/${this.currentDate.getDate()}/${this.currentDate.getFullYear()} ${this.currentTime}`;
    this.vetService.getVetAvailability(dt).subscribe(x => {
      this.vets = [];
      this.vets = x;
      this.vet.reset();
    });
  }
}
