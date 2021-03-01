import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Appointment } from 'src/app/core/models/appointment.model';
import { HourSlot, SlotSatus } from 'src/app/core/models/hour-slot.model';

@Component({
  selector: 'app-slot-cell',
  templateUrl: './slot-cell.component.html',
  styleUrls: ['./slot-cell.component.css']
})
export class SlotCellComponent implements OnInit, OnChanges {
  @Input() hourSlot: HourSlot;
  @Input() slotId: number;
  @Output() notifySlotSelected = new EventEmitter<number>();

  slotAppointment: Appointment;
  slotStatus: string;
  disableCellClick: boolean;
  isSlotFromCell: boolean;
  isSlotToCell: boolean;
  constructor() { }

  ngOnInit(): void {
    if (this.hourSlot) {
      this.disableCellClick = this.hourSlot.slotStatus == SlotSatus.Booked;
      //this.isSlotFromCell = this.slotId==this.hourSlot.appointment?.slotFrom;
      //this.isSlotToCell = this.slotId==this.hourSlot.appointment?.slotTo;
    }
  }

  ngOnChanges(changes: any) {
    if(this.hourSlot)
    {
      //TODO revise null logic
      this.disableCellClick = this.hourSlot.slotStatus == SlotSatus.Booked;
      //this.isSlotFromCell = this.slotId==this.hourSlot.appointment?.slotFrom;
      //this.isSlotToCell = this.slotId==this.hourSlot.appointment?.slotTo;
    }
  }
}
