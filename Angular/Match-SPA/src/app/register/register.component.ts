import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Input() valuesfromhome: any;
  @Output() cancelregister = new  EventEmitter();


  constructor(private authService: AuthService) {}

  ngOnInit() {}

  register() {
    this.authService.register(this.model).subscribe(() => {
         console.log('register successfully');
    }, error => {
      console.log(error);
    });
  }


  calcel() {
    console.log("calcel clicked");
    this.cancelregister.emit(false);
  }
}
