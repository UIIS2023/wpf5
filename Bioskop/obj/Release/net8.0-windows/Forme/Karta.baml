   M S B A M L   `   `   `  ���� B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop      Bioskop.Karta   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Bioskop       � Title$  Karta��$	��350��$	��450��.��� -    �Name$ frmKarta������  j� Stretch$
 None=� �� ImageSource$4 .C:\Users\Marko\Desktop\pozadinaZaposleniii.jpg�� j� 
AlignmentY$	 Top=� j� 
AlignmentX$ Right=�.+��� $.��(C:\Users\Marko\Desktop\pozadinaKarta.png��$��312,44,5,79q� J� Opacity$	 0.8Q��� -    ��Name$ lblZaposleni��
�������$
��Bold"�$��Zaposleni:
��$
��Left=�$��	20,37,0,0q�$	��Top=��� -   $ lblGledalac��
����  �$
��Bold"�$��Gledalac:
��$
��Left=�$��	25,82,0,0q�$	��Top=��� -   $ lblProjekcija��
����  �$
��Bold"�$��Projekcija:
��$
��Left=�$��
20,129,0,0q�$	��Top=��� -   $ lblCena��$��Cena:
��
����  �$
��Bold"�$
��Left=�$��
47,176,0,0q�$	��Top=��� -   $ lblBrojSedista��
����  �$
��Bold"�$��Broj sedista:
��$
��Left=�$��
11,223,0,0q�$	��Top=��� -    ��Name$ 
btnSacuvaj��$��Sacuvaj��$
��Left=�$��
50,280,0,0q�$	��Top=�$	��100��$��25��$��15(�$
��Bold"��� -   $ 	btnOtkazi��$��Otkazi��$
��Left=�$��207,280,0,0q�$	��Top=�$	��100��$��25��$��15(�$
��Bold"��� -	   	 ��Name$	 cbZaposleni��$
��Left=�$��	89,42,0,0q�$	��Top=�$	��218��
 �� DisplayMemberPath$
 	zaposleni�� �� SelectedValuePath$ IdZaposleni���� -
   $	 
cbGledalac��$
��Left=�$��	89,85,0,0q�$	��Top=�$	��218��$
 gledalac��$ 
IdGledaoca���� -   $	 cbProjekcija��$
��Left=�$��
89,133,0,0q�$	��Top=�$	��218��$
 prikazivanje��$ IdProjekcije���� -    ��Name$ txtCena��$
��Left=�
����  �
�������
���   �$��1q�$��
89,180,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��218��$��22���� -   $ txtBrojSedista��$
��Left=�
����  �
�������
���   �$��1q�$��
89,227,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��109��$��22���� -   $��Odabir sedista��$
��Left=�$��207,215,0,0q�$	��Top=�$��42��$	��104��$��15(�$
��Bold"�