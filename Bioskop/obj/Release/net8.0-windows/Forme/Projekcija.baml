   M S B A M L   `   `   `  ���� B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop      Bioskop.Projekcija   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Bioskop       � Title$  
Projekcija��$	��300��$	��450��.��� -    �Name$ frmProjekcija������  j� Stretch$
 None=� �� ImageSource$4 .C:\Users\Marko\Desktop\pozadinaZaposleniii.jpg�� j� 
AlignmentY$ Center=� j� 
AlignmentX$ Right=�.+��� -    ��Name$ cbFilm��$
��Left=�$��	40,39,0,0q�$	��Top=�$	��322�� �� DisplayMemberPath$ Naslov�� �� SelectedValuePath$ IdFilm���� -   $ cbSale��$
��Left=�$��	40,99,0,0q�$	��Top=�$	��322��$ IdSale��$ IdSale���� -   $ cbPrikazivanje��$
��Left=�$��
40,156,0,0q�$	��Top=�$	��322��$ prikaz��$ IdPrikazivanje���� -   	 ��Name$	 lblFilm��
����  �$
��Bold"�$��Film:
��$
��Left=�$��	40,16,0,0q�$	��Top=��� -   $	 lblSale��
����  �$
��Bold"�$��Sala:��$
��Left=�$��	40,73,0,0q�$	��Top=��� -   $	 lblPrikazivanja��
����  �$
��Bold"�$ ��Tip i vreme prikazivanja:
��$
��Left=�$��
40,133,0,0q�$	��Top=��� -   
 ��Name$
 
btnSacuvaj��$��Sacuvaj
��$
��Left=�$��
40,214,0,0q�$	��Top=�$��26��$	��125��$
��Bold"�$��15(��� -	   $
 	btnOtkazi��$��Otkazi
��$
��Left=�$��237,214,0,0q�$	��Top=�$��26��$	��125��$
��Bold"�$��15(�