   M S B A M L   `   `   `  ����R  NejercicioManejoPersonas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ejercicioManejoPersonasejercicioManejoPersonas  5   	   (    "ejercicioManejoPersonas.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ejercicioManejoPersonas     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
      �� 5   
   $��* �6    � ColumnDefinitions 5      �� 5   
   $��* �6   �� 5   
   $
��3.5* �6   .+�5      �  5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   .+�5      �� -   5        $��	lblNombre��5      $��Nombre:��6#   $��
20,20,20,5q�65   �� 5      -   5        $��	txtNombre��5      $��
20,5,20,20q�6%   $	��135��69   �� 5      -   5        $��lblApellidos��5      $��
Apellidos:��6&   $��
20,20,20,5q�6;   �� 5      -   5        $��txtApellidos��5      $��
20,5,20,20q�6(   $	��135��6<   5      �� 5    
   $ Vertical=�6   $��1��6,   .+�5!      �� -   5        $��lblEdad��5!      $��Edad:��6!   $��
20,20,20,5q�61   �� 5"      -   5        $��txtEdad��5"      $��
20,5,20,20q�6#   $	��135��67   �� 5$      -   5        $��
btnAgregar��5$      $��Agregar Persona��6%   $	��135��6?   $��20q�6K   6W   5%      5&   	   � 5(      $��1��6    5)   
   �� 5*      $��7* �6   �� 5+      $��* �6    5.   
   �� 5/      $��* �6   �� 50      $��* �6   .+�53      &   System.Windows.Controls.DataGrid  -   5        $��dgvPersonas��53      $��0��6$   $��2��61      AutoGenerateColumns$ False��6E   $��	0,20,16,0q�6b      Columns 54   
   0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6/   �� *Nombre+  56      $ 	Apellidos��6    62   �� *	Apellidos+  57      $
 Edad��6    6-   �� *Edad+59   	   �� 5;      -	   5        $��btnModificar��5;      $��	Modificar��6#   $��1��67   $��0��6D   $	��120��6T   $��20��6`   $
��Left=�5<      6*   �� 5=      -
   5        $��btnEliminar��5=      $��Eliminar��6"   $��1��65   $��1��6B   $	��120��6R   $��20��6^   $��Right=�5>      $��0,0,20,0q�6+   6=   5?      5@      5A      