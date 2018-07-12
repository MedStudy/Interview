import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule, MatFormFieldModule, MatInputModule, MatIconModule, MatCardModule, MatListModule } from '@angular/material';

const MATERIAL_MODULES = [
  CommonModule,
  MatButtonModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatIconModule,
  MatCardModule,
  MatListModule
];

@NgModule({
  imports: MATERIAL_MODULES,
  exports: MATERIAL_MODULES
})
export class MyMaterialModule { }
