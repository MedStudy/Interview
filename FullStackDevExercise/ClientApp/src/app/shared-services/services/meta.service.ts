import { Injectable } from '@angular/core';
import { AppConstants } from '../../appconstants';
import { Title } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})

@Injectable()
export class MetaService {
  constructor(private title: Title) { }

  setTitle(title: string) {
    this.title.setTitle(`${title} - ${AppConstants.appName}`);
  }
}