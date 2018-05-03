import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model = new User();

  constructor() { }

  ngOnInit() { }

  submit() {
    this.http.post(User) 
  }

}

class User {
  username: string;
  password: string;
}


