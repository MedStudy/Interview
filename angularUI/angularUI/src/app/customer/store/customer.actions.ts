import { Update } from '@ngrx/entity';
import { createAction, props } from '@ngrx/store';

import { Customer } from '../models/customer';

export const requestLoadCustomers = createAction(
  '[Customer/API] Request Load Customers'
);

export const loadCustomers = createAction(
  '[Customer/API] Load Customers',
  props<{ Customers: Customer[] }>()
);

export const addCustomer = createAction(
  '[Customer/API] Add Customer',
  props<{ Customer: Customer }>()
);

export const updateCustomer = createAction(
  '[Customer/API] Update Customer',
  props<{ Customer: Update<Customer> }>()
);

export const deleteCustomer = createAction(
  '[Customer/API] Delete Customer',
  props<{ id: string }>()
);

export const searchCustomer = createAction(
  '[Customer/API] Search Customers',
  props<{ searchQuery: Customer }>()
);
