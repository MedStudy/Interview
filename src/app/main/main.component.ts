import { Component, OnInit } from '@angular/core';
import { GithubapiService } from '../services/githubapi.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

	 githubdata: any; 
   userName:string = '';
   isValid:boolean = false;

  constructor(private apidata : GithubapiService) {

   }

  ngOnInit() {
  }

  updateUser(){
    this.getData()
  }

  getData() {
    let regex = /^[a-zA-Z0-9_-]{3,}$/;
    if ( !regex.test(this.userName) ) {
      this.githubdata = [];
      this.isValid = true;  
      return;
    }
    this.isValid = true;
    this.apidata.getdata( this.userName )
    .subscribe(posts => {
        if ( posts.total_count > 0 ) {
          this.githubdata = posts
          this.isValid = false;
        } else {
          this.githubdata = [];
          this.isValid = true;
        }
      
      });
    }

}
