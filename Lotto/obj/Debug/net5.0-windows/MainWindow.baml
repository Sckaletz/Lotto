   M S B A M L   `   `   `  ����@  <Lotto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LottoLotto  5   	       Lotto.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lotto     5   	     � Title$  Lotto��5   	   $	��685��6   $
��1200��6$    � 
ResizeMode$ NoResize=�61   ���#B20000.��5	      � $��0,0,0,0q�6   .+�5
   
   �� -   5        $��canvas��5
      $��Stretch=�6   $��Stretch=�6=   �� 5   
   $��50��6   $��	10,10,0,0q�6   $
��Left=�6/   $	��Top=�6J   $��/img/lotto-white.png��6b   �� 5   
   $	��145��6   $��	0,279,0,0q�6   $	��Top=�60   $��/img/joker.png��6H   �� 5   
   $��Vælg antal kuponer��6   $��Center=�6-   $��	0,188,0,0q�6J   $	��Top=�6]   
�������$
��Bold"�6�   $��34��6�   $	��202��6�   $��18(�6�   	� 5   
   -   5         	�Name$ jokerJa��5      $��Ja��6'   $
��Left=�64   $��392,379,0,0q�6O   $	��Top=�6d   $��77��6|   $��28��6�   $��20(�6�   $
��Bold"�6�   
�������6�   	� 5   
   -   5        $ jokerNej��5      $	��Nej��6(   $��776,378,0,0q�66   $	��Top=�6K   $
��Left=�6c   $	��100��6~   $��29��6�   $��20(�6�   $
��Bold"�6�   
�������6�   �� 5   
   $
��Left=�6C   $��706,188,0,0q�6^   $	��Top=�6s   $��32��6�   
�������$
��Bold"�6�   $��18(�6�   ��6   �� *Value+ �� ElementName$ kuponSlider��6�   �� 5   
   -   5         ��Name$ mineKuponer��5      $��	Vis kupon��6&   $��0,31,0,0q�6:   $��40��6L   $	��Top=�6X   $��Center=�6p   $	��202��6�   6�   �� 5   
   -   5        $
 exit��5      $��Afslut��6   $
��Left=�60   $��40��6K   $��
36,599,0,0q�6W   $	��Top=�6k   $��98��6�   6�   �� 5   
   -   5         ��Name$ kuponSlider��5      $��36,237,34,0q�6&   $	��Top=�6;    �� TickPlacement$ BottomRight=�6S    � SmallChange$ 1Q�6o    �� AutoToolTipPlacement$ TopLeft=�6   	 � Minimum$	 1Q�6�   
 �� IsSnapToTickEnabled$

 True��6�   �� 5   
   -   5        $ 	printKnap��5      $��	Lav kupon��6$   $��526,495,528,0q�68   $��30��6O   $	��Top=�6[   6s   �� 5   
   -   5         ��Name$ 	doneLabel��5      $�� ��6#   $��Center=�6.   $��	0,530,0,0q�6K   $	��Top=�6^   $��48��6v   $
��Bold"�6�   
�������6�   5      5      