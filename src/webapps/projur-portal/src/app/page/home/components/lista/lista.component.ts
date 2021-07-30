import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../services/usuario.service';
import {MatPaginator} from '@angular/material/paginator';
import { Router } from '@angular/router';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) 
  sort!: MatSort;

  displayedColumns: string[] = ['id', 'nome', 'sobreNome', 'email', 'dataNascimento', 'escolaridadeDesc', 'editar', 'deletar'];
  dataSource = new MatTableDataSource<Usuario>([]);

  public usuarios: Usuario[] = [];
  errorMessage: string = '';

  constructor(private usuarioService: UsuarioService,
    private router: Router,) { }

  ngOnInit(): void {
    this.usuarioService.obterTodos()
      .subscribe(
        usuarios => {
          this.usuarios = usuarios
          this.dataSource = new MatTableDataSource<Usuario>(this.usuarios);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        },
        error => this.errorMessage);
  }

  removerUsuario(usuario: Usuario) {
    this.usuarioService.removerUsuario(usuario.id).subscribe(
      sucesso => {

      },
      falha => {}
    )

    window.location.reload();
  }

}
