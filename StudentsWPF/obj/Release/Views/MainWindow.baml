   M S B A M L   `   `   `  ����   StudentsWPF"    StudentsWPF.Views.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   $	��700��$	��400��$	��700��$	��400��$	��700��$	��400��  � 
ResizeMode$  	CanResize=� � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value��%�   '��       �� " �� P�  �@��AlternationIndex$ 0��. ��� 	 � ��

 �����P�  �@��AlternationIndex$ 1��. ��� 	 � ��

 �����.��� .+��� $��50��$��40��$��619,281,0,0q�$
��Left=�$	��Top=�$��Delete��|�.  ���� *RemoveCommand+�� $��50��$��40��$��564,281,0,0q�$
��Left=�$	��Top=�$��Update��|�.  ���� *EditCommand+�� $��50��$��40��$��509,281,0,0q�$
��Left=�$	��Top=�$��Insert��|�.  ���� *
AddCommand+�� $��79��$��40��$��425,281,0,0q�$
��Left=�$	��Top=�$��Save to XML��|�.  ���� *SaveCommand+�� $	��659��$	��266��$��	10,10,0,0q�$
��Left=�$	��Top=� �� AlternationCount$ 2������ *StudentsesCollection+ �� SelectedItem �� *SelectedStudents+���� .R��  � ColumnDefinitions �� ��  � RowDefinitions �� �� �� .+��� $��0��$��0��$��Name:���� $��1��$��0��$
��Age:���� $��2��$��0��$��Gender:���� $��0��$��2������ *Name+�� $��1��$��2������ *	StringAge+�� $��2��$��2������ *Gender+