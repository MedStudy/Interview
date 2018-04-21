import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './user.service';
import { User } from './models/user.model';
import {UserSearchResult } from './models/user-search-result.model';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list-component.html',
    styleUrls: ['./user-list-component.scss']
})

export class UserListComponent implements OnInit {

    @Input('searchUser')
    public searchUser = '';

    public searchResult: UserSearchResult = new UserSearchResult();
    public pageOfUsers: User[];
    public isLoading: boolean;
    public isExecuted = false;
    constructor(private userService: UserService) { }

    ngOnInit() {
        this.isLoading = false;
        this.searchResult.total_count = 0;
    }

    async findUsers(searchParam: string) {
            this.isLoading = true;
            this.searchResult = await this.userService.find(searchParam);
            this.pageOfUsers =  this.searchResult.items.slice(0, 10);
            this.isLoading = false;
            this.isExecuted = true;
    }
}
