   M S B A M L   `   `   `  ����G  CCoffee-to-go, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Coffee_to_goCoffee_to_go  5   	   #    Coffee_to_go.GetVoucherWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Coffee_to_go     5   	      WindowStyle#��[  5   	     � Title$  GetVoucherWindow��5	   	   $��80��6"   $	��150��6.   .��5      ��   MyBorderStyle#��[ 6   ._�5   
   � .+�5      � -   5         �Name$ NotEnoughGrid��5      $y�Visible=�6*   .+�5      �� $>��8Coffee streak is too small or you already have a voucher��6   $��Center=�6\   $��Center=�5      $��0,0,0,25q�67   $
��Wrap=�6I   $	��140��6]    �� TextAlignment$ Center=�6i   �� 5      -   5         ��Name$ okBtn��5   0   $��22��6   $��30��6%   $��15(�6?   $��center=�5      $��Bottom=�66   $��0,0,0,5q�6Q   ��5      �� 5       �� 
TargetType" ��6*   .R�5      ��  ��Name$ buttonBorder��6%   
�������$��1q�6R    �� CornerRadius$ 10��6f   ._�5   "   � $��Center=�6'   $��Center=�6D   .+�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5   *   �� $��ok��64   $��Center=�6>   $��Center=�6[   5   '   5   #   5       �� Triggers 5      P� 5   "   	 P� Property	 �@J�IsMouseOver
 P� Value$

 True��6A   . �5   &   ��  �� 
TargetName$ buttonBorder��6-    �� Property � �� �� Value �	#FFE8E8E86]   5    #   5"      5$      5%      � 5'      -   5        $ ConfirmGrid��5'      $y�Hidden=�6(   .+�5(      �� -   5         ��Name$ voucherText��5*   >   $!��You will get Bronze voucher��5(      $��Center=�6?   $��Center=�5)      $��0,0,0,20q�67   $
��Wrap=�6I   $��90��5*      $ Center=�6'   6>   �� 5,      -   5        $ 	acceptBtn��5,   0   $��22��6   $��30��6%   $��15(�6C   $
��Left=�5-      $��Bottom=�64   $��30,0,0,5q�6O   ��5.      �� 5/      " ��6*   .R�50      �� $ buttonBorder��6%   
�������$��1q�6R   $ 10��6f   ._�51   "   � $��Center=�6'   $��Center=�6D   .+�52   &   �� $ 
Horizontal=�61   .+�53   *   �� $��ok��64   $��Center=�6>   $��Center=�6[   54   '   55   #   56       57      P� 58   "   	 �@J�IsMouseOver$

 True��6A   . �59   &   �� $ buttonBorder��6-    � �� �	#FFE8E8E86]   5:   #   5<      5>      �� 5@      -   5        $ 
declineBtn��5@   0   $��22��6   $��55��6%   $��15(�6D   $��Right=�5A      $��Bottom=�65   $��0,0,20,5q�6P   ��5B      �� 5C      " ��6*   .R�5D      �� $ buttonBorder��6%   
�������$��1q�6R   $ 10��6f   ._�5E   "   � $��Center=�6'   $��Center=�6D   .+�5F   &   �� $ 
Horizontal=�61   .+�5G   *   �� $��decline��64   $��Center=�6C   $��Center=�6`   5H   '   5I   #   5J       5K      P� 5L   "   	 �@J�IsMouseOver$

 True��6A   . �5M   &   �� $ buttonBorder��6-    � �� �	#FFE8E8E86]   5N   #   5P      5R      5T      5V      5W      5Y      