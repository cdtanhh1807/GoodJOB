   M S B A M L   `   `   `  ����B  >GoodJOB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GoodJOBGoodJOB  5          GoodJOB.CompanyChat   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:GoodJOB     5        � 	Resources  5	       �� 
TargetType   
btnCheckCV �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName��%o  &	        �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $��0q�61   ���	#FF284241
������ ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $	 border��6)    � �� �	#FFDFD5C86S   5      P� 5       � {�$ False��6;   . �5   "   �� $	 border��6)    � �� �	#FFDFD5C86S   5      P� 5       � ��$
 True��6;   . �5   "   �� $	 border��6)    � �� �	#FFC2B9AE6S   5      5      5      5      5       .��5!      � -   5        
 � ColumnDefinitions
 5"   
   �� 5#      �� 5$      .+�5&   
   � $��0��6   ���	#FF284241.+�5'      �� $��Hidden=�6   $��	0,23,0,26q�6@   .��5(      �� -   5         ��Name$ stack��5(      5*      5+      5,      � 5-   
   $��1��6   ���#F9F2e8.+�5.      �� -   5        $ bd��5.      ���	#FF284241 J� Opacity$	 0.1Q�68   $��19,56,19,81q�6F   6]   �� 5/      -   5        $ bdInput��5/      
������ $��1q�6?   ���	#FF284241$��19,444,53,10q�6k   ._�50      �� -   5         ��Name$ txbInput��50      $��Nhập để chat...��6,    �� 	MaxLength$
 1000��6C    �� AcceptsReturn$
 True��6T   $��0q�6i   
������  �� 
CaretBrush �	#FF284241$��4q�6�   $��15(�6�    �� TextWrapping$
 Wrap=�6�   6!  51      �� 52      -   5        $ bdSend��52      
������ $��1q�6>   ���	#FF284241$��372,444,19,10q�6j   ._�53      �� -   5         ��Name$ btnSend��53      #��[  6*   $	��▲��6N   $��Black"�6Z   $��20(�6m   $��0,0,0,37q�6{   $��27��6�   $��Bottom=�6�   6�   54      �� 55      -   5         ��Name$ txbName��55      ���	#FF284241$��20(�6@   $
��Bold"�6N   $
��Left=�6`   $��	19,14,0,0q�6{   $
��Wrap=�6�   $	��Top=�6�   �� 56      -	   5         ��Name$	 scr��56      $��Visible=�6(   $��19,65,19,88q�6N   .��57      �� -
   5        $ 	stackChat��57      62   58      �� 59      ���#F9F2e8$��0q�6*   $��364,445,49,11q�6>   6W   5:      5;      5<      