export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  year?: string;
  image: number;
}

export interface Customerp {
  items:Customer[]
}


