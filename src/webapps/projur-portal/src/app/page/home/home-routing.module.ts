import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaComponent } from './components/lista/lista.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: 'home', component: HomeComponent,
    children: [
        { path: 'listar', component: ListaComponent }
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
