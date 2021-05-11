import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: "home", redirectTo: "appointments" },
  { path: "appointments", loadChildren: () => import('./appointments/appointments.module').then(m => m.AppointmentsModule) },
  { path: "owners", loadChildren: () => import('./owners/owners.module').then(m => m.OwnersModule) },
  { path: "pets", loadChildren: () => import('./pets/pets.module').then(m => m.PetsModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
