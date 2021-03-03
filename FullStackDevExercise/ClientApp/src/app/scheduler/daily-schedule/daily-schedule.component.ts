import { NullTemplateVisitor } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbDate, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
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

  closeResult: string;
  workingHours: number[] = [9, 10, 11, 12, 13, 14, 15, 16, 17];
  slotNoStart: number;
  slotNoEnd: number;
  appointments: Array<Appointment> | null;
  slotsPerHourArray: number[] = [0, 1, 2, 3];
  nextBookedSlot: number;
  hourSlots: HourSlot[] = [];
  selectedSlots: object;
  selectedDate: Date;

  // message: string;
  // subscription: Subscription;

  constructor(private modalService: NgbModal, private appointmentService: AppointmentService, private utilService: UtilityService, private sharedData: SharedDataService) { }

  ngOnInit(): void {
    this.initHourSlots();
    this.selectedDate = new Date(Date.now());
    this.populateAppointments()
    // this.subscription = this.sharedData.currentMessage.subscribe(message => { 
    //   this.message = message;
    // })
  }

  isDisabled = (date: NgbDate, current: { month: number, year: number }) => date.month !== current.month;

  populateAppointments() {
    //Get list of appointments and iterate through the hourSlots marking them as "Booked"
    console.log(this.selectedDate.toISOString());
    this.appointmentService.getByDate(this.selectedDate.toISOString()).subscribe((result) => {
      if (result != null) {
        this.appointments = result;
        //let _this=this;
        //TODO Add more comment for implemented logic
        //Instead of storing the actual time for slots numbers have been used, this has helped in selecting a
        //range of slots easily in UI.
        //Example if slotFrom has value 92, 9 is base hour and 2 is the number of slot in an hour, so this translates to
        //9:30 AM assuming slot interval is 15mins.
        //Similarly 133 translates to 13 => 1pm , 3*15 => 45mins, 1:45pm would be shown in UI.
        for (var i = 0; i < this.appointments.length; i++) {
          let hs: HourSlot = this.hourSlots.filter(c => c.id == this.appointments[i].slotFrom)[0]
          hs.slotStatus = SlotSatus.Booked;
          hs.appointment = this.appointments[i];
          //to avoid floating point "add" operation issue like 9.1+0.1=9.299999999999999 
          let slotNo: number = this.calcNextSlotNo(this.appointments[i].slotFrom);
          while (slotNo <= this.appointments[i].slotTo) {
            let hs: HourSlot = this.hourSlots.filter(c => c.id == slotNo)[0]
            hs.slotStatus = SlotSatus.Booked;
            hs.appointment = this.appointments[i];
            slotNo = this.calcNextSlotNo(slotNo);
          }
        }
      }
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
    this.hourSlots = [];
    //represent in 24hr timing for easy mathematical calculations
    for (var h = 9; h <= 17; h++) {
      for (var s = 0; s < this.utilService.slotsPerHour; s++) {
        let timeText = this.getCellTimeText(h, s)
        this.hourSlots.push(new HourSlot(h * 10 + (s), SlotSatus.None, null, timeText))
      }
    }
  }

  getCellTimeText(h: number, s: number) {
    let time = "";
    let slotTime = (s * 15).toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false });
    if (h >= 12)
      time = (h == 12 ? h : (h - 12)) + ":" + slotTime + " PM"
    else
      time = (h) + ":" + slotTime + " AM"
    return time;
  }

  findNextBookedSlot(slotNo: number) {
    //set as last Slot 5:45pm (5=>17, 45/15(interval)=3)
    this.nextBookedSlot = 173;
    if (this.appointments !== undefined) {
      let bookings: Appointment[] = this.appointments?.filter(c => c.slotFrom > slotNo)
      if (bookings.length > 0) {
        if (bookings.length > 1) {
          bookings = bookings.sort((r1, r2) => r1.slotFrom > r2.slotFrom ? 1 : -1)
        }
        this.nextBookedSlot = bookings[0].slotFrom;
      }
    }
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
      slotTo: this.slotNoEnd
    };
    console.log(this.selectedSlots);

  }

  refreshAppointmentsList(initHourSlots: any) {
    if (initHourSlots)
      this.initHourSlots();
    this.populateAppointments();
    //Clear selected slot range
    this.slotNoStart = null;
    this.slotNoEnd = null;
  }

  onDateSelect($event) {
    this.slotNoStart = this.slotNoEnd = null;
    this.selectedDate = new Date($event.year, $event.month - 1, $event.day);
    //reset hourSlots and populate appointments of selected day.
    this.hourSlots.forEach(c => { c.slotStatus = SlotSatus.None; c.appointment = null })
    this.populateAppointments();
  }

  ngOnDestroy() {
    //this.subscription.unsubscribe();
  }

}
