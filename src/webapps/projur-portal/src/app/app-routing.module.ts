import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './page/home/home.component';


const routes: Routes = [
  { path: 'home', 
    loadChildren: () => import('./page/home/home.module')
    .then(m => m.HomeModule)
  },  

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
