import { Component, OnInit, Input } from '@angular/core';
import { GitHubService} from '../service/github.service'

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit  {
  @Input() user: string;
  visible: boolean= false;
  message: string = "Show Repos";
  userData: any;
  constructor(private gitService: GitHubService) { }
  
  ngOnInit(){
    this.getUser(this.user);
  }
 
  // subscribe to the observable 
  getUser(name: string){
    this.gitService.getUserInfo(name).subscribe( data => {
      this.userData = data;
      //console.log(data)  // TODO: REMOVE 
    }, err => console.log(err))
  }
  // toggle to show and hide repo details 
  toggle(){
    this.visible = !this.visible;
    if(this.visible){
      this.message = "Hide Repos";
    }else{ this.message = "Show Repos"};
  }

}
