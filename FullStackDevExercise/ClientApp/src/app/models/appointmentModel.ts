export class appointmentModel {
  id:number;
  owner_id: number;
  pet_id: number;
  date: string;
  fromtime: number;
  totime: number;
  constructor() {
    this.id=0;
    this.owner_id = 0;
    this.pet_id = 0;
    this.date = new Date().toISOString().slice(0, 10);
    this.fromtime = 0;
    this.totime = 0;
  }
}

export class appointmentListModel extends appointmentModel {
  owner_name: string;
  pet_name: string;
  constructor() {
    super();
    this.owner_name = '';
    this.pet_name = '';
  }
}
