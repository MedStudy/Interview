import { Component, OnInit, Input } from '@angular/core';
import { Pet } from '../pet.model';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.css']
})
export class PetComponent implements OnInit {

  @Input() pet: Pet;
  constructor() { }

  ngOnInit(): void {
  }

}
