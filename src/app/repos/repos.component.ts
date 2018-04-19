import { Component, OnInit, Input } from '@angular/core';
import { GitHubService } from '../service/github.service';

@Component({
  selector: 'app-repos',
  templateUrl: './repos.component.html',
  styleUrls: ['./repos.component.scss']
})
export class ReposComponent implements OnInit {
  repos: any = [];
  @Input() user: string; // imput decorator to allow passing username data from user detail component
  
  //inject GitHub Service
  constructor(private gitService: GitHubService) { }

  ngOnInit() {
    // when compnent is initialized subscribe  and load data 
    this.getRepo(this.user)
  }

  //subscrive to the promise
  getRepo(name: string){
    this.gitService.getRepoInfo(name).subscribe( data => {
      this.repos = data;
      console.log( data)  // TODO: REMOVE 
    }, err => console.log(err))
  }

}
