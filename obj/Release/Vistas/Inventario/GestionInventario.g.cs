﻿#pragma checksum "..\..\..\..\Vistas\Inventario\GestionInventario.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "26F7BAF332202D8720CBDDA6F99F2C88C060FA8C2C2D64AC221BD070C75C4209"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MuebleriaPIS.Vistas.Inventario {
    
    
    /// <summary>
    /// GestionInventario
    /// </summary>
    public partial class GestionInventario : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIdProducto;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreProducto;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrecioProducto;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCategoriaProducto;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStockProducto;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgInventario;
        
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
            System.Uri resourceLocater = new System.Uri("/MuebleriaPIS;component/vistas/inventario/gestioninventario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 23 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.RegresarBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtIdProducto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtNombreProducto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPrecioProducto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtCategoriaProducto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtStockProducto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 99 "..\..\..\..\Vistas\Inventario\GestionInventario.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AgregarOActualizarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgInventario = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

