   M S B A M L   `   `   `  ����  HallManagementSystem/    )HallManagementSystem.StudentDetailsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   A    � 
ResizeMode$ CanMinimize=�6f    � Title$ Student Details Window UI��5   	   $	��450��6+   $	��853��68    � 	Resources 5         DiningStyle �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value  MyWaterMarkStyle
 �� 
TargetType ��Name ��Name
 � Tag �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName��%�  &	        &	     �� 5   
   " ��6$   .�5      ��  � ��
 �����62   �� 5       � ��
 �����62   �� 5	       � ��$ Segoe UI)�62    5
      P� 5       �@J�IsMouseOver	 . . �5      ��  � ��
 �   �63   5      5      �� 5   
   " ��6)   .�5      ��  � �� 5      �� 5      "
 ��6&   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�5   %   �� 5      $ PART_ContentHost��6+   $��5,0,0,0q�5   +   $��Center=�5   +   �� 5      $ WaterMarkLabel��5   $   $��5,0,0,0q�5   $   #��z 5   $   $��Center=�5    $   $y�	Collapsed=�5!   $   
�������$��Italic)�5#   $   5%       5&      ]� 5'       5(   "   �� 5)   &    � ��$  ��5*   0   ./�5,   "   �� $ WaterMarkLabel��5-   )    � y�$ Visible=�5.   )   5/      P� 50       � {�	 .  . �52   "   ��  � ��
 �iii�53   )   54      56      58      59      5:      .��5;      �  � RowDefinitions 5<      �� 5=      $��40 �6$   �� 5>      $��10 �6$   �� 5?      $	��320 �6$   �� 5@      $��10 �6$   �� 5A      $��25 �6$   �� 5B      $��20 �6$    � ColumnDefinitions 5E      �� 5F      $��10 �6#   �� 5G      $	��700 �6#   �� 5H      $��10 �6#   �� 5I      $��45 �6#   �� 5J      $��10 �6#   �� 5K      $��45 �6#   �� 5L      $��10 �6#   .+�5O   
   �� $��0��5P      $��Segoe UI Light)�5Q      $1��+    Student Details Information At a Glance��5R       �� TextAlignment$
 Left=�5S      $��22(�5T      $��SemiBold"�5U      
���� ��$��7��5W      $��0,0,-8,0q�5X      
�������5Z      &   System.Windows.Controls.DataGrid  5\      -   5        $��
mydataGrid��5a      $��2��5\      $��1��5]         AutoGenerateColumns .  $	��300��5_      $
��Left=�5`      $	��Top=�5b      $	��798��5d      $��5��5e      $��	10,10,0,0q�5f      ��5c      ��  �� Path$ DataBind�   Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5l   %      MinWidth$ 50Q�5m   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5n   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5k   -   �� $ StudentName�5o   %     5q      $ 
Department��5r   %   $ 50Q�5s   %   $ * 5t   %    .  5q   -   �� $ DepartmentName�5u   %     5w      $ Session��5x   %   $ 50Q�5y   %   $ * 5z   %    .  5w   -   �� $ StudentSessionName�5{   %     5}      $ District��5~   %   $ 50Q�5   %   $ * 5�   %    .  5}   +   �� $ StudentDistrict�5�   %     5�      $ 	Seat Code��5�   %   $ 50Q�5�   %      
Foreground
 �  ��$ * 5�   %    .  5�   %   �� $ GeneratedSeatCode�5�   %     5�      $ Roll No��5�   %   $ 50Q�5�   %   $ * 5�   %    .  5�   %   �� $ StudentRollNo�5�   %     5�      $ Allotment Date��5�   %   $ 50Q�5�   %   $ * 5�   %    .  5�   -   �� $ AllotmentDate�5�   %     5�      $ Expiery Date��5�   %   $ 50Q�5�   %   $ * 5�   %    .  5�   %   �� $ ExpieryDate�5�   %     5�      $ Phone No��5�   %   $ 50Q�5�   %   $ * 5�   %   
 �  �� .  5�   %   �� $ StudentPhoneNo�5�   %   5�      �� 5�      -   5        $��DeleteButton��5�      #��[  5�      $��4��5�      $��3��5�      $��Delete��5�      $��3��5�      $��27,0,0,0q�5�      �� 5�   
   -   5        $��searchTextBox��5�      #��[ 5�      $��0��5�      $��1��5�      $% Search By Phone No or Seat Code��5�      $��5��5�      $��	587,8,0,6q�5�      5�      5�      