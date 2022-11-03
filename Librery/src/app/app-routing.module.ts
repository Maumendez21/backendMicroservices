import { NgModule, ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';
import { PagesRoutingModule } from './Pages/pages.routing';

const routes: Routes = [
  { path: '', redirectTo: '/books', pathMatch: 'full'},
  { path: '**', component: NoPageFoundComponent},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    PagesRoutingModule,
    // AuthRoutingModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
