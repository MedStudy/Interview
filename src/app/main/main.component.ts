import { Component, OnInit, ViewChild} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {UserListComponent} from '../user/user-list.component';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  userForm: FormGroup;
  public userSearchTextBox = new FormControl;

  public user: string;
  @ViewChild (UserListComponent) userList: UserListComponent;
  constructor( public formBuilder: FormBuilder) {}

  ngOnInit() {
      this.buildForm();
      this.user = '';
  }
  onSubmit() {
    // console.log(this.user);
    // console.log(this.userForm.value.userSearchTextBox);
    this.userList.findUsers(this.user);
  }
  buildForm() {
    this.userForm = this.formBuilder.group({
      userSearchTextBox: this.formBuilder.control(null, [])
    });
  }
}
