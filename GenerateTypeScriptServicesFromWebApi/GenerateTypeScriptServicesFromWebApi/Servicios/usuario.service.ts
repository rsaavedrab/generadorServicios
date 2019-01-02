import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class UsuarioService {

	constructor(private http: HttpClient) { }

	listarUsuario(ipInput: any) {
		const href = "Usuario/listarUsuario";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	listarUsuarioAsignado(ipInput: any) {
		const href = "Usuario/listarUsuarioAsignado";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	validarUsuario(strUsuario: string, strContrasenia: string) {
		const href = "Usuario/validarUsuario";
		return this.http.get(href + "?strUsuario=" + strUsuario + "&strContrasenia=" + strContrasenia);
	}


	listarCombo(ipInput: any) {
		const href = "Usuario/listarCombo";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	insertarUsuario(data: any/*, file: any */) {
		const href = "Usuario/insertarUsuario";
		let formData: FormData = new FormData();

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object,
			params: new HttpParams().set('entidad', JSON.stringify(data))
		};

		 /* Descomentar si tuviera archivos por enviar */
		//formData.append("uploadFile", file.file, file.nombre);

		return this.http.post(href, formData, httpOptions);
	}


	actualizarClaveUsuario(data: any/*, file: any */) {
		const href = "Usuario/actualizarClaveUsuario";
		let formData: FormData = new FormData();

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object,
			params: new HttpParams().set('entidad', JSON.stringify(data))
		};

		 /* Descomentar si tuviera archivos por enviar */
		//formData.append("uploadFile", file.file, file.nombre);

		return this.http.post(href, formData, httpOptions);
	}


	activarUsuario(ipInput: any) {
		const href = "Usuario/activarUsuario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	modificarUsuario(data: any/*, file: any */) {
		const href = "Usuario/modificarUsuario";
		let formData: FormData = new FormData();

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object,
			params: new HttpParams().set('entidad', JSON.stringify(data))
		};

		 /* Descomentar si tuviera archivos por enviar */
		//formData.append("uploadFile", file.file, file.nombre);

		return this.http.post(href, formData, httpOptions);
	}


	anularUsuario(ipInput: any) {
		const href = "Usuario/anularUsuario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


}
