   M S B A M L   `   `   `  ����   MuebleriaPIS6    0MuebleriaPIS.Vistas.Inventario.GestionInventario   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008        BackgroundBrushSecond  N� 
Background#  [  .��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $4��./Recursos/Imagenes/BarraNavegacion/Regreso.ico��$��0��$��30��$��2,0,0,0q�$��Center=�$
��Left=��� $��1��$��Gestión de Inventario��$��32(�$��SemiBold"�$��Center=�$��0,0,0,20q�� $��2�� � ColumnDefinitions �� $	��350 ��� $��* �.+��� $��0��$��0,0,20,0q�.+��� 
������� �� CornerRadius$ 8�� �� Padding$ 20q�._��� .+��� $��Datos del Producto��$��20(�$��SemiBold"�$��0,0,0,15q��� $��ID del Producto��$��0,0,0,5q��� -    ��Name$ txtIdProducto��$��35��  ModernTextBox#��[ $��0,0,0,10q��� $��Nombre��$��0,0,0,5q��� -   $ txtNombreProducto��$��35��#��[ $��0,0,0,10q��� $��Precio��$��0,0,0,5q��� -   $ txtPrecioProducto��$��35��#��[ $��0,0,0,10q��� $��
Categoría��$��0,0,0,5q��� -   $ txtCategoriaProducto��$��35��#��[ $��0,0,0,10q��� $��Cantidad Disponible��$��0,0,0,5q��� -   $ txtStockProducto��$��35��#��[ $��0,0,0,20q���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $#��Agregar o Actualizar Producto��$	��200��$��40��  BaseButtonStyle#��[ �� $��1��
�������$ 8��$ 20q�._��  �� $
��Auto ��� $��* �.+��� $��0��$��Inventario Actual��$��20(�$��SemiBold"�$��0,0,0,15q�&   System.Windows.Controls.DataGrid  -     Name$ dgInventario��$��1��   AutoGenerateColumns .  	   
IsReadOnly	 . 
�������$��1q����#EEEEEE
   RowBackground

 �����   AlternatingRowBackground �#F5F5F5   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID Producto��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.2* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IdProducto+  $ Nombre��$
 0.3*  �� *Nombre+  $ Precio��$
 0.2*  �� *Precio+  $ 
Categoría��$
 0.2*  �� *	Categoria+  $ Fecha Ingreso��$
 0.3*  �� *FechaIngreso+  $ Cantidad��$
 0.2*  �� *CantidadDisponible+