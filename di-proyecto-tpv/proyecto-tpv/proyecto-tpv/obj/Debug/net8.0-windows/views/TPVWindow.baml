   M S B A M L   `   `   `  ����G  Cproyecto-tpv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:proyecto_tpv.viewsproyecto_tpv.views  5   	   "    proyecto_tpv.views.TPVWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:proyecto_tpv.views     5   	     � WindowStyle$
  None=�5   	   ���#161A1D � WindowStartupLocation$ CenterScreen=�61    � AllowsTransparency$
 True��6V   $	��600��5	   	   $
��1000��6   ���#FFFFFF$��	Comfortaa)�68   .��5
      � ���#161A1D � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��4* �6   .+�5      �� $��0��6   ���#0B090A$��4,4,2,4q�6/    �� RadiusX$ 10��6@    �� RadiusY$ 10��6M   � 5      -   5        $��	spOptions��5      $��4,4,2,4q�6   $��0��6-    � RowDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��3* �6   .+�5      �� -   5        $��bckImageProfile��5      $��10q�6)   $ 10��65   $ 10��6B   ���	#FFF5F3F4$��2��6b   �� 5      -   5        $��
imgProfile��5      $��14q�6    $��/images/profile-ico.ico��6,   � 5      -   5        $��
tpvOptions��5      $��1��6    5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   .+�5#   
   �� $��0��6   $��6q�6!   $ 10��6,   $ 10��69   ���#161A1D$��2��6U   ���	#FFF5F3F46i   �� 5$   
   -   5         ��Name$ optSettings��5$      $��0��6   $��4q�63   ��6?   Z� ��5%      �� 5&       �� ImageSource$% /images/tpvOptions/settings.ico��6   	 j� Stretch$	 Uniform=�6G   5(      �� 5*   
   $��1��6   $��6q�6!   $ 10��6,   $ 10��69   ���#161A1D$��2��6U   ���	#FFF5F3F46i   �� 5+   
   -   5        $ optCalendar��5+      $��1��6   $��4q�63   ��6?   Z� ��5,      �� 5-      $% /images/tpvOptions/calendar.ico��6   $	 Uniform=�6G   5/      �� 51   
   $��2��6   $��6q�6!   $ 10��6,   $ 10��69   ���#161A1D$��2��6U   ���	#FFF5F3F46i   �� 52   
   -   5        $ optOrder��52      $��2��6   $��4q�60   ${�False��6S   ��6<   Z� ��53      �� 54      $" /images/tpvOptions/order.ico��6   $	 Uniform=�6D   56      �� 58   
   $��3��6   $��6q�6!   $ 10��6,   $ 10��69   ���#161A1D$��2��6U   ���	#FFF5F3F46i   �� 59   
   -   5        $ optExit��59      $��3��6   $��4q�6/   ��6:   Z� ��5:      �� 5;      $! /images/tpvOptions/exit.ico��6   $	 Uniform=�6C   
 j� Viewbox$
 0,0,1,1�6U   5=      5>   	   5?      �� 5A      $��1��6   ���#0B090A$��4,4,2,4q�6/   $ 10��6@   $ 10��6M   � 5B      -	   5        $��spTicketCalc��5B      $��2,4,2,4q�6   $��1��60    5C      �� 5D   
   $��* �6   �� 5E   
   $��* �6   .+�5H      �� $��0��6   $��6,4,4,4q�6   $ 10��60   $ 10��6=   $��2��6J   ���	#FFF5F3F46^   �� 5I      $��0��6   $��4q�6   $��6q�6U   ��6(   Z� ��6>   Z� 5K   	   �� 5M      $��1��6   $��6,4,4,4q�6   $ 10��60   $ 10��6=   ���#161A1D6J   � 5N      $��1��6   $��6,4,4,4q�6    � ShowGridLines$
 True��6+    5O   
   �� 5P      $��* �6   �� 5Q      $��* �6   �� 5R      $��* �6   �� 5S      $��* �6   �� 5T      $��* �6    5V   
   �� 5W      $��* �6   �� 5X      $��* �6   �� 5Y      $��* �6   �� 5Z      $��* �6   �� 5[      $��* �6   5]   	   5^      �� 5`      $��2��6   ���#0B090A$��4q�6/   $ 10��6:   $ 10��6G   � 5a      -
   5        $��
spProducts��5a      $��2,4,4,4q�6   $��2��6.    5b      �� 5c   
   $
��2.5* �6   �� 5d   
   $
��2.5* �6   �� 5e   
   $��* �6    5g      �� 5h   
   $��* �6   �� 5i   
   $��4* �6   .+�5l      �� $��0��6   $��0��6   $��3��6/   $��6,4,4,4q�6@   $ 10��6Q   $ 10��6^   $��2��6k   ���	#FFF5F3F46   � 5m      $��0��6   $��0��6   $��3��6*   $��6,4,4,4q�6;    5n   
   �� 5o      $��* �6   �� 5p      $��* �6   �� 5q      $��* �6   �� 5r      $��* �6   �� 5s      $��* �6   �� 5t      $��* �6   �� 5u      $��* �6   .+�5x   
   �� $��0��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5y   
   -   5        $��btnRefrescos��5y      $��0��6%   $��14q�62   ��6>   Z� ��5z      �� 5{      $( "/images/tpvFoodImages/refresco.ico��6   $	 Uniform=�6J   5}      �� 5   
   $��1��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5�   
   -   5        $��
btnAlcohol��5�      $��1��6#   $��14q�60   ��6<   Z� ��5�      �� 5�      $' !/images/tpvFoodImages/alcohol.ico��6   $	 Uniform=�6I   5�      �� 5�   
   $��2��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5�   
   -   5        $��	btnCafeTe��5�      $��2��6"   $��14q�6/   ��6;   Z� ��5�      �� 5�      $$ /images/tpvFoodImages/cafe.ico��6   $	 Uniform=�6F   5�      �� 5�   
   $��3��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5�   
   -   5        $��btnAperitivo��5�      $��3��6%   $��14q�62   ��6>   Z� ��5�      �� 5�      $) #/images/tpvFoodImages/aperitivo.ico��6   $	 Uniform=�6K   5�      �� 5�   
   $��4��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5�   
   -   5        $��btnEntrante��5�      $��4��6$   $��14q�61   ��6=   Z� ��5�      �� 5�      $( "/images/tpvFoodImages/entrante.ico��6   $	 Uniform=�6J   5�      �� 5�   
   $��5��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5�   
   -   5        $��btnPrincipal��5�      $��5��6%   $��14q�62   ��6>   Z� ��5�      �� 5�      $) #/images/tpvFoodImages/principal.ico��6   $	 Uniform=�6K   5�      �� 5�   
   $��6��6   $��8q�6!   $ 10��6,   $ 10��69   $��2��6F   ���	#FFF5F3F46Z   �� 5�   
   -   5        $��
btnCPostre��5�      $��6��6#   $��14q�60   ��6<   Z� ��5�      �� 5�      $&  /images/tpvFoodImages/postre.ico��6   $	 Uniform=�6H   5�      5�   	   �� 5�      $��0��6   $��1��6   $��6,4,4,4q�6/   $ 10��6@   $ 10��6M   $��2��6Z   ���	#FFF5F3F46n    � 5�      -   5        $��contenidoProductos��5�      $��0��6(   $��1��65   $��6,4,4,4q�6E     � NavigationUIVisibility$ Hidden=�6V   �� 5�      $��1��6   $��1��6   $��6,4,4,4q�6/   $ 10��6@   $ 10��6M   $��2��6Z   ���	#FFF5F3F46n   �� 5�      $��2��6   $��1��6   $��6,4,4,4q�6/   $ 10��6@   $ 10��6M   $��2��6Z   ���	#FFF5F3F46n   5�      5�      5�      