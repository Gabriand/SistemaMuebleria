﻿#pragma checksum "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "76C1635B112D7D65BFC61CDA2AB4229253B8353F0EA059961FBF10382448F026"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MuebleriaPIS.Vistas.Compartido;
using MuebleriaPIS.Vistas.GestionUsuarios;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MuebleriaPIS.Vistas.GestionUsuarios {
    
    
    /// <summary>
    /// DetalleUsuario
    /// </summary>
    public partial class DetalleUsuario : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MuebleriaPIS.Vistas.Compartido.BarraNavegacion barraNavegacion;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreUs;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCorreoUs;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTelefonoUs;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDireccionUs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MuebleriaPIS;component/vistas/gestionusuarios/detalleusuario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.barraNavegacion = ((MuebleriaPIS.Vistas.Compartido.BarraNavegacion)(target));
            return;
            case 2:
            this.txtNombreUs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtCorreoUs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtTelefonoUs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtDireccionUs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 99 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditarPerfilBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 108 "..\..\..\..\Vistas\GestionUsuarios\DetalleUsuario.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CerrarSesionBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

