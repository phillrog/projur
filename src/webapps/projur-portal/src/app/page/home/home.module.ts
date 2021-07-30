import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioService } from './services/usuario.service';
import { ListaComponent } from './components/lista/lista.component';
import { MaterialModule } from 'src/app/material.module';
import { HomeRoutingModule } from './home-routing.module';



@NgModule({
  declarations: [ListaComponent],
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
