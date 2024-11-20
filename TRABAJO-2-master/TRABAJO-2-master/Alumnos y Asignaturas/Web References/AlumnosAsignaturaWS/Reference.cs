﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Alumnos_y_Asignaturas.AlumnosAsignaturaWS {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MiWSSoap", Namespace="http://tempuri.org/")]
    public partial class MiWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GuardarAlumOperationCompleted;
        
        private System.Threading.SendOrPostCallback GuardarAsigOperationCompleted;
        
        private System.Threading.SendOrPostCallback listarAlumnOperationCompleted;
        
        private System.Threading.SendOrPostCallback listarAsigOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MiWS() {
            this.Url = global::Alumnos_y_Asignaturas.Properties.Settings.Default.Alumnos_y_Asignaturas_AlumnosAsignaturaWS_MiWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GuardarAlumCompletedEventHandler GuardarAlumCompleted;
        
        /// <remarks/>
        public event GuardarAsigCompletedEventHandler GuardarAsigCompleted;
        
        /// <remarks/>
        public event listarAlumnCompletedEventHandler listarAlumnCompleted;
        
        /// <remarks/>
        public event listarAsigCompletedEventHandler listarAsigCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GuardarAlum", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GuardarAlum(string nombre, string apellidoPat, string apellidoMat, string mail, int matricula) {
            object[] results = this.Invoke("GuardarAlum", new object[] {
                        nombre,
                        apellidoPat,
                        apellidoMat,
                        mail,
                        matricula});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void GuardarAlumAsync(string nombre, string apellidoPat, string apellidoMat, string mail, int matricula) {
            this.GuardarAlumAsync(nombre, apellidoPat, apellidoMat, mail, matricula, null);
        }
        
        /// <remarks/>
        public void GuardarAlumAsync(string nombre, string apellidoPat, string apellidoMat, string mail, int matricula, object userState) {
            if ((this.GuardarAlumOperationCompleted == null)) {
                this.GuardarAlumOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGuardarAlumOperationCompleted);
            }
            this.InvokeAsync("GuardarAlum", new object[] {
                        nombre,
                        apellidoPat,
                        apellidoMat,
                        mail,
                        matricula}, this.GuardarAlumOperationCompleted, userState);
        }
        
        private void OnGuardarAlumOperationCompleted(object arg) {
            if ((this.GuardarAlumCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GuardarAlumCompleted(this, new GuardarAlumCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GuardarAsig", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GuardarAsig(string nombre, int creditos) {
            object[] results = this.Invoke("GuardarAsig", new object[] {
                        nombre,
                        creditos});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void GuardarAsigAsync(string nombre, int creditos) {
            this.GuardarAsigAsync(nombre, creditos, null);
        }
        
        /// <remarks/>
        public void GuardarAsigAsync(string nombre, int creditos, object userState) {
            if ((this.GuardarAsigOperationCompleted == null)) {
                this.GuardarAsigOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGuardarAsigOperationCompleted);
            }
            this.InvokeAsync("GuardarAsig", new object[] {
                        nombre,
                        creditos}, this.GuardarAsigOperationCompleted, userState);
        }
        
        private void OnGuardarAsigOperationCompleted(object arg) {
            if ((this.GuardarAsigCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GuardarAsigCompleted(this, new GuardarAsigCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/listarAlumn", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Alumnos[] listarAlumn() {
            object[] results = this.Invoke("listarAlumn", new object[0]);
            return ((Alumnos[])(results[0]));
        }
        
        /// <remarks/>
        public void listarAlumnAsync() {
            this.listarAlumnAsync(null);
        }
        
        /// <remarks/>
        public void listarAlumnAsync(object userState) {
            if ((this.listarAlumnOperationCompleted == null)) {
                this.listarAlumnOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistarAlumnOperationCompleted);
            }
            this.InvokeAsync("listarAlumn", new object[0], this.listarAlumnOperationCompleted, userState);
        }
        
        private void OnlistarAlumnOperationCompleted(object arg) {
            if ((this.listarAlumnCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listarAlumnCompleted(this, new listarAlumnCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/listarAsig", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Asignaturas[] listarAsig() {
            object[] results = this.Invoke("listarAsig", new object[0]);
            return ((Asignaturas[])(results[0]));
        }
        
        /// <remarks/>
        public void listarAsigAsync() {
            this.listarAsigAsync(null);
        }
        
        /// <remarks/>
        public void listarAsigAsync(object userState) {
            if ((this.listarAsigOperationCompleted == null)) {
                this.listarAsigOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistarAsigOperationCompleted);
            }
            this.InvokeAsync("listarAsig", new object[0], this.listarAsigOperationCompleted, userState);
        }
        
        private void OnlistarAsigOperationCompleted(object arg) {
            if ((this.listarAsigCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listarAsigCompleted(this, new listarAsigCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Alumnos {
        
        private int iDAlumnoField;
        
        private string nombreField;
        
        private string apellidoPAtField;
        
        private string apellidoMatField;
        
        private string emailField;
        
        private int numeroMatriculaField;
        
        /// <remarks/>
        public int IDAlumno {
            get {
                return this.iDAlumnoField;
            }
            set {
                this.iDAlumnoField = value;
            }
        }
        
        /// <remarks/>
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <remarks/>
        public string ApellidoPAt {
            get {
                return this.apellidoPAtField;
            }
            set {
                this.apellidoPAtField = value;
            }
        }
        
        /// <remarks/>
        public string ApellidoMat {
            get {
                return this.apellidoMatField;
            }
            set {
                this.apellidoMatField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroMatricula {
            get {
                return this.numeroMatriculaField;
            }
            set {
                this.numeroMatriculaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Asignaturas {
        
        private int codigoAsignaturaField;
        
        private string nombreAsignaturaField;
        
        private int creditosField;
        
        /// <remarks/>
        public int CodigoAsignatura {
            get {
                return this.codigoAsignaturaField;
            }
            set {
                this.codigoAsignaturaField = value;
            }
        }
        
        /// <remarks/>
        public string NombreAsignatura {
            get {
                return this.nombreAsignaturaField;
            }
            set {
                this.nombreAsignaturaField = value;
            }
        }
        
        /// <remarks/>
        public int Creditos {
            get {
                return this.creditosField;
            }
            set {
                this.creditosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GuardarAlumCompletedEventHandler(object sender, GuardarAlumCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GuardarAlumCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GuardarAlumCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GuardarAsigCompletedEventHandler(object sender, GuardarAsigCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GuardarAsigCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GuardarAsigCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void listarAlumnCompletedEventHandler(object sender, listarAlumnCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class listarAlumnCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal listarAlumnCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Alumnos[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Alumnos[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void listarAsigCompletedEventHandler(object sender, listarAsigCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class listarAsigCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal listarAsigCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Asignaturas[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Asignaturas[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591