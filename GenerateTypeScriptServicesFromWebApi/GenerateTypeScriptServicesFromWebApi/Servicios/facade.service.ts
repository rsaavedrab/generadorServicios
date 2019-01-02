import { Injectable, Injector } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class FacadeService {

	constructor(private injector: Injector) { }

	private _AsignacionUsuarioService: AsignacionUsuarioService;
	public get asignacionusuarioService(): AsignacionUsuarioService {
		if (!this._AsignacionUsuarioService) {
			this._AsignacionUsuarioService = this.injector.get(AsignacionUsuarioService);
		}
		return this._AsignacionUsuarioService
	}
	private _DataExternaService: DataExternaService;
	public get dataexternaService(): DataExternaService {
		if (!this._DataExternaService) {
			this._DataExternaService = this.injector.get(DataExternaService);
		}
		return this._DataExternaService
	}
	private _CalendarioService: CalendarioService;
	public get calendarioService(): CalendarioService {
		if (!this._CalendarioService) {
			this._CalendarioService = this.injector.get(CalendarioService);
		}
		return this._CalendarioService
	}
	private _ProyectoService: ProyectoService;
	public get proyectoService(): ProyectoService {
		if (!this._ProyectoService) {
			this._ProyectoService = this.injector.get(ProyectoService);
		}
		return this._ProyectoService
	}
	private _GestionPerfilService: GestionPerfilService;
	public get gestionperfilService(): GestionPerfilService {
		if (!this._GestionPerfilService) {
			this._GestionPerfilService = this.injector.get(GestionPerfilService);
		}
		return this._GestionPerfilService
	}
	private _UsuarioService: UsuarioService;
	public get usuarioService(): UsuarioService {
		if (!this._UsuarioService) {
			this._UsuarioService = this.injector.get(UsuarioService);
		}
		return this._UsuarioService
	}
}
