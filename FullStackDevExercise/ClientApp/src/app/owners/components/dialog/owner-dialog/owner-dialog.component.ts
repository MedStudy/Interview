import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Owner } from 'src/app/shared-services/models/owner';
import { OwnersService } from '../../../services/owners.service';

@Component({
  selector: 'app-owner-dialog',
  templateUrl: './owner-dialog.component.html',
  styleUrls: ['./owner-dialog.component.css']
})
export class OwnerDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<OwnerDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private ownerService : OwnersService) { }

  owner = this.data.owner;
  action = this.data.action;

  ngOnInit(): void {
  }

  executeAction() : void{
    if(this.action == 'Create'){
    this.ownerService.createOwner(this.owner).toPromise().then(data=>
      this.dialogRef.close(data));
    }
    else{
      this.ownerService.updateOwner(this.owner).toPromise().then(data=>
        this.dialogRef.close(data));
    }
  }

}
