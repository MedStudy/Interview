import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { AppModule } from 'src/app/app.module';
import { Appointment } from 'src/app/core/models/appointment.model';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Owner } from 'src/app/core/models/owner.model';
import { AppointmentService } from 'src/app/core/services/appointment.service';
import { OwnerService } from 'src/app/core/services/owner.service';
//import { SharedDataService } from 'src/app/core/services/shared-data.service';
import { UtilityService } from 'src/app/core/services/utility.service';
import { Pet } from '../../core/models/pet.model';
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
  hideOwnerFields: boolean;
  //petTypes:["Dog","Cat","Rabbit","Other"]; //TODO get this through API call.
  selectedPetType:any;
  message: string;
  subscription: Subscription;
  closeResult = '';
  notes: string;
  ownerFormModel: any = { owner: { firstName: null, lastName: null }, pet: {ownerId:null,name:null,age:null,type:null}};
  petTypes = [
    { id: 1, name: "Dog" },
    { id: 2, name: "Cat" },
    { id: 3, name: "Rabbit" },
    { id: 4, name: "Other" }
  ];
  constructor(private ownerService: OwnerService, private utilService: UtilityService, private appointmentService: AppointmentService, private modalService: NgbModal) { }

  ngOnInit(): void {
   
    console.log(this.petTypes);
    //this.subscription = this.sharedData.currentMessage.subscribe(message => this.message = message)
    this.ownerService.getAll().subscribe((result) => {
      this.owners = result;

    });
    this.slotFromTime = this.utilService.getTimeText(this.selectedSlots.slotFrom);
    this.slotToTime = this.utilService.getTimeText(this.selectedSlots.slotTo, true);
  }

  onOwnerAdd(form) {
    let owner: Owner = new Owner();
    owner.id = 0;
    owner.firstName=this.ownerFormModel.owner.firstName;
    owner.lastName = this.ownerFormModel.owner.lastName;
    owner.pets = new Array<Pet>();
    owner.pets.push(this.ownerFormModel.pet);
    if (!this.hideOwnerFields) {
      this.ownerService.save(owner).subscribe((result) => {
        this.owners = result;
        this.modalService.dismissAll('Owner Added!!.')
      });
    }
    else {
      this.ownerFormModel.pet.ownerId = this.selectedOwner.id;
      this.ownerService.savePet(this.ownerFormModel.pet).subscribe((result) => {
        this.selectedOwner.pets = result;
        this.modalService.dismissAll('Pet Added!!.')
      });
    }
    console.log(this.ownerFormModel);
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
    let appointment: Appointment = { id: 0, slotFrom: this.selectedSlots.slotFrom, slotTo: this.selectedSlots.slotTo, appointmentDate: this.selectedDate.toISOString(), petId: this.selectedPetId, notes: this.notes };
    console.log(appointment);
    this.appointmentService.save(appointment).subscribe((result) => {
      this.notifyAppointmentBooked.emit();
    });
    //this.sharedData.changeMessage("book msg" + this.selectedSlots.slotFrom)
  }
  open(content, hideOwnerFields) {
    this.hideOwnerFields = hideOwnerFields;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  ngOnDestroy() {
    //this.subscription.unsubscribe();
  }

}
