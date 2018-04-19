import { Component, OnInit, NgModule } from '@angular/core';
import { Http, Response } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { HeaderComponent} from '../header/header.component';
import 'rxjs/add/operator/map';

import {GitHubService} from '../service/github.service';
  

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  providers: [GitHubService]
})
export class MainComponent implements OnInit {
  title = 'profile search!';
  userName: string = "";
  data: any = {};
  userData: any = {};
  totalCount;

  first: number = 1;
  last: number = 10;

  //inject GitHubService 
  constructor(private gitService: GitHubService){
  }
  ngOnInit(){
    
  }

  // intialize counters, update search string for api query and pull the data from the api 
  onSearch(){
    this.first = 1;
    this.last = 10;
    this.gitService.pageNum = 1;
    this.gitService.updateUserName(this.userName);
    this.getData(); 
  }

  //pull data from the api through GitHubService service
  getData(){
    this.gitService.getData().subscribe(user => {
      this.data = user;
      this.totalCount = this.data.total_count;
      this.gitService.getTotalCount(this.data.total_count);
      
    //console.log(this.data); //TODO: REMOVE 
    }, err => console.log("Error: " + err)); 
  }

  // set visual start number and decrement pagenum on api query in GitHub Service
  onPrevPage(){
    if(this.first > 10 )
    {
    this.gitService.decPageNumber()
    this.getData();
      this.first -=10;
      this.last -=10;
    }else{
      //TODO: disable prev button
    }

  // opposite of above method
  }
  onNextPage(){
    // console.log(this.totalCount) //TODO: REMOVE
    if(this.last < this.totalCount){
    this.gitService.incPageNumber();
    this.getData()
    this.first +=10;
    this.last +=10;
    }else{
      //TODO: disable next button
    }
  }

  


}
