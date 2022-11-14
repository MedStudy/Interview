import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Customer,Customerp, CustomerWithPaging } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  load(): Observable<CustomerWithPaging> {
    return this.http.get<CustomerWithPaging>('https://localhost:44312/api/customer/getcustomer');
  }
  loadSearch(searchQuery:Customer): Observable<Customerp> {
    const params = new HttpParams().set("query",JSON.stringify(searchQuery));

    return this.http.get<Customerp>('https://localhost:44312/api/customer/SearchCustomer',{
      params: params
    });;
  }

  search(searchQuery: Customer): Observable<Customerp> {
    return this.loadSearch(searchQuery).pipe(
      map((list: Customerp) => list)
    );
  }
}
