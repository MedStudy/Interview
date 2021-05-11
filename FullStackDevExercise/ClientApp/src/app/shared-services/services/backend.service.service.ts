import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DOCUMENT, LocationStrategy } from '@angular/common';

@Injectable()
export class BackendService {
  constructor(private http: HttpClient,private readonly locationStrategy: LocationStrategy,
    @Inject(DOCUMENT) private readonly document: any) { }

    get<T>(url: string): Observable<T> {
      return this.http.get<T>(url);
    }

    post<TIn, TOut>(url: string, data: TIn): Observable<TOut> {
      return this.http.post<TOut>(url, data);
    }
  
    put<TIn, TOut>(url: string, data: TIn): Observable<TOut> {
      return this.http.put<TOut>(url, data);
    }

    delete<T>(url: string): Observable<T> {
      return this.http.delete<T>(url);
    }
    
    getApiUrl(...urlParts: any[]) {
      return `${this.document.location.origin}${this.locationStrategy.getBaseHref()}api/${urlParts.map(r=>r.toString()).filter(r=>!!r).map(url => url.startsWith('/') ? url.substring(1) : url).join('/')}`
    }
}
