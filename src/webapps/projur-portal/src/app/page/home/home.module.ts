import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioService } from './services/usuario.service';
import { ListaComponent } from './components/lista/lista.component';
import { MaterialModule } from 'src/app/material.module';



@NgModule({
  declarations: [ListaComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    ListaComponent
  ],
  providers: [
    UsuarioService
  ]
})
export class HomeModule { }
