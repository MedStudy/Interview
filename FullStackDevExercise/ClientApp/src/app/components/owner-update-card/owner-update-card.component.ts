import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Owner } from 'src/app/entities/owner.entity';

@Component({
  selector: 'app-owner-update-card',
  templateUrl: './owner-update-card.component.html',
  styleUrls: ['./owner-update-card.component.css']
})
export class OwnerUpdateCardComponent {

  constructor(
    public dialogRef: MatDialogRef<OwnerUpdateCardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Owner) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
