import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {
  slotsPerHourArray: number[] = [0, 1, 2, 3];
  private _slotsPerHour = this.slotsPerHourArray.length;
  public get slotsPerHour() {
    return this._slotsPerHour;
  }
  constructor() { }


  getTimeText(slotNo: number, outCellEndTime: boolean = false) {
    let slotHour = Math.floor(slotNo / 10);
    let slotMinutesIdx = slotNo - (slotHour * 10);
    if (outCellEndTime) {
      if (slotMinutesIdx == this._slotsPerHour-1) {
        slotMinutesIdx=0;
        slotHour++;
      }
      else
        slotMinutesIdx++;
    }
    let time = "";
    let slotMinutes = (slotMinutesIdx * 15).toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false });
    if (slotHour > 12)
      time = (slotHour - 12) + ":" + slotMinutes + " PM"
    else
      time = (slotHour) + ":" + slotMinutes + " AM"
    return time;
  }
}
