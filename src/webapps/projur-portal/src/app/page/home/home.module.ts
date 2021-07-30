import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioService } from './services/usuario.service';
import { ListaComponent } from './components/lista/lista.component';
import { MaterialModule } from 'src/app/material.module';
import { HomeRoutingModule } from './home-routing.module';
import { NovoUsuarioComponent } from './components/novo-usuario/novo-usuario.component';
import { EditarUsuarioComponent } from './components/editar-usuario/editar-usuario.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    ListaComponent, 
    NovoUsuarioComponent, 
    EditarUsuarioComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HomeRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    })
  ],
  exports: [
    ListaComponent
  ],
  providers: [
    UsuarioService,
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }
  ]
})
export class HomeModule { }
