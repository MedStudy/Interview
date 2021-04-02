export class appointmentModel {
  owner_id: number;
  pet_id: number;
  date: string;
  fromtime: number;
  totime: number;
  constructor() {
    this.owner_id = -1;
    this.pet_id = -1;
    this.date = new Date().toISOString().slice(0, 10);
    this.fromtime = -1;
    this.totime = -1;
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
