   M S B A M L   `   `   `  ����\  XAHPA 19 - The Middle Name Problem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AHPA_19___The_Middle_Name_Problem!AHPA_19___The_Middle_Name_Problem  5   	   2    ,AHPA_19___The_Middle_Name_Problem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:AHPA_19___The_Middle_Name_Problem     5   	     � Title$  The Middle Name Problem��5   	   $	��450��6)   $	��800��66    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Copy��5      6_     5   
   -   5        $ ApplicationCommands.Paste��5      6`   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��5* �6   6,   �� 5      $��* �6   6+   �� 5      $��5* �6   6,   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5    
   �� -   5         ��Name$ tbSource��5       $��1��6$   $��1��64   $��10q�6A   6O   �� 5!   
   -   5        $ tbDestination��5!       �� 
IsReadOnly . $��3��6;   $��1��6K   $��10q�6X   6f   �� 5#   
   $
��Copy��6   $��1��6    $��3��60   $��ApplicationCommands.Copy��6=   $��10q�6`   6n   �� 5$   
   $��Paste��6   $��3��6!   $��3��61   $��ApplicationCommands.Paste��6>   $��10q�6b   6p   �� 5%   
   -   5         ��Name$ btnClear��5%      $��Clear��6#   $��3��63   $��4��6C   $��10q�6P   6u   5'      5(      