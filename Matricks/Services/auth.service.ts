import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {
  baseURL = "http://localhost:52610/"

  constructor(private http: HttpClient) { }



  register(user) {

    this.http.post(this.baseURL + "/api/auth/register", user )

  }

}
