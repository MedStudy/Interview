import { Owner } from "./owner.model";
import { Pet } from "./pet.model";

export class Appointment {
  constructor(public id: number = 0) { }
  petId: number | null;
  appointmentDate: any | null; //TODO
  slotFrom: number;
  slotTo: number;
  notes?: string;

  pet?: Pet | null; //TODO 
  owner?: Owner | null; //TODO
}
