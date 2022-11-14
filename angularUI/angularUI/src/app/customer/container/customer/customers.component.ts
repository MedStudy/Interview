import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromCartActions from '../../../header/store/header.actions';
import * as fromActions from '../../store/customer.actions';
import * as fromStore from '../../store/customer.reducer';
import * as fromSelector from '../../store/customer.selectors';
import { Customer } from '../../models/customer';

@Component({
  selector: 'app-Customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
  
})
export class CustomersComponent implements OnInit {
  displayedColumns: string[] = ['ID', 'FirstName', 'LastName', 'Year'];
  filterCustomer:Customer={id:1,firstName:"",lastName:"",year:0 };
  isLoading$: Observable<boolean>
  error$: Observable<string | null>;
  Customers$: Observable<Customer[]>;
 
  constructor(private store: Store<fromStore.CustomerState>) {
    this.store.dispatch(fromActions.requestLoadCustomers());
    this.Customers$ = this.store.select(fromSelector.customers);
    this.isLoading$ = this.store.select(fromSelector.isLoading);
    this.error$ = this.store.select(fromSelector.error);
   
    // this.store.select(state => state).subscribe(data => {
    //   console.log('data', data);
    // });
  }

  ngOnInit(): void { }

  addCustomerCart(Customer: Customer): void {
    this.store.dispatch(fromCartActions.addToCart());
  }
  applyFilter() {
        this.store.dispatch(fromActions.searchCustomer({ searchQuery: this.filterCustomer }));
  }

}
