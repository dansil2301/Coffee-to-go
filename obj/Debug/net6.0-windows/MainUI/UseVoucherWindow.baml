   M S B A M L   `   `   `  ����G  CCoffee-to-go, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Coffee_to_goCoffee_to_go  5   	   #    Coffee_to_go.UseVoucherWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Coffee_to_go     5   	      WindowStyle#��[  5   	     � Title$  UseVoucherWindow��5	   	   $��80��6"   $	��150��6.   .��5      ��   MyBorderStyle#��[ 6   ._�5   
   � .+�5      � -   5         �Name$ NoVoucherGrid��5      $y�Visible=�6*   .+�5      �� $��You don't have a voucher��6   $��Center=�6<   $��Center=�5      $��0,0,0,15q�67   $
��Wrap=�6I   $	��140��6]    �� TextAlignment$ Center=�6i   �� 5      -   5         ��Name$ okBtn��5   0   $��22��6   $��30��6%   $��15(�6?   $��center=�5      $��Bottom=�66   $��0,0,0,5q�6Q   ��5      �� 5       �� 
TargetType" ��6*   .R�5      ��  ��Name$ buttonBorder��6%   
�������$��1q�6R    �� CornerRadius$ 10��6f   ._�5   "   � $��Center=�6'   $��Center=�6D   .+�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5   *   �� $��ok��64   $��Center=�6>   $��Center=�6[   5   '   5   #   5       �� Triggers 5      P� 5   "   	 P� Property	 �@J�IsMouseOver
 P� Value$

 True��6A   . �5   &   ��  �� 
TargetName$ buttonBorder��6-    �� Property � �� �� Value �	#FFE8E8E86]   5   #   5!      5#      5$      � 5&      -   5        $ ConfirmGrid��5&      $y�Hidden=�6(   .+�5'      �� -   5         ��Name$ voucherText��5)   ?   $&�� Your Bronze voucher will be used��5'      $��Center=�6D   $��Center=�5(      $��0,0,0,20q�67   $
��Wrap=�6I   $	��120��5)      $ Center=�6(   6?   �� 5+      -   5        $ 	acceptBtn��5+   0   $��22��6   $��30��6%   $��15(�6C   $
��Left=�5,      $��Bottom=�64   $��30,0,0,5q�6O   ��5-      �� 5.      " ��6*   .R�5/      �� $ buttonBorder��6%   
�������$��1q�6R   $ 10��6f   ._�50   "   � $��Center=�6'   $��Center=�6D   .+�51   &   �� $ 
Horizontal=�61   .+�52   *   �� $��ok��64   $��Center=�6>   $��Center=�6[   53   '   54   #   55       56      P� 57   "   	 �@J�IsMouseOver$

 True��6A   . �58   &   �� $ buttonBorder��6-    � �� �	#FFE8E8E86]   59   #   5;      5=      �� 5?      -   5        $ 
declineBtn��5?   0   $��22��6   $��55��6%   $��15(�6D   $��Right=�5@      $��Bottom=�65   $��0,0,20,5q�6P   ��5A      �� 5B      " ��6*   .R�5C      �� $ buttonBorder��6%   
�������$��1q�6R   $ 10��6f   ._�5D   "   � $��Center=�6'   $��Center=�6D   .+�5E   &   �� $ 
Horizontal=�61   .+�5F   *   �� $��decline��64   $��Center=�6C   $��Center=�6`   5G   '   5H   #   5I       5J      P� 5K   "   	 �@J�IsMouseOver$

 True��6A   . �5L   &   �� $ buttonBorder��6-    � �� �	#FFE8E8E86]   5M   #   5O      5Q      5R      5T      5U      5W      