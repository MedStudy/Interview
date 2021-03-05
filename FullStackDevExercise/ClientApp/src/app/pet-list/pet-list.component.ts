import { Component, OnInit } from '@angular/core';

import { PetsService } from '../pets.service';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent implements OnInit {
  constructor(private petService: PetsService) {}

  ngOnInit(): void {}
}
