import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

import { catchError, map } from "rxjs/operators";
import { Usuario } from '../models/usuario.model';

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

  serviceError(response: Response | any) {
    let customError: string[] = [];

    if (response instanceof HttpErrorResponse) {

        if (response.statusText === "Unknown Error") {
            customError.push("Ocorreu um erro desconhecido");
            response.error.errors = customError;
        }
    }

    console.error(response);
    return throwError(response);
  }
}
