import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { AppModule } from 'src/app/app.module';
import { Appointment } from 'src/app/core/models/appointment.model';
//import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Owner } from 'src/app/core/models/owner.model';
import { AppointmentService } from 'src/app/core/services/appointment.service';
import { OwnerService } from 'src/app/core/services/owner.service';
//import { SharedDataService } from 'src/app/core/services/shared-data.service';
import { UtilityService } from 'src/app/core/services/utility.service';
@Component({
  selector: 'app-appointment-editor',
  templateUrl: './appointment-editor.component.html',
  styleUrls: ['./appointment-editor.component.css']
})
export class AppointmentEditorComponent implements OnInit, OnChanges {
  @Input() selectedDate: Date;
  @Input() selectedSlots: any;
  @Output() notifyAppointmentBooked = new EventEmitter<any>();
  //@Input() slotTo?: number;
  selectedOwnerId: number;
  selectedPetId: number;
  selectedOwner: Owner;
  owners: Owner[];
  slotFromTime: string;
  slotToTime: string;

  message: string;
  subscription: Subscription;

  constructor(private ownerService: OwnerService, private utilService: UtilityService, private appointmentService: AppointmentService) { }

  ngOnInit(): void {
    //this.subscription = this.sharedData.currentMessage.subscribe(message => this.message = message)
    this.ownerService.getAll().subscribe((result) => {
      this.owners = result;
      //this.selectedOwner=result[0];
      //console.log("child",this.selectedOwner);

    });
    //console.log("child",this.owners);
    //this.selectedDate = new Date(Date.now()).toLocaleDateString();
    this.slotFromTime = this.utilService.getTimeText(this.selectedSlots.slotFrom);
    this.slotToTime = this.utilService.getTimeText(this.selectedSlots.slotTo, true);
  }

  ngOnChanges(changes: any) {
    this.slotFromTime = this.utilService.getTimeText(this.selectedSlots.slotFrom);
    this.slotToTime = this.utilService.getTimeText(this.selectedSlots.slotTo, true);
  }

  onOwnerChange(e) {
    this.selectedOwner = this.owners.filter(c => c.id == this.selectedOwnerId)[0];
    this.selectedPetId = 0; //TODO
  }

  bookAppointment() {
    let appointment: Appointment = { id: 0, slotFrom: this.selectedSlots.slotFrom, slotTo: this.selectedSlots.slotTo, appointmentDate: this.selectedDate.toISOString(), petId: this.selectedPetId };
    console.log(appointment);
    this.appointmentService.save(appointment).subscribe((result) => {
      this.notifyAppointmentBooked.emit(this.selectedSlots.slotFrom)
    });
    //this.sharedData.changeMessage("book msg" + this.selectedSlots.slotFrom)
  }
  ngOnDestroy() {
    //this.subscription.unsubscribe();
  }

}
