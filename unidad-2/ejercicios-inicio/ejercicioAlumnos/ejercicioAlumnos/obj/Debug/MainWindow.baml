   M S B A M L   `   `   `  ����K  GejercicioAlumnos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ejercicioAlumnosejercicioAlumnos  5   	   !    ejercicioAlumnos.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ejercicioAlumnos     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
      �� -   5        $��lNombre��5
      $��Nombre Completo��6   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   �� 5      -   5        $��lEdad��5      $
��Edad��6   $
��Left=�6(   $��	10,41,0,0q�6C   $	��Top=�6V   �� 5      -   5        $��lSexo��5      $
��Sexo��6   $
��Left=�6(   $��	10,72,0,0q�6C   $	��Top=�6V   �� 5      -   5        $��lCurso��5      $��Curso��6   $
��Left=�6*   $��
10,103,0,0q�6E   $	��Top=�6Y   �� 5      -   5        $��lHorario��5      $��Horario��6   $
��Left=�6.   $��
10,134,0,0q�6I   $	��Top=�6]   �� 5      -   5        $��tNombreInput��5      $
��Left=�6"   $��
240,14,0,0q�6=    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��165��6�   $��2��6�   �� 5      -   5        $��
tEdadInput��5      $
��Left=�6    $��
240,45,0,0q�6;   $
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $��82��6�   	� 5      -   5        $��rbMasculino��5      $��	Masculino��6%   $
��Left=�69   $��
240,78,0,0q�6T   $	��Top=�6h   $��80��6�   	� 5      -	   5        $��
rbFemenino��5      $��Femenino��6$   $
��Left=�67   $��
325,78,0,0q�6R   $	��Top=�6f   $��80��6~    J� RenderTransformOrigin$ 0.185,0.345&�6�   $��2��6�   �� 5      -
   5        $��cobCurso��5      $��2��6   $
��Left=�63   $��240,105,0,0q�6N   $	��Top=�6c   $	��165��6{   .@�5      �� $	��DAM��6    �� 
IsSelected . 6#   �� 5      $	��DAW��6   �� 5      $
��ASIR��6   5      �� 5      -   5        $��
cobHorario��5      $��2��6!   $
��Left=�65   $��240,136,0,0q�6P   $	��Top=�6e   $	��165��6}   .@�5      �� $��Diurno��6    . 6&   �� 5      $��Nocturno��6   5      �� 5      -   5        $
��cbTI��5      $
��T.I.��6   $
��Left=�6*   $��
10,165,0,0q�6E   $	��Top=�6Y   �� 5      -   5        $��cbDocumento��5      $��Otro Documento:��6"   $
��Left=�6<   $��
65,165,0,0q�6W   $	��Top=�6k   �� 5      -   5        $��tDocumentoInput��5      $��2��6%   $
��Left=�69   $��240,164,0,0q�6T   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��165��6�   �� 5       -   5        $��
bRegistrar��5       $��	Registrar��6   $
��Left=�63   $��10,0,0,0q�6N   $��Center=�6`   $	��160��6{   �� 5!      -   5         ��Name$ bSalir��5!      $��Salir��6   $
��Left=�6-   $��Center=�6H   $	��160��6c   $��2��6o   $��	245,0,0,0q�6�   5"      5#      