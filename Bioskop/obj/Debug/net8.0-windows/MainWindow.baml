   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop  5   	       Bioskop.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bioskop     5   	     � Title$  Naslov��5   	   $	��350��6   $	��700��6%    � 
ResizeMode$ NoResize=�61   .��5
      � ��5   
   �� 5       j� Stretch$
 None=�6    �� ImageSource$3 -C:\Users\Marko\Desktop\pozadinaAplikacija.jpg��6(    j� 
AlignmentY$	 Top=�6d    j� 
AlignmentX$ Center=�6u   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6-   $��Center=�6J   $
��auto��6e   $
��auto��6s      
IsReadOnly$
 True��6�      CanUserAddRows$ False��5         SelectionUnit$ FullRow=�6+   	   SelectionMode$	 Single=�6C   
   	RowHeight$
 22Q�6Z      	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value
 �����63   �� 5       � ��
 ��  �63    �� Triggers 5      P� 5       P� Property �@ 
IsSelected P� Value$
 True��68   . �5      ��  � ��
 �����6;   �� 5       � ��
 ��  �6;   5      5      5"      �� 5#      $��Center=�6   $��30��6:   $	��Top=�6G   $
��auto��6_    �� Orientation$ 
Horizontal=�6l   .+�5$      �� -   5         ��Name$ btnKarta��5$      $��Karta��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��85��6v   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6�    � Cursor$
 Hand��6	  �� 5%      -   5        $ btnZaposleni��5%      $��	Zaposleni��6+   $
��Left=�6?   $��30��6Z   $	��Top=�6f   $��85��6~   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6  $
 Hand��6  �� 5&      -   5        $ btnGrickalice��5&      $��
Grickalice��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��85��6�   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6  $
 Hand��6  �� 5'      -   5        $ btnGledalac��5'      $��Gledalac��6*   $
��Left=�6=   $��30��6X   $	��Top=�6d   $��85��6|   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6   $
 Hand��6  �� 5(      -   5        $ btnSala��5(      $
��Sale��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��85��6t   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6�   $
 Hand��6  �� 5)      -   5        $ btnFilm��5)      $
��Film��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��85��6t   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6�   $
 Hand��6  �� 5*      -   5        $ btnProjekcija��5*      $��
Projekcije��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��85��6�   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6  $
 Hand��6  �� 5+      -	   5        $ btnPrikazivanje��5+      $��Prikazivanje��6.   $
��Left=�6E   $��30��6`   $	��Top=�6l   $��85��6�   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6  $
 Hand��6  5,      �� 5-      $��Center=�6   $��30��66   $��Bottom=�6C   $	��360��6^   $ 
Horizontal=�6j   .+�5.      �� -
   5        $ btnDodaj��5.      $��Dodaj��6'   $	��120��67   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6�   $
 Hand��6�   �� 5/      -   5        $ 	btnIzmeni��5/      $��Izmeni��6(   $	��120��69   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6�   $
 Hand��6�   �� 50      -   5        $ 	btnObrisi��50      $��Obriši��6(   $	��120��69   
����  �
�������
���   �$��2q�6�   $��14(�6�   $
��Bold"�6�   $
 Hand��6�   51      53      56      