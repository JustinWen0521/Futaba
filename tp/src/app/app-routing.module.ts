import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MccodelistComponent } from './mccodelist/mccodelist.component';


const routes: Routes = [
  { path: '', redirectTo: 'home' , pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'mccodelist', component: MccodelistComponent },
  { path: 'mccodelist/:code', component: MccodelistComponent },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
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
