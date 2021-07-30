import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from '../../services/usuario.service';

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

  form!: FormGroup;

  id: any;

  constructor(public fb: FormBuilder, 
    private usuarioService: UsuarioService,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private toastr: ToastrService) {
      this.reactiveForm();     
  }

  ngOnInit(): void {
    this.activeRoute.queryParams
      .subscribe(params => {
        this.id = this.activeRoute.snapshot.params['id']; 
        this.usuarioService.obterPorId(this.id).subscribe(response =>{
          this.form = this.fb.group({
            id:  new FormControl({ value: response.id, disabled: true }),
            nome: [response.nome, Validators.required],
            sobrenome: [response.sobreNome, Validators.required],
            email: [response.email, Validators.required],
            dataNascimento: [response.dataNascimento, Validators.required],            
            escolaridade: [this.escolaridade[response.escolaridade]]      
          });
        })              
      }
    );
  }

  reactiveForm() {
    this.form = this.fb.group({
      id:  new FormControl({ value: '', disabled: true }),
      nome: [],
      sobrenome: [],
      email: [],
      dataNascimento: [],      
      escolaridade: []
    })
  }

  compareItems(i1: any, i2: any) {
    return i1 && i2 && i1.id===i2.id;
  }

  submit() {
    if (!this.form.valid) return;
    
    let usuario: any = {
      id: this.form.controls.id.value,
      escolaridadeDesc: '',
      nome: this.form.value.nome,
      sobreNome: this.form.value.sobrenome,
      email: this.form.value.email,
      dataNascimento: this.form.value.dataNascimento,
      escolaridade: Number(this.form.value.escolaridade.id)
    };

    this.usuarioService.alterarUsuario(usuario)
        .subscribe(sucesso => {
            this.toastr.success('Usuário alterado com sucesso', 'Atenção');
          },
          falha => {});

    this.router.navigate(["/"]);
  }
}
