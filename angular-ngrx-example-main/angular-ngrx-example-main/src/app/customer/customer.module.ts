import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { CustomerEffects } from './store/customer.effects';

import { SharedModule } from './../shared/shared.module';
import { CustomersComponent } from './container/customer/customers.component';
import { CustomersRoutingModule } from './customer-routing.module';

import * as fromCustomer from './store/customer.reducer';

@NgModule({
  declarations: [CustomersComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    StoreModule.forFeature(fromCustomer.CustomersFeatureKey, fromCustomer.reducer),
    EffectsModule.forFeature([CustomerEffects]),
    SharedModule
  ]
})
export class CustomersModule { }
