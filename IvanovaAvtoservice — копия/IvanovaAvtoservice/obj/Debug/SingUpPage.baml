   M S B A M L   `   `   `  ����M  IIvanovaAvtoservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:IvanovaAvtoserviceIvanovaAvtoservice  5      #    IvanovaAvtoservice.SingUpPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:IvanovaAvtoservice     5        N� Title$  
SingUpPage��5	       N� 
FontFamily$ 	Tw Cen MT)�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $+��%Наименование услуги��6   $��15(�6/   $��0��6=   $��0��6M   $
��Left=�6Z   $��Center=�6u   $��5q�6�   6�   �� 5   
   $&�� Длительность, мин��6   $��15(�6-   $��0��6;   $��1��6K   $
��Left=�6X   $��Center=�6s   $��5q�6�   6�   �� 5   
   $��ФИО клиента��6   $��15(�6'   $��0��65   $��2��6E   $
��Left=�6R   $��Center=�6m   $��5q�6�   6�   �� 5   
   $��Дата��6   $��15(�6    $��0��6.   $��3��6>   $
��Left=�6K   $��Center=�6f   $��5q�6�   6�   �� 5   
   $��Время начала:��6   $��15(�6)   $��0��67   $��4��6G   $
��Left=�6T   $��Center=�6o   $��5q�6�   6�   �� 5   
   $��1��6   $��0��6"   $��30��6/   $��20(�6;   6K   �� 5   
   $��1��6   $��1��6"   $��30��6/   $	��200��6;   $��20(�6G   6W   �� 5    
   -   5        $��TBTitle��5       $��0��6!   $��1��6.   $��30��6>   {�.  $��20(�6s   ��6J   �� *Title+6�   �� 5!   
   -   5        $��	TDuration��5!      $��1��6#   $��1��60   $��30��6@   {�.  $��20(�6x   ��6L   �� *
Duration+6�   (  "System.Windows.Controls.DatePicker  5"   
   -   5        $��	StartDate��5"   X   $��1��6   $��3��6%   $��30��62   $	��200��6>   $��15(�6J   $
��Left=�6i   6�   �� 5#   
   -   5        $��ComboClient��5#   V   $��1��6   $��2��6#   $��30��60   $	��300��6<   $��15(�6H   $
��Left=�6i   ��5%      �� 5&      .R�5'      ��  �� Orientation$ 
Horizontal=�6!   .+�5(      �� ��6    �� *	FirstName+6@   �� 5)      ��6    �� *
LastName+6?   �� 5*      ��6    �� *
Patronymic+6A   5+      5,      5.      �� 5/   
   $��1��6   $��4��6%   $ 
Horizontal=�62   .+�50      �� -   5        $��TBStart��50      $��30��6%   $	��200��61   $��20(�6=   6o   �� 51      $$��Время окончания:��6   $��15(�60   $��30��6>   $��20q�6J   6X   �� 52      -   5        $��TBEnd��52      $��30��6#   $	��200��6/   $��20(�6;   6K   53      �� 54   
   -   5        $��
SaveButton��54      $��Сохранить��6#   $��5��67   $��0��6D   $��2��6T   6�   55      56      