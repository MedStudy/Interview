import { Owner } from './owner.model'
import { Pet } from './pet.model'

export class Appointment
{
    constructor(){
        this.owner = new Owner()
        this.pet = new Pet()
        this.id= 0;
        this.appointmentDate = '';
        this.isComplete = false;
    }
    id: number;
    appointmentDate: string;
    isComplete: boolean;
    owner: Owner;
    pet: Pet;
}