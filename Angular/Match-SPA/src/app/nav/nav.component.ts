import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login() {
    console.log(this.model);
    this.authService.login(this.model).subscribe(next => {
      console.log('login successfully');
    }, erroor => {
      console.log('error occured');
    });
  }

  loggedin() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  loggedout() {
    localStorage.removeItem('token');
  }

}
