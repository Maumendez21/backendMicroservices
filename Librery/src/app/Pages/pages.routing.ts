import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { PagesComponent } from './pages.component';
import { BookActionComponent } from './Book/book-action/book-action.component';
import { BookComponent } from './Book/book.component';
import { AutorComponent } from './autor/autor.component';
import { AutorActionComponent } from './autor/autor-action/autor-action.component';
import { LoginComponent } from '../Auth/login/login.component';
import { RegisterComponent } from '../Auth/register/register.component';
import { AuthGuard } from '../Guards/auth.guard';



const routes: Routes = [

    {
        path: 'books',
        component: PagesComponent,
        // canActivate: [AuthGuard],
        children: [
            {path: '', component: BookComponent},
            {path: ':id', component: BookActionComponent}
        ]
    },
    {
        path: 'authors',
        component: PagesComponent,
        // canActivate: [AuthGuard],
        children: [
            {path: '', component: AutorComponent},
            {path: ':id', component: AutorActionComponent}
        ]
    },
    {
        path: 'login',
        component: PagesComponent,
        children: [
            {path: '', component: LoginComponent}
        ]
    },
    {
        path: 'register',
        component: PagesComponent,
        children: [
            {path: '', component: RegisterComponent}
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule {}
