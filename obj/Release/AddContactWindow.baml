   M S B A M L   `   `   `  ����   Projekt_Lukasz_Motak+    %Projekt_Lukasz_Motak.AddContactWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 
ResizeMode$  NoResize=� � Title$ Dodaj kontakt��$	��450��$	��800��.���� .+���  �� Orientation$ Vertical=�$��	0,20,0,20q�.+��� -   $��	FirstName��.����O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib      �� 
TargetType" �� �� 	Resources    CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%R   &	        !� $
 Left=�$ Center=�$
 None=� �� $��Imię��
�������	 �� Triggers	 P� 
 P� Property
 � �� �� Empty P� Value# Z . ���  �� Property � �� �� Value# [  P� 
 � �� Z� . ���  � ��# [  P� 
 �@J�IsKeyboardFocused . . ���  � ��
 �����.���� -   $��LastName��.����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%U   &	        !� $
 Left=�$ Center=�$
 None=� �� $��Nazwisko��
�������	 P� 
 � ��# Z . ���  � ��# [  P� 
 � �� Z� . ���  � ��# [  P� 
 �@J�IsKeyboardFocused . . ���  � ��
 �����.���� -   $��PhoneNumber�� �� 	MaxLength$ 9��.����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%[   &	        !� $
 Left=�$ Center=�$
 None=� �� $��Numer telefonu��
�������	 P� 
 � ��# Z . ���  � ��# [  P� 
 � �� Z� . ���  � ��# [  P� 
 �@J�IsKeyboardFocused . . ���  � ��
 �����.���� -   $��Email��.����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%R   &	        !� $
 Left=�$ Center=�$
 None=� �� $��Email��
�������	 P� 
 � ��# Z . ���  � ��# [  P� 
 � �� Z� . ���  � ��# [  P� 
 �@J�IsKeyboardFocused . . ���  � ��
 �����.��(  "System.Windows.Controls.DatePicker  -   $��Birthday���� -   $��
DoneButton��$��Dodaj kontakt���� -    ��Name$ greetingOutput��