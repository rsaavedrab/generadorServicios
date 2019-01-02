import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class GestionPerfilService {

	constructor(private http: HttpClient) { }

	listarGestionPerfil(ipInput: any) {
		const href = "GestionPerfil/listarGestionPerfil";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	insertarGestionPerfil(ipInput: any) {
		const href = "GestionPerfil/insertarGestionPerfil";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	modificarGestionPerfil(ipInput: any) {
		const href = "GestionPerfil/modificarGestionPerfil";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.put(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	anularGestionPerfil(ipInput: any) {
		const href = "GestionPerfil/anularGestionPerfil";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	listarOrganismo() {
		const href = "GestionPerfil/listarOrganismo";
		return this.http.get(href);
	}


	listarPerfilOrganimo(ipInput: any) {
		const href = "GestionPerfil/listarPerfilOrganimo";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


}
