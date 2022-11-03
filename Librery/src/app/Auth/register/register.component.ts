import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { User } from '../User.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  public registerForm  = this.fb.group({
    name: ['', [Validators.required]],
    lastname: ['', [Validators.required]],
    username: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['',[ Validators.required, Validators.minLength(8)]],
  });

  ngOnInit(): void {
   
  }

  register(){
    
    let usrRegiste: User = {
      name: this.registerForm.value.name || '',
      lastname: this.registerForm.value.lastname|| '',
      email: this.registerForm.value.email || '',
      username: this.registerForm.value.username || '',
      password: this.registerForm.value.password || '',
      userId: '',
      token: ''
    }


    this.authService.registerUser(usrRegiste);
  }

}
