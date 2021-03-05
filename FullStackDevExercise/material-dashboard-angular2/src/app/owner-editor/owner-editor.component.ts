import { Component, OnInit } from '@angular/core';

import { OwnersService } from '../owners.service';

@Component({
  selector: 'app-owner-editor',
  templateUrl: './owner-editor.component.html',
  styleUrls: ['./owner-editor.component.css']
})
export class OwnerEditorComponent implements OnInit {
  constructor(private ownerService: OwnersService) {}

  ngOnInit(): void {}
}
