   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop  5   	       Bioskop.Projekcija   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bioskop     5   	     � Title$  
Projekcija��5   	   $	��300��6   $	��450��6)   .��5	      � -   5         �Name$ frmProjekcija��5	      ��5
   
   �� 5       j� Stretch$
 None=�6    �� ImageSource$4 .C:\Users\Marko\Desktop\pozadinaZaposleniii.jpg��6(    j� 
AlignmentY$ Center=�6e    j� 
AlignmentX$ Right=�6y   .+�5   
   �� -   5         ��Name$ cbFilm��5      $
��Left=�6#   $��	40,39,0,0q�6>   $	��Top=�6Q   $	��322��6i    �� DisplayMemberPath$ Naslov��6u    �� SelectedValuePath$ IdFilm��6�   �� 5   
   -   5        $ cbSale��5      $
��Left=�6#   $��	40,99,0,0q�6>   $	��Top=�6Q   $	��322��6i   $ IdSale��6u   $ IdSale��6�   �� 5   
   -   5        $ cbPrikazivanje��5      $
��Left=�6+   $��
40,156,0,0q�6F   $	��Top=�6Z   $	��322��6r   $ prikaz��6~   $ IdPrikazivanje��6�   �� 5   
   -   5        	 ��Name$	 lblFilm��5      
����  �$
��Bold"�67   $��Film:
��6I   $
��Left=�6c   $��	40,16,0,0q�6~   $	��Top=�6�   �� 5   
   -   5        $	 lblSale��5      
����  �$
��Bold"�67   $��Sala:��6I   $
��Left=�6Y   $��	40,73,0,0q�6t   $	��Top=�6�   �� 5   
   -   5        $	 lblPrikazivanja��5      
����  �$
��Bold"�6?   $ ��Tip i vreme prikazivanja:
��6Q   $
��Left=�6z   $��
40,133,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        
 ��Name$
 
btnSacuvaj��5      $��Sacuvaj
��6%   $
��Left=�6<   $��
40,214,0,0q�6W   $	��Top=�6k   $��26��6�   $	��125��6�   $
��Bold"�6�   $��15(�6�   6�   �� 5   
   -	   5        $
 	btnOtkazi��5      $��Otkazi
��6$   $
��Left=�6?   $��237,214,0,0q�6Z   $	��Top=�6o   $��26��6�   $	��125��6�   $
��Bold"�6�   $��15(�6�   6�   5      5      