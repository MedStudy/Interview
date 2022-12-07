import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Configurations } from 'src/environments/environment';
import { HttpService } from './http-service.service';


@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor(private http: HttpService) { }

  getStates(): Observable<any> {
    let urlPath: string = Configurations.Services.EmployeeService + "GetStates";
    return this.http.getWithoutParams(urlPath)
  }
}
