import { Pet } from "./pet.model";

export class Owner {
    constructor(public id: number = null, public firstName: string = null, public lastName:string = null, public pets: Pet[] = null) { }
}
