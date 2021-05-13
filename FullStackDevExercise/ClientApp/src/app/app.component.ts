import { Component,OnInit } from '@angular/core';
import {MetaService} from '../app/shared-services/services/meta.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  constructor(private metaService: MetaService) { }

  ngOnInit(): void {
    this.metaService.setTitle("Home");
  }

}
