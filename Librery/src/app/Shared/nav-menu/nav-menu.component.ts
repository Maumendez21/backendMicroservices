import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/app/Auth/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  @Output() menuToggle = new EventEmitter<void>();
  show: boolean = false

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.show = this.authService.showMenu;
  }

  onMenuToggle(){
    this.menuToggle.emit();
  }

  logout(){
    this.authService.logout();
  }
}
