import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Owner } from 'src/app/entities/owner.entity';
import { OwnerService } from 'src/app/services/owner.service';

@Component({
  selector: 'app-add-owner',
  templateUrl: './add-owner.component.html',
  styleUrls: ['./add-owner.component.css']
})
export class AddOwnerComponent implements OnInit {

  activeForm = this.formBuilder1.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
  })

  constructor(private formBuilder1: FormBuilder,
    private ownerService: OwnerService,
    public dialogRef: MatDialogRef<AddOwnerComponent>)
     { }
  
  ngOnInit(): void {
  }

  onCancel(){
    this.dialogRef.close();
  }

  async addOwner(){
    var obj: Owner= {
      first_Name: this.activeForm.get('firstName').value,
      last_Name: this.activeForm.get('lastName').value
  };
    var response = await this.ownerService.addOwner(obj);
    this.dialogRef.close(response);
  }
}