import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class AsignacionUsuarioService {

	constructor(private http: HttpClient) { }

	listarOrganismo() {
		const href = "AsignacionUsuario/listarOrganismo";
		return this.http.get(href);
	}


	listarPerfilOrganismo(ipInput: any) {
		const href = "AsignacionUsuario/listarPerfilOrganismo";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	listarAsignacionUsuario(ipInput: any) {
		const href = "AsignacionUsuario/listarAsignacionUsuario";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	listarUsuarioPerfil(ipInput: any) {
		const href = "AsignacionUsuario/listarUsuarioPerfil";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	insertarAsignacionUsuario(ipInput: any) {
		const href = "AsignacionUsuario/insertarAsignacionUsuario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	anularAsignacionUsuario(ipInput: any) {
		const href = "AsignacionUsuario/anularAsignacionUsuario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


}
