import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class DataExternaService {

	constructor(private http: HttpClient) { }

	listarInformacionSsi(intCodigo: number) {
		const href = "DataExterna/listarInformacionSsi";
		return this.http.get(href + "?intCodigo=" + intCodigo);
	}


	consultarInformacionReniec(strDni: string) {
		const href = "DataExterna/consultarInformacionReniec";
		return this.http.get(href + "?strDni=" + strDni);
	}


}
