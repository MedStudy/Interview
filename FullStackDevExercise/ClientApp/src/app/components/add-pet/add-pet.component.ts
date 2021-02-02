import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Owner } from 'src/app/entities/owner.entity';
import { OwnerService } from 'src/app/services/owner.service';
import { PetService } from 'src/app/services/pet.service';
import { Pet } from 'src/app/entities/pet.entity';

@Component({
  selector: 'app-add-pet',
  templateUrl: './add-pet.component.html',
  styleUrls: ['./add-pet.component.css']
})
export class AddPetComponent implements OnInit {

  activeForm = this.formBuilder1.group({
    id: {value: 0, disabled: true},
    ownerId: ['', [Validators.required]],
    type: ['', [Validators.required]],
    name: ['', [Validators.required]],
    age: [0, [Validators.required]], 
  })

  constructor(private formBuilder1: FormBuilder,
    private petService: PetService,
    private ownerService: OwnerService,
    public dialogRef: MatDialogRef<AddPetComponent>)
     { }
  
  ngOnInit(): void {
  }

  onCancel(){
    this.dialogRef.close();
  }

  async addPet(){
    var obj: Pet= {
      id: this.activeForm.get('id').value,
      owner_Id: this.activeForm.get('ownerId').value,
      name: this.activeForm.get('name').value,
      type: this.activeForm.get('type').value,
      age: this.activeForm.get('age').value,
    };
    var pet = await this.petService.addPet(obj)
    .then(res => {
      alert(`Pet added successfully.`)
      this.dialogRef.close(res);
    })
    .catch(error => {
      alert(error);
    }
    )
  }
}