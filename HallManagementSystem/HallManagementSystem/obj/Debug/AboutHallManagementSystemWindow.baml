   M S B A M L   `   `   `  ����  HallManagementSystem:    4HallManagementSystem.AboutHallManagementSystemWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   K    � 
ResizeMode$ CanMinimize=�5   @    � Title$ VSASH Window UI��5   	   $	��575��6!   $	��753��6.    � 	Resources 5         DiningStyle �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%  &	        �� 5   
   " ��6$   .�5      ��  � ��
 �����62   �� 5       � ��
 �����62   �� 5	       � ��$ Segoe UI)�62    5
      P� 5       �@J�IsMouseOver	 . . �5      ��  � ��
 �   �63   5      5      5      .��5      � .+�5   
   �� .+�5      � 
 � RowDefinitions
 5      �� 5      $��20 �6$   �� 5      $��20 �6$   �� 5      $��50 �6$   �� 5      $��20 �6$   �� 5      $��50 �6$   �� 5      $��20 �6$   �� 5      $��50 �6$   �� 5      $��20 �6$   �� 5      $��50 �6$   �� 5      $��20 �6$   �� 5      $��50 �6$   �� 5       $��15 �6$   �� 5!      $��25 �6$   �� 5"      $��10 �6$   �� 5#      $��25 �6$   �� 5$      $��10 �6$   �� 5%      $��25 �6$   �� 5&      $��10 �6$   �� 5'      $��25 �6$   �� 5(      $��20 �6$    � ColumnDefinitions 5*      �� 5+      $��20 �6'   �� 5,      $��60 �6'   �� 5-      $��80 �6'   �� 5.      $��20 �6'   �� 5/      $	��110 �6'   �� 50      $��20 �6'   �� 51      $	��150 �6'   �� 52      $��20 �6'   �� 53      $	��110 �6'   �� 54      $��20 �6'   �� 55      $��80 �6'   �� 56      $��60 �6'   �� 57      $��20 �6'   .+�5;      �� $��2��6   $��4��5<      $��Floor4��5=      
��� E��
�������$��20(�5@      �� 5B      $��2��6   $��8��5C      $��Floor 4��5D      
��� ���
�������$��20(�5G      �� 5I      $��4��6   $��4��5J      $��Floor 3��5K      ���	#FFF05847
�������$��20(�5N      �� 5P      $��4��6   $��8��5Q      $��Floor 3��5R      ���	#FF597FF1
�������$��20(�5U      �� 5W      $��6��6   $��4��5X      $��Floor 2��5Y      ���	#FF597FF1
�������$��20(�5\      �� 5^      $��6��6   $��8��5_      $��Floor 2��5`      ���	#FFF05847
�������$��20(�5c      �� 5f      $��8��6   $��4��5g      $��Floor 1��5h      
��� ���
�������$��20(�5k      �� 5n      $��8��6   $��8��5o      $��Floor 1��5p      
��� E��
�������$��20(�5s      �� 5u      $��6��6   $��6��5v      $��Mosque��5w      ���#7EC350
�������$��20(�5z      �� 5|      $��4��6   $��6��5}      $��Hall Dining��5~      ���#7EC350
�������$��20(�5�      �� 5�      $��1��6   $��2��5�      $��Block A��5�      ���#4D5251
�������$��20(�5�      $��9��5�      �� 5�      $��1��6   $��10��5�      $��Block B��5�      ���#4D5251
�������$��20(�5�      $��9��5�      �� 5�      $��10��6   $!��At a glance VSASH Outerface��5�      
���� ��$��12��5�      $��20(�5�       �� TextAlignment$ Center=�5�      
�������$��Normal"�5�      $��0,10,5,0q�5�      �� 5�      -   5        $��
ExitButton��5�      #��[  5�      $��18��5�      $��10��5�      $
��Exit��5�      
�������5�      �� 5�      $��12��6   $��2��5�      $��Total Blocks��5�      $
 Left=�5�      $��15(�5�      #��� ��5�      $��Normal"�5�      �� 5�      -   5        $��totalBlocksTextBlock��5�      $��12��5�      $��4��5�      $
 Left=�5�      $��16(�5�      
���<��$��Normal"�5�       J� RenderTransformOrigin$ 0.5,0.5&�60   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�       �� Angle$ 1.595Q�6.   T� 5�      5�      5�      �� 5�      -   5        $��totalFloorsTextBlock��5�      $��12��5�      $��8��5�      $
 Left=�5�      $��14(�5�      
���<��$��Normal"�5�      �� 5�      -   5        $��totalRoomsTextBlock��5�      $��14��5�      $��4��5�      $
 Left=�5�      $��14(�5�      
���<��$��Normal"�5�      �� 5�      -   5        $��TotalSeatTextBlock��5�      $��14��5�      $��8��5�      $
 Left=�5�      $��14(�5�      
���<��$��Normal"�5�      �� 5�      $��14��6   $��6��5�      $��Total Seats��5�      #��� ��5�      $��15(�5�      $ Center=�5�      $��Normal"�5�      $��0,0,63,0q�5�      �� 5�      $��14��6   $��2��5�      $��Total Rooms��5�      $��15(�5�      $ Center=�5�      #��� ��5�      $��Normal"�5�      $��2��60   $��0,0,10,0q�6D   �� 5�      $��12��6   $��6��5�      $��Total Floors��5�      $��15(�5�      $ Center=�5�      #��� ��5�      $��Normal"�5�      $��0,0,63,0q�5�      �� 5�      $��16��6   $��6��5�      $��Total Available Seats��5�      #��� ��5      $��15(�5     $ Center=�5     $��Normal"�5     $��0,0,10,0q�5     �� 5     -   5        $!��TotalAvailableSeatTextBlock��5     $��16��5     $��8��5     
���<��$��15(�5
     $ Center=�5     $��Normal"�5     $
��25,0q�60   5     5     5     5     