import { Component, OnInit } from '@angular/core';
import { DataServiceService } from '../data-service.service';
import { Pet } from '../pet.model';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent implements OnInit {

  constructor(private dataservice: DataServiceService) { }

  pets: Pet[] = [];
  ngOnInit(): void {
    this.getAppointments();
  }

  getAppointments(){
    this.dataservice.GetPets(0).subscribe((res: Pet[]) => {
      this.pets = res
    });
  }

}
