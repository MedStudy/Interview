import { Component, OnInit, Input } from '@angular/core';
import { Owner } from '../owner.model';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.css']
})
export class OwnerComponent implements OnInit {

  @Input() owner: Owner;
  constructor() { }

  ngOnInit(): void {
    
  }

}
