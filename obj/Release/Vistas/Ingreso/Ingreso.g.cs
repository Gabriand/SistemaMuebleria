﻿#pragma checksum "..\..\..\..\Vistas\Ingreso\Ingreso.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "132F800B9DA7361E7374D60E7A0B443D88BDEA18E5347485061C353FF9488F3B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MuebleriaPIS.Vistas;
using MuebleriaPIS.Vistas.Compartido;
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


namespace MuebleriaPIS.Vistas {
    
    
    /// <summary>
    /// IngresoPage
    /// </summary>
    public partial class IngresoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MuebleriaPIS.Vistas.Compartido.BarraNavegacion barraNavegacion;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsuario;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtContrasena;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIngresar;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistrarse;
        
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
            System.Uri resourceLocater = new System.Uri("/MuebleriaPIS;component/vistas/ingreso/ingreso.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
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
            this.txtUsuario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtContrasena = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            
            #line 67 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OlvidasteContrasena_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnIngresar = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
            this.btnIngresar.Click += new System.Windows.RoutedEventHandler(this.IngresoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRegistrarse = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\Vistas\Ingreso\Ingreso.xaml"
            this.btnRegistrarse.Click += new System.Windows.RoutedEventHandler(this.btnRegistrarse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

