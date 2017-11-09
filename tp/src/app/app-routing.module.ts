import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MccodelistComponent } from './mccodelist/mccodelist.component';
import { LoginGuard } from './login.guard';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: '', redirectTo: 'Login' , pathMatch: 'full' },
  { path: 'Login', component: LoginComponent },
  { path: 'home', component: HomeComponent,canActivate:[LoginGuard]},
  { path: 'mccodelist', component: MccodelistComponent , canActivate:[LoginGuard]},
  { path: 'mccodelist/:code', component: MccodelistComponent, canActivate:[LoginGuard] },
  { path: '**', redirectTo: '/Login', pathMatch: 'full' }
];

@NgModule({
imports: [RouterModule.forRoot(routes, {
  enableTracing: false,
  useHash: true
}
)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
