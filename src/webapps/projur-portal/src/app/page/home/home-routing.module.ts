import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditarUsuarioComponent } from './components/editar-usuario/editar-usuario.component';
import { ListaComponent } from './components/lista/lista.component';
import { NovoUsuarioComponent } from './components/novo-usuario/novo-usuario.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: 'home', component: HomeComponent,
    children: [
        { path: 'listar', component: ListaComponent },
        { path: 'novo', component: NovoUsuarioComponent },
        { path: 'editar/:id', component: EditarUsuarioComponent }
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
