import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Configurations } from 'src/environments/environment';
import { HttpService } from '../common/http-service.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpService) { }

  getUsersList(inputObj:any): Observable<any>{
    let urlPath: string = Configurations.Services.EmployeeService + "SearchEmployee";
    return this.http.postHttpMethod(urlPath,inputObj);
  }
}
