   M S B A M L   `   `   `  ����  StudentsWPF"    StudentsWPF.Views.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6B   $	��550��5      $	��400��5      $	��550��5	      $	��400��5
        � 
ResizeMode$  	CanResize=�5       � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=�5       � WindowState$ Normal=�5      
���������6   Z�  � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value   StoryboardListbox �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value  StoryboardStudentsImage��%�  '��       &	  �     &	 u    �� 5   
   " ��6    5      P� 5       �@��AlternationIndex$ 0��6C   . �5      �� 	 � ��

 �����63   5      P� 5       �@��AlternationIndex$ 1��6C   . �5      �� 	 � ��

 �����63   5      5      �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ button��6_   ..�5      i� $ 0:0:1��6)   # Z 69   5      T� 5      $ (UIElement.Visibility)�6,   $ button1��6_   ..�5      i� $ 0:0:1��6)   # Z 69   5       T� 5!      $ (UIElement.Visibility)�6,   $ button2��6_   ..�5"      i� $ 0:0:1��6)   # Z 69   5#      T� 5$      $ (UIElement.Visibility)�6,   $ button3��6_   ..�5%      i� $ 0:0:1��6)   # Z 69   5&      T� 5'      $ (UIElement.Visibility)�6,   $ listBox��6_   ..�5(      i� $ 0:0:1��6)   # Z 69   5)      5*      �� 5+   
   6   5,       � Triggers 5-      :� 5.   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5/      �� #��[ 6   �� 50      #��[  6   51      .��53      � $	��544��6   $	��367��6   $
��Left=�6$   $	��Top=�6?   $��	0,0,-8,-8q�6W    � ColumnDefinitions 54   
   �� 55      $��0* �6   �� 56      .+�58   
   �� -   5         ��Name$ button��58      $��50��59      $��40��5:      $��471,304.5,0,0q�5;      $
��Left=�5<      $	��Top=�5=      $��Delete��5?      |�.  $��1��5@      ��5>      �� *RemoveCommand+5@      �� 5A   
   -   5        $ button1��5A      $��50��5B      $��40��5C      $��417.5,304.5,0,0q�5D      $
��Left=�5E      $	��Top=�5F      $��Update��5H      |�.  $��1��5I      ��5G      �� *EditCommand+5I      �� 5J   
   -   5        $ button2��5J      $��50��5K      $��40��5L      $��364,304,0,0q�5M      $
��Left=�5N      $	��Top=�5O      $��Insert��5Q      |�.  $��1��5R      ��5P      �� *
AddCommand+5R      �� 5S   
   -   5        $ button3��5S      $��80��5T      $��40��5U      $��278,304,0,0q�5V      $
��Left=�5W      $	��Top=�5X      $��Save to XML��5Z      |�.  $��1��5[      ��5Y      �� *SaveCommand+5[      �� 5\   
   -   5         ��Name$ listBox��5\      $	��511��5]      $	��266��5^      $��10,17.5,0,0q�5_      $
��Left=�5`      $	��Top=�5a       �� AlternationCount$ 2��5b      $��1��5d   7   ��5c      �� *StudentsesCollection+ �� SelectedItem 5d      �� *SelectedStudents+��5e      �� 5f      .R�5g      �  5h      �� 5i      �� 5j       � RowDefinitions 5l      �� 5m      �� 5n      �� 5o      .+�5q      �� $��0��5r      $��0��5s      $��Name:��5t      �� 5u      $��1��5v      $��0��5w      $
��Age:��5x      �� 5y      $��2��5z      $��0��5{      $��Gender:��5|      �� 5}      $��0��5~      $��2��5      ��5�      �� *Name+�� 5�      $��1��5�      $��2��5�      ��5�      �� *	StringAge+�� 5�      $��2��5�      $��2��5�      ��5�      �� *Gender+5�      5�      5�      5�      5�      