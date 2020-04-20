import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + "identity/login";
  private registerPath = environment.apiUrl + "identity/register";
  
  constructor(private http: HttpClient) { }

  saveToken(data: any): Observable<any>{
    return this.http.post(this.registerPath, data);
  }

  register(data:any){
    return this.http.post(this.registerPath, data)
  }
}
