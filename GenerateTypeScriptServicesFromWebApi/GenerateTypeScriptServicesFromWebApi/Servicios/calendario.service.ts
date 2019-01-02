import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class CalendarioService {

	constructor(private http: HttpClient) { }

	listarCalendario(ipInput: any) {
		const href = "Calendario/listarCalendario";
		return this.http.get(href + "?ipInput.strData=" + JSON.stringify(ipInput));
	}


	insertarCalendario(ipInput: any) {
		const href = "Calendario/insertarCalendario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	modificarCalendario(ipInput: any) {
		const href = "Calendario/modificarCalendario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.put(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


	anularCalendario(ipInput: any) {
		const href = "Calendario/anularCalendario";

		var headers_object = new HttpHeaders();
		headers_object.append('Content-Type', 'application/json');

		const httpOptions = {
			headers: headers_object
		};

		return this.http.post(href + "?ipInput.strData=" + JSON.stringify(ipInput), null, httpOptions);
	}


}
