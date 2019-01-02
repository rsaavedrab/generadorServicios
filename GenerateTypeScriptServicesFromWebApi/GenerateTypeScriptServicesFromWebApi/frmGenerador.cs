using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Web.Http;

namespace GenerateTypeScriptServicesFromWebApi
{
    public partial class frmGenerador : Form
    {
        public frmGenerador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtRuta.Text = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"D:\";
            fd.Filter = "Archivos Assemblys (*.dll) | *.dll";

            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtRuta.Text = fd.FileName;
            }
        }

        private void btnGenerarServicios_Click(object sender, EventArgs e)
        {

            try
            {
                Assembly asm = Assembly.LoadFrom(txtRuta.Text.Trim());

                Type[] types = asm.GetTypes();
                
                foreach (Type item in types)
                {
                    if (item.BaseType.Name == "Controller")
                    {
                        generarArchivoServicio(item, asm);
                    }
                }

                generarFacadeServices(types);

                MessageBox.Show("Se crearón los servicios @ngular satisfactoriamente!!", "Generador de Servicios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void generarFacadeServices(Type[] items)
        {
            string file = Environment.CurrentDirectory.Replace(@"bin\Debug", "") + @"\Servicios\facade.service.ts";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("import { Injectable, Injector } from '@angular/core';");

            sb.AppendLine();
            sb.AppendLine(@"@Injectable({
    providedIn: 'root'
})");

            sb.AppendLine();
            sb.AppendLine("export class FacadeService {\n");

            sb.AppendLine("\tconstructor(private injector: Injector) { }\n");

            foreach (Type item in items)
            {
                if (item.BaseType.Name == "Controller")
                {
                    string servicioName = item.Name.Replace("Controller", "") + "Service";
                    sb.AppendLine("\tprivate _" + servicioName + ": " + servicioName + ";");

                    string strGetService = item.Name.Replace("Controller", "").ToLower() + "Service";

                    sb.AppendLine("\tpublic get " + strGetService + "(): " + servicioName + " {");
                    sb.AppendLine("\t\tif (!this._" + servicioName + ") {");
                    sb.AppendLine("\t\t\tthis._" + servicioName + " = this.injector.get(" + servicioName + ");");
                    sb.AppendLine("\t\t}");

                    sb.AppendLine("\t\treturn this._" + servicioName);
                    sb.AppendLine("\t}");
                }
            }

            sb.AppendLine("}");
            System.IO.File.WriteAllText(file, sb.ToString());
        }

        private void generarArchivoServicio(Type tipo, Assembly asm)
        {
            string servicio = tipo.Name.Replace("Controller", "");
            string servicioName = tipo.Name.Replace("Controller", "") + "Service";
            string fileName = tipo.Name.Replace("Controller", "").ToLower() + ".service";


            string file = Environment.CurrentDirectory.Replace(@"bin\Debug", "") + @"\Servicios\" + fileName + ".ts";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("import { Injectable } from '@angular/core';");
            sb.AppendLine("import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';");

            sb.AppendLine();
            sb.AppendLine(@"@Injectable({
    providedIn: 'root'
})");
            sb.AppendLine();
            sb.AppendLine("export class " + servicioName + " {\n");

            sb.AppendLine("\tconstructor(private http: HttpClient) { }\n");

            foreach (MethodInfo item in tipo.GetMethods())
            {
                if (item.ReturnParameter.ToString().Trim() == "System.Net.Http.HttpResponseMessage")
                {
                    sb.AppendLine(generarMetodo(item, asm, servicio));
                }

                if (item.ReturnParameter.ToString().Trim() == "System.Web.Mvc.ContentResult")
                {
                    sb.AppendLine(generarMetodo(item, asm, servicio));
                }
            }

            sb.AppendLine("}");
            System.IO.File.WriteAllText(file, sb.ToString());
        }

        private string generarMetodo(MethodInfo metodo, Assembly asm, string servicio)
        {
            StringBuilder sb = new StringBuilder();

            int nroParametros = metodo.GetParameters().Length;

            sb.Append(generarFirmaMetodoWithParameters(metodo, servicio));

            return sb.ToString();
        }

        public string generarFirmaMetodoWithParameters(MethodInfo metodo, string servicio)
        {
            StringBuilder sb = new StringBuilder();

            int nroParametros = metodo.GetParameters().Length;

            IEnumerable<Attribute> listaAtributos = metodo.GetCustomAttributes();

            foreach (Attribute attribute in listaAtributos)
            {
                if (attribute is System.Web.Mvc.HttpGetAttribute || attribute is HttpGetAttribute)
                {
                    if (nroParametros > 0)
                    {
                        sb.AppendLine("\t" + metodo.Name + "(" + retornarParametrosFirma(metodo) + ") {");
                    }
                    else
                    {
                        sb.AppendLine("\t" + metodo.Name + "() {");
                    }

                }

                if (attribute is System.Web.Mvc.HttpPostAttribute || attribute is System.Web.Mvc.HttpPutAttribute || attribute is HttpPostAttribute || attribute is HttpPutAttribute)
                {
                    if (nroParametros > 0)
                    {
                        sb.AppendLine("\t" + metodo.Name + "(" + retornarParametrosFirma(metodo) + ") {");
                    }
                    else
                    {
                        sb.AppendLine("\t" + metodo.Name + "(data: any/*, file: any */) {");
                    }
                }

                if (attribute is System.Web.Mvc.HttpDeleteAttribute || attribute is HttpDeleteAttribute)
                {
                    if (nroParametros > 0)
                    {
                        sb.AppendLine("\t" + metodo.Name + "(" + retornarParametrosFirma(metodo) + ") {");
                    }
                    else
                    {
                        sb.AppendLine("\t" + metodo.Name + "(data: any) {");
                    }
                }

                sb.AppendLine(generarCuerpoMetodo(metodo, attribute, servicio));
            }


            return sb.ToString();
        }

        public string generarCuerpoMetodo(MethodInfo metodo, Attribute atributo, string servicio)
        {
            StringBuilder sb = new StringBuilder();
            int nroParametros = metodo.GetParameters().Length;

            sb.AppendLine("\t\tconst href = \"" + string.Format(servicio + "/" + metodo.Name) + "\";");

            string urlParametros = retornarUrlParametrosServicio(metodo);

            if (atributo is System.Web.Mvc.HttpGetAttribute || atributo is HttpGetAttribute)
            {

                if (nroParametros == 0)
                {
                    sb.AppendLine("\t\treturn this.http.get(href);");
                }
                else
                {
                    sb.AppendLine("\t\treturn this.http.get(href + \"" + urlParametros + ");");
                }
            }

            if (atributo is System.Web.Mvc.HttpPostAttribute || atributo is System.Web.Mvc.HttpPutAttribute || atributo is HttpPostAttribute || atributo is HttpPutAttribute)
            {
                if (nroParametros == 0)
                {
                    sb.AppendLine("\t\tlet formData: FormData = new FormData();");
                    sb.AppendLine();
                    sb.AppendLine("\t\tvar headers_object = new HttpHeaders();");
                    sb.AppendLine("\t\theaders_object.append('Content-Type', 'application/json');");
                    sb.AppendLine();
                    sb.AppendLine("\t\tconst httpOptions = {");
                    sb.AppendLine("\t\t\theaders: headers_object,");
                    sb.AppendLine("\t\t\tparams: new HttpParams().set('entidad', JSON.stringify(data))");
                    sb.AppendLine("\t\t};");
                    sb.AppendLine();
                    sb.AppendLine("\t\t /* Descomentar si tuviera archivos por enviar */");
                    sb.AppendLine("\t\t//formData.append(\"uploadFile\", file.file, file.nombre);");
                    sb.AppendLine();

                    if (atributo is System.Web.Mvc.HttpPostAttribute)
                    {
                        sb.AppendLine("\t\treturn this.http.post(href, formData, httpOptions);");
                    }
                    else
                    {
                        sb.AppendLine("\t\treturn this.http.put(href, formData, httpOptions);");
                    }
                }
                else
                {
                    sb.AppendLine();
                    sb.AppendLine("\t\tvar headers_object = new HttpHeaders();");
                    sb.AppendLine("\t\theaders_object.append('Content-Type', 'application/json');");
                    sb.AppendLine();
                    sb.AppendLine("\t\tconst httpOptions = {");
                    sb.AppendLine("\t\t\theaders: headers_object");
                    sb.AppendLine("\t\t};");
                    sb.AppendLine();

                    if (atributo is System.Web.Mvc.HttpPostAttribute)
                    {
                        sb.AppendLine("\t\treturn this.http.post(href + \"" + urlParametros + ", null, httpOptions);");
                    }
                    else
                    {
                        sb.AppendLine("\t\treturn this.http.put(href + \"" + urlParametros + ", null, httpOptions);");
                    }
                }
            }

            if (atributo is System.Web.Mvc.HttpDeleteAttribute || atributo is HttpDeleteAttribute)
            {
                if (nroParametros == 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("\t\tvar headers_object = new HttpHeaders();");
                    sb.AppendLine("\t\theaders_object.append('Content-Type', 'application/json');");
                    sb.AppendLine();
                    sb.AppendLine("\t\tconst httpOptions = {");
                    sb.AppendLine("\t\t\theaders: headers_object,");
                    sb.AppendLine("\t\t\tparams: new HttpParams().set('entidad', JSON.stringify(data))");
                    sb.AppendLine("\t\t};");
                    sb.AppendLine();

                    if (atributo is System.Web.Mvc.HttpPostAttribute)
                    {
                        sb.AppendLine("\t\treturn this.http.delete(href, httpOptions);");
                    }
                    else
                    {
                        sb.AppendLine("\t\treturn this.http.delete(href, httpOptions);");
                    }
                }
                else
                {
                    sb.AppendLine();
                    sb.AppendLine("\t\tvar headers_object = new HttpHeaders();");
                    sb.AppendLine("\t\theaders_object.append('Content-Type', 'application/json');");
                    sb.AppendLine();
                    sb.AppendLine("\t\tconst httpOptions = {");
                    sb.AppendLine("\t\t\theaders: headers_object");
                    sb.AppendLine("\t\t};");
                    sb.AppendLine();

                    if (atributo is System.Web.Mvc.HttpPostAttribute)
                    {
                        sb.AppendLine("\t\treturn this.http.delete(href + \"" + urlParametros + ", httpOptions);");
                    }
                    else
                    {
                        sb.AppendLine("\t\treturn this.http.delete(href + \"" + urlParametros + ", httpOptions);");
                    }
                }
            }

            sb.AppendLine("\t}");
            return sb.ToString();
        }

        public string retornarUrlParametrosServicio(MethodInfo metodo)
        {
            string UrlParameters = "";

            int nroParametros = metodo.GetParameters().Length;

            if (nroParametros == 0)
            {
                return "";
            }

            foreach (ParameterInfo item in metodo.GetParameters())
            {
                if (item.ParameterType.IsPrimitive || item.GetType() == typeof(Decimal) || item.GetType() == typeof(String))
                {
                    if (nroParametros == 1)
                    {
                        UrlParameters = "?" + item.Name + "=\" + " + item.Name;
                    }
                    else
                    {
                        if (UrlParameters.Length == 0)
                        {
                            UrlParameters = "?" + item.Name + "= \" + " + item.Name + "";
                        }
                        else
                        {
                            UrlParameters += " + " + "\"&" + item.Name + "=\" + " + item.Name + "";
                        }
                    }
                }
                else if (item.ParameterType.IsClass)
                {
                    if (nroParametros == 1)
                    {
                        if (item.ParameterType.Name == "String")
                        {
                            UrlParameters = "?" + item.Name + "=\" + " + item.Name;
                        }
                        else
                        {
                            UrlParameters = "?" + item.Name + ".strData=\" + JSON.stringify(" + item.Name + ")";
                        }
                    }
                    else
                    {
                        if (UrlParameters.Length == 0)
                        {
                            UrlParameters = "?" + item.Name + "=\" + " + item.Name;
                        }
                        else
                        {
                            UrlParameters += " + \"&" + item.Name + "=\" + " + item.Name;
                        }
                    }
                }
            }

            return UrlParameters;
        }

        public string retornarParametrosFirma(MethodInfo metodo)
        {
            string parameters = "";

            int nroParametros = metodo.GetParameters().Length;

            if (nroParametros == 0)
            {
                return "";
            }
            else
            {
                foreach (ParameterInfo item in metodo.GetParameters())
                {
                    if (item.ParameterType.Name == "Int32" || item.ParameterType.Name == "Decimal" || item.ParameterType.Name == "Double" || item.ParameterType.Name == "Single" || item.ParameterType.Name == "Int64")
                    {
                        parameters += item.Name + ": number, ";
                    }

                    if (item.ParameterType.Name == "Boolean")
                    {
                        parameters += item.Name + ": boolean, ";
                    }


                    if (item.ParameterType.IsClass)
                    {
                        if (item.ParameterType.Name == "String")
                        {
                            parameters += item.Name + ": string, ";
                        }
                        else
                        {
                            parameters += item.Name + ": any, ";
                        }

                    }
                }
            }

            if (nroParametros > 0)
            {
                parameters = parameters.Remove(parameters.Length - 2, 2);
            }

            return parameters;
        }

    }
}

