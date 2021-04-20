import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Observable } from "rxjs";
import {HttpClient} from '@angular/common/http';

@Component({
  selector: "app-create-owner",
  templateUrl: "./create-owner.component.html",
  styleUrls: ["./create-owner.component.css"]
})
export class CreateOwnerComponent implements OnInit {
  createOwnerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) {
    this.createOwnerForm = formBuilder.group({
      first_name: ["", Validators.required],
      last_name: ["", Validators.required],
    });
  }

  ngOnInit() {}

  createOwner() {
    console.log("create button clicked");
    console.log("form value " + JSON.stringify(this.createOwnerForm.value));
    const req = this.createOwnerForm.value;

    this.registerOwner(req).subscribe(data => {
      if (data.toString() === 'Added Successfully') {
        window.alert("Added Successfully.Please refresh to see the owner added");
        
      } else {
        window.alert("fail");
      }
    });

  }

 
  public registerOwner(req: any){
    return this.httpClient.post('https://localhost:5001/api/owner', req);
  }
}
