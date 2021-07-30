import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'home', 
    loadChildren: () => import('./page/home/home.module')
    .then(m => m.HomeModule)
  },
  { path: '', redirectTo: 'home/listar', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
