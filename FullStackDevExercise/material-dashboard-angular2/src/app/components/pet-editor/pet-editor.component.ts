import { Component, OnInit } from '@angular/core';

import { PetsService } from 'app/services';

@Component({
  selector: 'app-pet-editor',
  templateUrl: './pet-editor.component.html',
  styleUrls: ['./pet-editor.component.css']
})
export class PetEditorComponent implements OnInit {
  constructor(private petService: PetsService) {}

  ngOnInit(): void {}
}
