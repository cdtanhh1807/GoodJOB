   M S B A M L   `   `   `  ����B  >GoodJOB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GoodJOBGoodJOB  5          GoodJOB.SeekerChatUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:GoodJOB     5        � 	Resources  5	       �� 
TargetType   
btnCheckCV �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName��%i  &	        �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $��0q�61   ���#F9F2e8
������ ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $	 border��6)    � �� �#516d6b6S   5      P� 5       � {�$ False��6;   . �5   "   �� $	 border��6)    � �� �#516d6b6S   5      P� 5       � ��$
 True��6;   . �5   "   �� $	 border��6)    � �� �	#FF3B53516S   5      5      5      5      5       .��5!      � -   5        
 �Name$
 mainGrid��5!       � ColumnDefinitions 5"   
   �� 5#      �� 5$      .+�5&   
   � $��0��6   ���#F9F2e8.+�5'      �� $��Hidden=�6   $��	0,23,0,26q�6@   .��5(      �� -   5         ��Name$ stack��5(      5*      5+      5,      � 5-   
   $��1��6   ���	#FF284241.+�5.      �� -   5        $ bd��5.      ���#F9F2e8 J� Opacity$	 0.1Q�66   $��19,56,19,81q�6D   6[   �� 5/      -   5        $ bdInput��5/      
������ $��1q�6?   ���#F9F2e8$��19,444,53,10q�6i   ._�50      �� -   5         ��Name$ txbInput��50      ���#F9F2e8$��Nhập để chat...��6A    �� 	MaxLength$
 1000��6X    �� AcceptsReturn$
 True��6i   $��0q�6~   
������  �� 
CaretBrush �#F9F2e8$��4q�6�   $��15(�6�    �� TextWrapping$
 Wrap=�6�   66  51      �� 52      -   5        $ bdSend��52      
������ $��1q�6>   ���#F9F2e8$��372,444,19,10q�6h   ._�53      �� -   5         ��Name$ btnSend��53      #��[  6*   ���#F9F2e8$	��▲��6c   $��Black"�6o   $��20(�6�   $��0,0,0,37q�6�   6�   54      �� 55      ���	#FF284241$��370,445,51,11q�6,   6E   �� 56      -   5         ��Name$ txbName��56      ���#F9F2e8$��20(�6>   $
��Bold"�6L   $
��Left=�6^   $��	19,14,0,0q�6y   $
��Wrap=�6�   $	��Top=�6�   �� 57      -	   5         ��Name$	 scr��57      $��Visible=�6(   $��19,65,19,88q�6N   .��58      �� -
   5        $ 	stackChat��58      62   59      5:      5;      5<      