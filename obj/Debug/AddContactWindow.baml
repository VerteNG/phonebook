   M S B A M L   `   `   `  ����  Projekt_Lukasz_Motak+    %Projekt_Lukasz_Motak.AddContactWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Dodaj kontakt��5   	   $	��450��6   $	��800��6,   .��5	      �� .+�5
   
   ��  �� Orientation$ Vertical=�6   $��	0,20,0,20q�6,   .+�5      �� -   5        $��	FirstName��5      .��6(   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61    �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 5      $
 Left=�6A   $ Center=�6S   $
 None=�6g    5   "   �� 5   &   $��Imię��6,   
�������6;   5      5      	 �� Triggers	 5      P� 5      
 P� Property
 � �� �� Empty P� Value# Z 66   . �5   "   ��  �� Property � �� �� Value# [  6?   5      P� 5      
 � �� 66   Z� . �5   "   ��  � ��# [  6?   5      P� 5      
 �@J�IsKeyboardFocused . . �5   "   ��  � ��
 �����6?   5      5!      .��5"   !   5#      �� 5$      -   5        $��LastName��5$      .��6'   ��5%      1&clr-namespace:System;assembly=mscorlibSystem 5&   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61   " ��6    5'      ��%�   &	        !� 5(      $
 Left=�6A   $ Center=�6S   $
 None=�6g    5)   "   �� 5*   &   $��Nazwisko��6,   
�������6?   5,      5-      	 5.      P� 5/      
 � ��# Z 66   . �50   "   ��  � ��# [  6?   51      P� 52      
 � �� 66   Z� . �53   "   ��  � ��# [  6?   54      P� 55      
 �@J�IsKeyboardFocused . . �56   "   ��  � ��
 �����6?   57      59      .��5:   !   5;      �� 5<      -   5        $��PhoneNumber��5<       �� 	MaxLength$ 9��6)   .��6g   ��5=      1&clr-namespace:System;assembly=mscorlibSystem 5>   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61   " ��6    5?      ��%�   &	        !� 5@      $
 Left=�6A   $ Center=�6S   $
 None=�6g    5A   "   �� 5B   &   $��Numer telefonu��6,   
�������6E   5D      5E      	 5F      P� 5G      
 � ��# Z 66   . �5H   "   ��  � ��# [  6?   5I      P� 5J      
 � �� 66   Z� . �5K   "   ��  � ��# [  6?   5L      P� 5M      
 �@J�IsKeyboardFocused . . �5N   "   ��  � ��
 �����6?   5O      5Q      .��5R   !   5S      �� 5T      -   5        $��Email��5T      .��6$   ��5U      1&clr-namespace:System;assembly=mscorlibSystem 5V   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61   " ��6    5W      ��%�   &	        !� 5X      $
 Left=�6A   $ Center=�6S   $
 None=�6g    5Y   "   �� 5Z   &   $��Email��6,   
�������6<   5\      5]      	 5^      P� 5_      
 � ��# Z 66   . �5`   "   ��  � ��# [  6?   5a      P� 5b      
 � �� 66   Z� . �5c   "   ��  � ��# [  6?   5d      P� 5e      
 �@J�IsKeyboardFocused . . �5f   "   ��  � ��
 �����6?   5g      5i      .��5j   !   5k      (  "System.Windows.Controls.DatePicker  5m      -   5        $��Birthday��5m      6*   �� 5o      -   5        $��
DoneButton��5o      $��Dodaj kontakt��6'   6?   5p      �� 5q   
   -   5         ��Name$ greetingOutput��5q      5r      5s      