import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';

import { Customer } from '../models/customer';
import * as CustomerActions from './customer.actions';

export const CustomersFeatureKey = 'Customers';

export interface CustomerState extends EntityState<Customer> {
  isLoading: boolean;
  error: string | null;
}

export const adapter: EntityAdapter<Customer> = createEntityAdapter<Customer>();

export const initialState: CustomerState = adapter.getInitialState({
  isLoading: true,
  error: null
});

export const reducer = createReducer(
  initialState,
  on(CustomerActions.addCustomer,
    (state, action) => adapter.addOne(action.Customer, state)
  ),
  on(CustomerActions.updateCustomer,
    (state, action) => adapter.updateOne(action.Customer, state)
  ),
  on(CustomerActions.deleteCustomer,
    (state, action) => adapter.removeOne(action.id, state)
  ),
  on(CustomerActions.loadCustomers,
    (state, action) => adapter.setAll(action.Customers, {
        ...state,
        isLoading: false
    })
  ),
  on(CustomerActions.requestLoadCustomers,
    (state, action) => adapter.setAll([], {
      ...state,
      isLoading: true
  })
  )
);

export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapter.getSelectors();

export const selectIsLoading = (state: CustomerState) => state.isLoading;
export const selectError = (state: CustomerState) => state.error;
