import { Component, OnInit } from '@angular/core';
import { GithubapiService } from '../services/githubapi.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

	 githubdata: any; 
   userName="";
    regex= /^[a-zA-Z]*$/;
    isValid:boolean =true;

  constructor(private apidata : GithubapiService) {

   }

  ngOnInit() {
  }

  updateUser(){
    this.getData()
  }

  getData(){

if(this.regex.test(this.userName)){
      this.isValid=true;
    this.apidata.getdata(this.userName)
      .subscribe(posts =>{
        return this.githubdata=posts});
    }  

    else{
          this.isValid=!this.isValid
      }
    }

}
