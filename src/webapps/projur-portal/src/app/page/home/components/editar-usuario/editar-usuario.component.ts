import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.scss']
})
export class EditarUsuarioComponent implements OnInit {

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
