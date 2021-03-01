import { Appointment } from "./appointment.model"

export class HourSlot {
    constructor(public id: number, public slotStatus:SlotSatus=SlotSatus.None, public appointment:Appointment, public timeText: string) { }
}

export enum SlotSatus {
    None = "none",
    Booking = "booking",
    Booked = "booked"
}
