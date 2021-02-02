import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Pet } from 'src/app/entities/pet.entity';

@Component({
  selector: 'app-pet-update-card',
  templateUrl: './pet-update-card.component.html',
  styleUrls: ['./pet-update-card.component.css']
})
export class PetUpdateCardComponent {

  constructor(
    public dialogRef: MatDialogRef<PetUpdateCardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Pet) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
