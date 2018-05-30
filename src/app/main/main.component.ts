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

  constructor(private apidata : GithubapiService) {

   }

  ngOnInit() {

      this.getData();
  }

  updateUser(){
    this.getData()
  }

  getData(){
      this.apidata.getdata(this.userName)
      .subscribe(posts =>{
        console.log(posts)
        return this.githubdata=posts});
  }

}
