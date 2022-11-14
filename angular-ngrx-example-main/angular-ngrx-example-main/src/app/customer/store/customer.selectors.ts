import { createFeatureSelector, createSelector } from '@ngrx/store';

import * as fromStore from './customer.reducer';

const CustomersSelector = createFeatureSelector<fromStore.CustomerState>(fromStore.CustomersFeatureKey);

export const isLoading = createSelector(CustomersSelector, fromStore.selectIsLoading);
export const customers = createSelector(CustomersSelector, fromStore.selectAll);
export const error = createSelector(CustomersSelector, fromStore.selectError);
