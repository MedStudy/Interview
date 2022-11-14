export class Customer {
  id!: number;
  firstName!: string;
  lastName!: string;
  year!: number;

}

export interface CustomerWithPaging {
  items:Customer[]
}
export interface Customerp{
  customers:Customer[]
}


