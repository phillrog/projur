import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

import { catchError, map } from "rxjs/operators";
import { Usuario } from '../models/usuario.model';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<Usuario[]> {
    return this.http
        .get<Usuario[]>(this.apiUrl + "Usuario")
        .pipe(catchError(this.serviceError));
  }

  novoUsuario(usuario: Usuario): Observable<any> {
    return this.http
        .post(this.apiUrl + "Usuario", usuario)
        .pipe(map(this.resposta),catchError(this.serviceError));
  }  

  alterarUsuario(usuario: Usuario): Observable<any> {
    return this.http
        .put(this.apiUrl + "Usuario", usuario)
        .pipe(map(this.resposta),catchError(this.serviceError));
  }  

  obterPorId(id: string): Observable<Usuario> {
    return this.http
        .get<Usuario>(this.apiUrl + "Usuario/" + id  )
        .pipe(catchError(this.serviceError));
  }

  removerUsuario(id: string): Observable<Usuario> {
    return this.http
        .delete(this.apiUrl + "Usuario/" + id)
        .pipe(
            map(this.resposta),
            catchError(this.serviceError));
  }  

  resposta(response: any): any {
    return response || {};
  }

  serviceError(response: Response | any) {
    let customError: string[] = [];
    
    if (response instanceof HttpErrorResponse) {

        if (response.statusText === "Unknown Error") {
            customError.push("Ocorreu um erro desconhecido");
            response.error.errors = customError;
        }
    }
     
    console.error(response);
    return new Observable<any>(r => {
      r.error(response.error.errors);      
    });
  }
}
