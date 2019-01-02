import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class ProyectoService {

	constructor(private http: HttpClient) { }

	listarProyecto(ipInput: any) {
		const href = "Proyecto/listarProyecto";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	listarProyectoDocumento(ipInput: any) {
		const href = "Proyecto/listarProyectoDocumento";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	listarDocumentos(ipInput: any) {
		const href = "Proyecto/listarDocumentos";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	insertarProyecto(ipInput: any) {
		const href = "Proyecto/insertarProyecto";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	insertarDocumentoProyecto(data: any/*, file: any */) {
		const href = "Proyecto/insertarDocumentoProyecto";
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


	modificarProyecto(ipInput: any) {
		const href = "Proyecto/modificarProyecto";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	notificarProyecto(ipInput: any) {
		const href = "Proyecto/notificarProyecto";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


}
