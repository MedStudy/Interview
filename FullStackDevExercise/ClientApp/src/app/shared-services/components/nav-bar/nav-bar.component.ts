import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { SharedServicesModule } from '../../shared-services.module';
import { AppConstants } from '../../../appconstants';

@Component({
  selector: 'shared-service-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit  {
  @Output() sidenavClose = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }

  appName = AppConstants.appName;

}
