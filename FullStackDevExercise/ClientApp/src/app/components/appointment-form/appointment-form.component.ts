import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-appointment-form',
  templateUrl: './appointment-form.component.html',
  styleUrls: ['./appointment-form.component.css']
})
export class AppointmentFormComponent implements OnInit {
  createAppointmentForm: FormGroup;
  dataSource: any;
  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient

  ) {
    this.createAppointmentForm = formBuilder.group({
      owner_name: ["", Validators.required],
      pet_name: ["", Validators.required],
      time: ["", Validators.required],
      date : ["", [Validators.required]]

    });
  }

  ngOnInit() {this.viewAppointment();
  }

  createAppointment() {
    console.log("create button clicked");
    console.log("form value " + JSON.stringify(this.createAppointmentForm.value));
    const req = this.createAppointmentForm.value;

    this.registerAppointment(req).subscribe(data => {
      if (data.toString() === 'Added Successfully') {
        window.alert("success");
      } else {
        window.alert("fail");
      }
    });

  }

 
  public registerAppointment(req: any){
    return this.httpClient.post('https://localhost:5001/api/appointment', req);
  }

  deleteAppointment(id) {

    this.httpClient.delete('https://localhost:5001/api/appointment/' + id, {observe: 'response'}).subscribe(data => {
      if (data['status'] === 200) {
        window.alert("Deleted " + id);
        this.ngOnInit();
      } else {
        window.alert("fail"); }});
  }

  viewAppointment() {

    this.getAppointment().subscribe(data => {
      if (data['status'] === 200) {
        this.dataSource = data["body"];
      } else {
        window.alert("fail");
      }
    });

  }
 
  public getAppointment(){
    return this.httpClient.get('https://localhost:5001/api/appointment', {observe: 'response'});
  }

}
