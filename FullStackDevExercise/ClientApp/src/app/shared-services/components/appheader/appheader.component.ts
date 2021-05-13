import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AppConstants } from '../../../appconstants'

@Component({
  selector: 'app-header',
  templateUrl: './appheader.component.html',
  styleUrls: ['./appheader.component.css']
})
export class AppHeaderComponent implements OnInit {
  @Output() public sidenavToggle = new EventEmitter();
  appName = AppConstants.appName;
  constructor() { }

  ngOnInit(): void {
  }
  
  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}