   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop  5   	       Bioskop.Karta   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bioskop     5   	     � Title$  Karta��5   	   $	��350��6   $	��450��6$   .��5	      � -   5         �Name$ frmKarta��5	      ��5
   
   �� 5       j� Stretch$
 None=�6    �� ImageSource$4 .C:\Users\Marko\Desktop\pozadinaZaposleniii.jpg��6(    j� 
AlignmentY$	 Top=�6e    j� 
AlignmentX$ Right=�6v   .+�5   
   �� $.��(C:\Users\Marko\Desktop\pozadinaKarta.png��6   $��312,44,5,79q�6B    J� Opacity$	 0.8Q�6W   �� 5   
   -   5         ��Name$ lblZaposleni��5      
�������$
��Bold"�69   $��Zaposleni:
��6K   $
��Left=�6j   $��	20,37,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ lblGledalac��5      
����  �$
��Bold"�6;   $��Gledalac:
��6M   $
��Left=�6k   $��	25,82,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ lblProjekcija��5      
����  �$
��Bold"�6=   $��Projekcija:
��6O   $
��Left=�6o   $��
20,129,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ lblCena��5      $��Cena:
��6!   
����  �$
��Bold"�6Q   $
��Left=�6c   $��
47,176,0,0q�6~   $	��Top=�6�   �� 5   
   -   5        $ lblBrojSedista��5      
����  �$
��Bold"�6>   $��Broj sedista:
��6P   $
��Left=�6r   $��
11,223,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��
50,280,0,0q�6R   $	��Top=�6f   $	��100��6�   $��25��6�   $��15(�6�   $
��Bold"�6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   $
��Left=�65   $��207,280,0,0q�6P   $	��Top=�6e   $	��100��6�   $��25��6�   $��15(�6�   $
��Bold"�6�   �� 5   
   -	   5        	 ��Name$	 cbZaposleni��5      $
��Left=�6(   $��	89,42,0,0q�6C   $	��Top=�6V   $	��218��6n   
 �� DisplayMemberPath$
 	zaposleni��6z    �� SelectedValuePath$ IdZaposleni��6�   �� 5   
   -
   5        $	 
cbGledalac��5      $
��Left=�6'   $��	89,85,0,0q�6B   $	��Top=�6U   $	��218��6m   $
 gledalac��6y   $ 
IdGledaoca��6�   �� 5   
   -   5        $	 cbProjekcija��5      $
��Left=�6)   $��
89,133,0,0q�6D   $	��Top=�6X   $	��218��6p   $
 prikazivanje��6|   $ IdProjekcije��6�   �� 5   
   -   5         ��Name$ txtCena��5      $
��Left=�6#   
����  �
�������
���   �$��1q�6   $��
89,180,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��218��6�   $��22��6�   �� 5   
   -   5        $ txtBrojSedista��5      $
��Left=�6*   
����  �
�������
���   �$��1q�6�   $��
89,227,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��109��6�   $��22��6�   �� 5   
   -   5        $��Odabir sedista��5      $
��Left=�6*   $��207,215,0,0q�6E   $	��Top=�6Z   $��42��6r   $	��104��6~   $��15(�6�   $
��Bold"�6�   6�   5      5      