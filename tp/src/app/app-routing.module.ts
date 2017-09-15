import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Page1Component } from './page1/page1.component';
import { MccodelistComponent } from './mccodelist/mccodelist.component';


const routes: Routes = [
  { path: '', redirectTo: 'page1' , pathMatch: 'full' },
  { path: 'page1', component: Page1Component },
  { path: 'mccodelist', component: MccodelistComponent },
  { path: 'mccodelist/:code', component: MccodelistComponent },
  { path: '**', redirectTo: '/page1', pathMatch: 'full' }
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
