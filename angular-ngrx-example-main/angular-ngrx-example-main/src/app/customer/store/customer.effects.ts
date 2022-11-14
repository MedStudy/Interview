import { customers } from './customer.selectors';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { switchMap, map, debounceTime, delay } from 'rxjs/operators';

import { CustomerService } from '../service/customer.service';
import { loadCustomers, requestLoadCustomers, searchCustomer } from './customer.actions';

@Injectable()
export class CustomerEffects {

  constructor(private actions$: Actions, private service: CustomerService) {}

  loadCustomers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(requestLoadCustomers),
      switchMap(action =>
        this.service.load().pipe(
          delay(3000),
          map(data => loadCustomers({Customers: data.items}))
      ))
    )
  );

  searchCustomer$ = createEffect(() =>
      this.actions$.pipe(
        ofType(searchCustomer),
        switchMap(action => this.service.search(action.searchQuery)
        .pipe(
          delay(1000),
          map(data => loadCustomers({Customers: data}))
        ))
      )
  );
}
