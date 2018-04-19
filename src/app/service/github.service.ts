import {Injectable} from '@angular/core';
import { Http, Headers, Response} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class GitHubService{
    private username = 'NickChlam';
    private client_id = "2070f2b76ebb617c9b74";
    private client_secret = "c93035cfe400474a53a2d64146cd7b42d5285a25";
    per_page = "per_page=10";
    page: string = "page=";
    pageNum = 1;
    url = "";
    totalCount;
    data: {};
    constructor(private http:Http){

    }

    //TODO: refactor code to have one unifed API function that takes url as parameter



    // make http request return an observable object then map the data and parse the response as JSON
    getData(){
        let url = "https://api.github.com/search/users?q=" + this.username + "&" + this.per_page + "&" + this.page + this.pageNum + "&?client_id=" + this.client_id  + "&client_secret=" + this.client_secret;
      // console.log("In Get Data " + url); // TODO: Remove 
        return this.http.get(url)
        .map((res: Response) => res.json()
        ,err => console.log(err))
    }

    //same as above
    getUserInfo(gitName: string){
        this.url = "https://api.github.com/users/"+ gitName + "?client_id=" + this.client_id + "&client_secret=" + this.client_secret;
        return this.http.get(this.url)
        .map((res: Response) => res.json(), err => console.log(" You have : " + err))
    }
    //same as above
    getRepoInfo(repoName: string){
        this.url = "https://api.github.com/users/" + repoName + '/repos?per_page=5&sort=stars&order=desc&client_id=' + this.client_id + '&client_secret=' + this.client_secret
        return this.http.get(this.url)
        .map((res: Response) => res.json(), 
            err => console.log(err))
    }

    //setter for UserName 
    updateUserName(username: string){
        this.username= username;
    }
    // increments page number called from main component
    incPageNumber(){
        if(this.pageNum < (this.totalCount / 10)){
            this.pageNum++;
        }else{this.pageNum = this.pageNum}
        
    }
    // decrements page number called from main component 
    decPageNumber(){
        if(this.pageNum > 1){
            this.pageNum--;
        }else {this.pageNum = this.pageNum}
        
    }
    // setter for total count - TODO: rename bad name
    getTotalCount(total){
        this.totalCount = total;
    }
    //setter for pagenum
    setPage(page){
        this.pageNum = page;
    }
    //getter for pagenum
    getPage(){
        return this.pageNum;
    }



}
