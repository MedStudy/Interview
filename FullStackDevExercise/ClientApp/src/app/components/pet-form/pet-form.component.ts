import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-pet-form',
  templateUrl: './pet-form.component.html',
  styleUrls: ['./pet-form.component.css']
})
export class PetFormComponent implements OnInit {

  createPetForm: FormGroup;
  dataSource: any;
  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) {
    this.createPetForm = formBuilder.group({
      name: ['', Validators.required],
      type: ['', Validators.required],
      age : ['', Validators.required],
      owner_id : ['', Validators.required],
    });
  }

  ngOnInit() {this.viewPet(); }

  createPet() {
    console.log('create button clicked');
    console.log('form value ' + JSON.stringify(this.createPetForm.value));
    const req = this.createPetForm.value;

    this.registerPet(req).subscribe(data => {
      if (data.toString() === 'Added Successfully') {
        window.alert('success');
      } else {
        window.alert('fail');
      }
    });
  }

 
  public registerPet(req: any){
    return this.httpClient.post('https://localhost:5001/api/pet', req);
  }

  deletePet(id) {
    console.log('delete pet ' + id);

    this.httpClient.delete('https://localhost:5001/api/pet/' + id, {observe: 'response'}).subscribe(data => {
      if (data['status'] === 200) {
        window.alert("Deleted " + id);
        this.ngOnInit();
      } else {
        window.alert("fail"); }});
  }

  viewPet() {

    this.getPet().subscribe(data => {
      if (data['status'] === 200) {
        this.dataSource = data["body"];
      } else {
        window.alert("fail");
      }
    });

  }
 
  public getPet(){
    return this.httpClient.get('https://localhost:5001/api/pet', {observe: 'response'});
  }

}

