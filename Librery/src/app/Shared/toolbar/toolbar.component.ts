import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../../Auth/auth.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {


  @Output() menuToggle = new EventEmitter<void>();

  public show: boolean = false;
  userSubscription!: Subscription;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

    this.show = this.authService.showMenu

    this.userSubscription = this.authService.securityChange.subscribe(show => {
      
      this.show = show;
    })
  }

  ngOnDestroy(): void {
    //Called once, before the instance is destroyed.
    //Add 'implements OnDestroy' to the class.
    this.userSubscription.unsubscribe();

  }

  ngOnChanges(): void {
    //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
    //Add '${implements OnChanges}' to the class.
    // this.userSubscription = this.authService.securityChange.subscribe(show => {
    //   console.log(show);
      
    //   this.show = show;
    // })
  }

  logout(){
    this.authService.logout();
  }

  onMenuToggle(){
    this.menuToggle.emit();
  }
}
