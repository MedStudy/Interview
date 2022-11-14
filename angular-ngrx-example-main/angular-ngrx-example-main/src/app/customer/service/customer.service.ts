import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Customer,Customerp } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  load(): Observable<Customerp> {
    return this.http.get<Customerp>('https://localhost:44312/api/customer/getcustomer');
  }
  loadSearch(searchQuery:any): Observable<Customer[]> {
    return this.http.get<Customer[]>('https://localhost:44312/api/customer/searcustomer?seach='+searchQuery);
  }

  search(searchQuery: any): Observable<Customer[]> {
    return this.loadSearch(searchQuery).pipe(
      map((list: Customer[]) => list.filter((value) => value.firstName.toLowerCase().indexOf(searchQuery.toLowerCase()) > -1))
    );
  }
}
