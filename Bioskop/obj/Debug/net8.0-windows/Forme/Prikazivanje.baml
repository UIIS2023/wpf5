   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop  5   	       Bioskop.Prikazivanje   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bioskop     5   	     � Title$  Prikazivanje��5   	   $	��300��6   $	��450��6+   .��5	      � -   5         �Name$ frmPrikazivanje��5	      ��5
   
   �� 5       j� Stretch$
 None=�6    �� ImageSource$4 .C:\Users\Marko\Desktop\pozadinaZaposleniii.jpg��6(    j� 
AlignmentY$ Center=�6e    j� 
AlignmentX$ Right=�6y   .+�5   
   �� $5��/C:\Users\Marko\Desktop\pozadinaPrikazivanje.png��6   $��183,61,-11,150q�6I    J� Opacity$	 0.8Q�6a   �� 5   
   -   5         ��Name$ lblTipPrikazivanja��5      $
��Bold"�6,   
����  �$��Tip prikazivanja:
��6T   $
��Left=�6z   $��5,46,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ lblDatum��5      $��Datum:
��6"   $
��Bold"�68   
����  �$
��Left=�6`   $��
56,118,0,0q�6{   $	��Top=�6�   �� 5   
   -   5         ��Name$ txtTipPrikazivanja��5      $
��Left=�6.   
����  �
���   �$��1q�6s   
�������$��
105,52,0,0q�6�   	 �� TextWrapping$
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��178��6�   $��18��6  (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 dpVreme��5      
����  �
���   �$��1q�6P   
�������$
��Left=�6{   $��105,121,0,0q�6�   $	��Top=�6�   $	��178��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��	Sacuvaj
��6%   $
��Left=�6A   $��
56,194,0,0q�6\   $	��Top=�6p   $��80��6�   $��25��6�   $��15(�6�   $
��Bold"�6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��
Otkazi

��6$   $
��Left=�6I   $��203,194,0,0q�6d   $	��Top=�6y   $��80��6�   $��25��6�   $��15(�6�   $
��Bold"�6�   6�   5      5      