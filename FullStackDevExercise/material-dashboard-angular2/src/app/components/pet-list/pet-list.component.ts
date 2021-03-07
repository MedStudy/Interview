import { Component, OnInit } from '@angular/core';

import { PetsService } from 'app/services';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent implements OnInit {
  constructor(private petService: PetsService) {}

  public pets: Array<any>;
  ngOnInit(): void {
    this.petService.getPets().subscribe(x => {
      this.pets = x;
    });
  }
}
