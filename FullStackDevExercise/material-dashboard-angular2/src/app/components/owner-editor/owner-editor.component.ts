import { Component, OnInit, Output } from '@angular/core';

import { OwnersService } from 'app/services';
import { EventEmitter } from 'events';

@Component({
  selector: 'app-owner-editor',
  templateUrl: './owner-editor.component.html',
  styleUrls: ['./owner-editor.component.css']
})
export class OwnerEditorComponent implements OnInit {
  constructor(private ownerService: OwnersService) {}
  @Output()
  saved = new EventEmitter();
  ngOnInit(): void {}
}
