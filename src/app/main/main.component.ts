import { Component, OnInit } from '@angular/core';
import { api, IApi } from './api.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  providers: [api]  //GITHUB API SERVICE PROVIDER
})

export class MainComponent implements OnInit {
  txtUser:string = '';    //INIT USER INPUT
  public items:IApi;      //INIT API INTERFACE

  constructor(private _userService: api) { }

  ngOnInit() {}

  //GET USER PROVIDED NAME FOR SEARCH (COULD ENHANCE WITH VALIDATION)
  checkUser(event){
    this.getUser(this.txtUser);
  }

  //CALL GETUSER IN API.SERVICE AND PASS USE SUPPLIED NAME
  getUser(name:string){
    this._userService.getUsers(name)
    .subscribe(
      //LOAD LOCAL ITEMS USING INTERFACE WITH SEARCH RESULTS
      data => {this.items= data;},
      //SEND ERRORS TO CONSOLE (COULD BE ENHANCED FOR ERROR CONTROL)
      err => console.error(err)
    );
  }

}
