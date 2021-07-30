import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioService } from './services/usuario.service';
import { ListaComponent } from './components/lista/lista.component';
import { MaterialModule } from 'src/app/material.module';
import { HomeRoutingModule } from './home-routing.module';
import { NovoUsuarioComponent } from './components/novo-usuario/novo-usuario.component';
import { EditarUsuarioComponent } from './components/editar-usuario/editar-usuario.component';


@NgModule({
  declarations: [
    ListaComponent, 
    NovoUsuarioComponent, 
    EditarUsuarioComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HomeRoutingModule
  ],
  exports: [
    ListaComponent
  ],
  providers: [
    UsuarioService
  ]
})
export class HomeModule { }
