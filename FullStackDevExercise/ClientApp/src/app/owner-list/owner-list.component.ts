import { Component, OnInit } from '@angular/core';

import { OwnersService } from '../owners.service';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  constructor(private ownerService: OwnersService) {}

  ngOnInit(): void {}
}
