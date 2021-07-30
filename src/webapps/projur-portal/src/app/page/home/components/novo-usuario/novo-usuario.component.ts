import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-novo-usuario',
  templateUrl: './novo-usuario.component.html',
  styleUrls: ['./novo-usuario.component.scss']
})
export class NovoUsuarioComponent implements OnInit {

  escolaridade = [
    { id: '0', descricao: 'Infantil'},
    { id: '1', descricao: 'Fundamental'},
    { id: '2', descricao: 'Medio'},
    { id: '3', descricao: 'Superior'}
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
