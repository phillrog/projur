import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../services/usuario.service';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  displayedColumns: string[] = ['nome', 'sobreNome', 'email', 'dataNascimento', 'escolaridadeDesc', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<Usuario>([]);

  public usuarios: Usuario[] = [];
  errorMessage: string = '';

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.usuarioService.obterTodos()
      .subscribe(
        usuarios => {
          this.usuarios = usuarios
          this.dataSource = new MatTableDataSource<Usuario>(this.usuarios);
          this.dataSource.paginator = this.paginator;
        },
        error => this.errorMessage);
  }

}
