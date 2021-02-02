import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AdminComponent } from './components/admin/admin.component';
import { OwnerComponent } from './components/owner/owner.component';
import { PetComponent } from './components/pet/pet.component';
import { AppointmentComponent } from './components/appointment/appointment.component';

const routes: Routes = [
	{ path: '', component: OwnerComponent },
	{ path: 'owner', component: OwnerComponent},
	{ path: 'pet', component: PetComponent},
	{ path: 'appointment', component: AppointmentComponent},
	{ path: '**', redirectTo: '' }
	
];

export const routing = RouterModule.forRoot(routes);