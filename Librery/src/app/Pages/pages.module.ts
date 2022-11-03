import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookComponent } from './Book/book.component';
import { BookActionComponent } from './Book/book-action/book-action.component';
import { AutorComponent } from './autor/autor.component';
import { AutorActionComponent } from './autor/autor-action/autor-action.component';
import { PagesComponent } from './pages.component';
import { RouterModule } from '@angular/router';

import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MaterialModule } from '../material.module';
import { LoginComponent } from '../Auth/login/login.component';
import { RegisterComponent } from '../Auth/register/register.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../Shared/shared.module';

@NgModule({
  declarations: [

    BookComponent,
    BookActionComponent,
    AutorComponent,
    AutorActionComponent,
    PagesComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule
  ]
})
export class PagesModule { }
