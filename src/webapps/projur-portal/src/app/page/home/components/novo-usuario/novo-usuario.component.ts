import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-novo-usuario',
  templateUrl: './novo-usuario.component.html',
  styleUrls: ['./novo-usuario.component.scss']
})
export class NovoUsuarioComponent implements OnInit {
  submitted = false;

  escolaridade = [
    { id: '0', descricao: 'Infantil'},
    { id: '1', descricao: 'Fundamental'},
    { id: '2', descricao: 'Medio'},
    { id: '3', descricao: 'Superior'}
  ];

  form!: FormGroup;

  constructor(public fb: FormBuilder, 
    private usuarioService: UsuarioService,
    private router: Router,
    private toastr: ToastrService) { 
    this.reactiveForm();
  }

  ngOnInit(): void {
    
  }

  reactiveForm() {
    this.form = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      email: ['', Validators.required],
      dataNascimento: ['', Validators.required],      
      escolaridade: []
    })
  }

  compareItems(i1: any, i2: any) {
    return i1 && i2 && i1.id===i2.id;
  }

  submit() {
    this.submitted = true;
    if (!this.form.valid) return;
    
    let usuario: any = {
      escolaridadeDesc: '',
      nome: this.form.value.nome,
      sobreNome: this.form.value.sobrenome,
      email: this.form.value.email,
      dataNascimento: this.form.value.dataNascimento,
      escolaridade: Number(this.form.value.escolaridade.id)
    };

    this.usuarioService.novoUsuario(usuario)
        .subscribe(sucesso => {
           this.toastr.success('Usuário cadastrado com sucesso', 'Atenção');
          },
    falha => {
      this.toastr.error(falha.Mensagens.join('/r/n'), 'Atenção');
    });

    this.router.navigate(["/"]);
  }
}
