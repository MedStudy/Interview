import { NullTemplateVisitor } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Appointment } from 'src/app/core/models/appointment.model';
import { HourSlot, SlotSatus } from 'src/app/core/models/hour-slot.model';
import { AppointmentService } from '../../core/services/appointment.service';
import { UtilityService } from 'src/app/core/services/utility.service';
import { Subscription } from 'rxjs';
import { SharedDataService } from 'src/app/core/services/shared-data.service';

@Component({
  selector: 'app-daily-schedule',
  templateUrl: './daily-schedule.component.html',
  styleUrls: ['./daily-schedule.component.css']
})
export class DailyScheduleComponent implements OnInit {

  //TODO make it as class
  //hours: Hour[];
  //slotsPerHour: number = 4; //instead of this change checking to slotsPerHourArray.length
  closeResult: string;
  workingHours: number[] = [9, 10, 11, 12, 13, 14, 15, 16, 17];
  slotNoStart: number;
  slotNoEnd: number;
  //mapTest: any;
  appointments: Array<Appointment>;
  slotsPerHourArray: number[] = [0, 1, 2, 3];
  nextBookedSlot: number;
  hourSlots: HourSlot[] = [];
  selectedSlots: object;

  // message: string;
  // subscription: Subscription;

  constructor(private modalService: NgbModal, private appointmentService: AppointmentService, private utilService: UtilityService, private sharedData: SharedDataService) { }

  ngOnInit(): void {
    this.initHourSlots();
    this.populateAppointments()
    // this.subscription = this.sharedData.currentMessage.subscribe(message => { 
    //   this.message = message;
    // })
  }

  populateAppointments() {
    //Get list of appointments, from these map hoursList and assign to map set
    this.appointmentService.getAll().subscribe((result) => {
      this.appointments = result;
      //let _this=this;
      //TODO assign hour slotStatus to booked for booked slots
      for (var i = 0; i < this.appointments.length; i++) {
        let hs: HourSlot = this.hourSlots.filter(c => c.id == this.appointments[i].slotFrom)[0]
        hs.slotStatus = SlotSatus.Booked;
        hs.appointment = this.appointments[i];
        //to avoid floating point add issue like 9.1+0.1=9.299999999999999 
        let slotNo: number = this.calcNextSlotNo(this.appointments[i].slotFrom);
        while (slotNo <= this.appointments[i].slotTo) {
          let hs: HourSlot = this.hourSlots.filter(c => c.id == slotNo)[0]
          hs.slotStatus = SlotSatus.Booked;
          hs.appointment = this.appointments[i];
          //this.mapTest.set(slotNo, hs);
          slotNo = this.calcNextSlotNo(slotNo);
        }
      }
      console.log(this.hourSlots);
    });
  }

  calcNextSlotNo(slotNo: number) {
    //TODO add comment for logic implemeneted.
    let slotBaseNumber = Math.floor(slotNo / 10) * 10;
    if ((slotNo - slotBaseNumber) == (this.utilService.slotsPerHour - 1))
      slotNo = ((slotBaseNumber / 10) + 1) * 10;
    else
      slotNo = slotNo + 1;
    return slotNo;
  }

  initHourSlots() {
    //this.mapTest = new Map();
    //represent in 24hr timing for easy mathematical calculations
    for (var h = 9; h <= 17; h++) {
      for (var s = 0; s < this.utilService.slotsPerHour; s++) {
        //this.mapTest.set(h * 10 + (s), null);
        let timeText = this.getCellTimeText(h, s)
        this.hourSlots.push(new HourSlot(h * 10 + (s), SlotSatus.None, null, timeText))
      }
    }
    //console.log(this.mapTest);
  }

  getCellTimeText(h: number, s: number) {
    let time = "";
    let slotTime = (s * 15).toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false });
    if (h > 12)
      time = (h - 12) + ":" + slotTime + " PM"
    else
      time = (h) + ":" + slotTime + " AM"
    return time;
  }

  findNextBookedSlot(slotNo: number) {
    let bookings: Appointment[] = this.appointments.filter(c => c.slotFrom > slotNo)
    if (bookings.length > 0) {
      if (bookings.length > 1) {
        bookings = bookings.sort((r1, r2) => r1.slotFrom > r2.slotFrom ? 1 : -1)
      }
      this.nextBookedSlot = bookings[0].slotFrom;
    }
    else
      //set as last Slot 5:45pm (5=>17, 45/15(interval)=3)
      this.nextBookedSlot = 173;//TOCHECK
  }

  onNotifySlotSelected(slotNo: number) {
    if (!this.slotNoStart || this.slotNoStart == null) {
      this.slotNoStart = slotNo
      this.findNextBookedSlot(slotNo);
    }
    else {
      if (slotNo > this.nextBookedSlot || slotNo < this.slotNoStart) {
        let prevNBS = this.nextBookedSlot;
        this.findNextBookedSlot(slotNo);
        this.slotNoStart = slotNo;
        if (prevNBS != this.nextBookedSlot)
          this.slotNoEnd = null;
        //Clear prev selection
        let hs: HourSlot[] = this.hourSlots.filter(c => (c.id < this.slotNoStart || c.id > this.nextBookedSlot) && c.slotStatus == SlotSatus.Booking)
        hs.forEach(c => c.slotStatus = SlotSatus.None);
      }
      else
        this.slotNoEnd = slotNo;
    }

    let hs2: HourSlot = this.hourSlots.filter(c => c.id == slotNo)[0];
    hs2.slotStatus = SlotSatus.Booking;
    //console.log(this.hourSlots);
    //TODO UnitTest logic
    if (this.slotNoEnd == null)
      this.slotNoEnd = this.slotNoStart;

    //mark slot range as booking
    if (this.slotNoStart && this.slotNoEnd) {
      //clear all with booking status 
      let hsBooking: HourSlot[] = this.hourSlots.filter(c => (c.slotStatus == SlotSatus.Booking))
      hsBooking.forEach(c => c.slotStatus = SlotSatus.None);
      //assign new range
      let hs: HourSlot[] = this.hourSlots.filter(c => (c.id >= this.slotNoStart && c.id <= this.slotNoEnd))
      hs.forEach(c => c.slotStatus = SlotSatus.Booking);
    }
    this.selectedSlots = {
      slotFrom: this.slotNoStart,
      slotTo: this.slotNoEnd //TODO find prev booked slot if not last slot in matrix, also check if last slot is booked.(this is an exception case)
    };
    console.log(this.selectedSlots);

  }

  onAppointmentBooked(msg) {
    this.populateAppointments();
    //Clear selected slot range
    this.slotNoStart = null;
    this.slotNoEnd = null;
  }

  open(slotNumber) {
    //this.mapTest.set("9.0", slotNumber)
    // if (!this.selectSlotStart)
    //   this.selectSlotStart = slotNumber;
    // else
    //   this.selectSlotEnd = slotNumber;
    alert(slotNumber);
  }

  // open(content) {
  //   this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
  //     this.closeResult = `Closed with: ${result}`;
  //   }, (reason) => {
  //     this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
  //   });

  // }

  // private getDismissReason(reason: any): string {
  //   if (reason === ModalDismissReasons.ESC) {
  //     return 'by pressing ESC';
  //   } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
  //     return 'by clicking on a backdrop';
  //   } else {
  //     return `with: ${reason}`;
  //   }
  // }

  ngOnDestroy() {
    //this.subscription.unsubscribe();
  }

}
