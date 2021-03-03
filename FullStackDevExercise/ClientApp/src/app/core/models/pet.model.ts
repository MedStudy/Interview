type petType = PetType;

export class Pet {
    id: number;
    ownerId: number;
    type: petType; //TODO
    name: string;
    age: number;
}

export enum PetType {
    Dog = "Dog",
    Cat = "Cat",
    Rabbit = "Rabbit",
    Other = "Other"
}


