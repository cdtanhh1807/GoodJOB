   M S B A M L   `   `   `  ����B  >GoodJOB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GoodJOBGoodJOB  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35iFclr-namespace:System.Windows.Media.Animation;assembly=PresentationCoreSystem.Windows.Media.Animation 5   	   \ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls 5   	       GoodJOB.MainWindow   5   	   e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:GoodJOB     5   	   XmediaFclr-namespace:System.Windows.Media.Animation;assembly=PresentationCore     5   	   YcontrolsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework     5   	   -   5          �Name$  MyMainWindow��5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � Title$  ��5   	   $	��450��6   $	��800��6   z�5      �� 5   
    �� ScaleX$ 1Q�6    �� ScaleY$ 1Q�6$    J� RenderTransformOrigin 5      8� 5   
    8� X$	 0.5Q�6   	 8� Y$		 0.5Q�6   
 � 	Resources
 5         WindowLoadAnimation �� 
TargetName �� TargetProperty W� From	 W� To g� Duration �� 
TargetType  
btnWDLogin �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName  btnWDSignUp  btnWDForget��%�  &	        &	 .    &	 �    &	 �    �� 5   
   .��5      W� $ MyMainWindow��6   $- 'RenderTransform.(ScaleTransform.ScaleX)�5       05       16#   $ 0:0:0.4D�6*   W� 5      $ MyMainWindow��6   $- 'RenderTransform.(ScaleTransform.ScaleY)�5       05       16#   $ 0:0:0.4D�6*   5      �� 5    
   " ��6   .�5!      ��  � �� 5"      �� 5#      " ��6&   .R�5$      �� $ border��6!   ���#F9F2e8$��0q�6F   ._�5%      �� $��Center=�6/   $��Center=�6L   5&       5'      P� 5(       �@J�IsMouseOver$
 True��6=   . �5)   "   �� $ border��6)    � �� �	#FFDFD5C86S   5*      P� 5+       � {�$ False��6;   . �5,   "   �� $ border��6)    � �� �	#FFDFD5C86S   5-      P� 5.       � ��$
 True��6;   . �5/   "   �� $ border��6)    � �� �	#FFC2B9AE6S   50      52      54      55      �� 56   
   " ��6   .�57      ��  � �� 58      �� 59      " ��6&   .R�5:      �� $ border��6!   $��1q�61   ���#F9F2e8
������ ._�5;      �� $��Center=�6/   $��Center=�6L   5<       5=      P� 5>       �@J�IsMouseOver$
 True��6=   . �5?   "   �� $ border��6)    � �� �#516d6b6S   5@      P� 5A       � {�$ False��6;   . �5B   "   �� $ border��6)    � �� �#516d6b6S   5C      P� 5D       � ��$
 True��6;   . �5E   "   �� $ border��6)    � �� �	#FF3B53516S   5F      5H      5J      5K      �� 5L   
   " ��6   .�5M      ��  � �� 5N      �� 5O      " ��6&   .R�5P      �� $ border��6!   $��0q�61   
������ ._�5Q      �� $��Center=�6/   $��Center=�6L   5R       5S      P� 5T       �@J�IsMouseOver$
 True��6=   . �5U   "   ��  � �� �	#FFE8DDCE6?   5V      P� 5W       �@J�IsMouseOver$ False��6=   . �5X   "   ��  � �� �#F9F2e86?   5Y      P� 5Z       �@J�IsMouseOver$
 True��6=   . �5[   "   ��  � ��
 ���� 6?   5\      P� 5]       � ��$
 True��6;   . �5^   "   ��  � �� �	#FFD6C3AA6?   5_      5a      5c      5d      5e      .��5f      �  � ColumnDefinitions 5g   
   �� 5h      6!   �� 5i      $	��300 �6   6-   .+�5l   
   � $��0��6   ���#F9F2e8.+�5m      �� $
��Left=�6   $	��433��6/   $	��Top=�6<   $	��500��6T   $��/Picture/Asset 3.png��6`   5o      � 5q   
   $��1��6   ���	#FF284241.+�5r      �� $��Center=�6   $	��450��61   $��Center=�6>   $	��300��6Y   $��/Picture/Asset 2.png��6e   $
��Fill=�6�   �� 5s      $
��Left=�6   $	��433��6/   $	��Top=�6<   $	��297��6T   $��0,-9,0,0q�6`   $
��True��6r   $��/Picture/Artboard 2.png��6�   �� 5t      -   5         ��Name$ btnLogin��5t      $��False��6'   #��[ 69   $��Medium"�6]   $��Đăng nhập��6q   ���#223d3c$
��Left=�6�   $��
52,308,0,0q�6�   $	��Top=�6�   $��34��6�   $��84��6�   6�   �� 5u      -   5        $ 	btnSignUp��5u      $��False��6(   #��[ 6:   $��Medium"�6_   $��
Đăng ký��6s   ���#F9F2e8$
��Left=�6�   $��159,308,0,0q�6�   $	��Top=�6�   $��34��6�   $��84��6�   6�   �� 5v      -   5         ��Name$ txbUserName��5v      $��1��6+   
������  �� 
CaretBrush �#F9F2e8$��0q�6f   ���#F9F2e8$
��Left=�6�   $��
77,159,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��Tên đăng nhập��6�   $	��Top=�6�   $	��166��6   6N  �� 5w      -   5         ��Name$ txblPass��5w      $��Mật khẩu��6*   ���#F9F2e8$
��Left=�6P   $	��Top=�6l   $	��166��6�   $��
77,220,0,0q�6�   G� 5x      -   5         G�Name$ pwPass��5x      $��2��6*   
������   G� 
CaretBrush  �#F9F2e8$��0q�6e   ���#F9F2e8$	��166��6�   $
��Left=�6�   $	��Top=�6�   $��
77,220,0,0q�6�   6  �� 5y      -   5        $ 	btnForget��5y      $��False��6(   #��[ 6:   $��Quên mật khẩu��6`   $��9(�6x   $��Italic$�6�   $
��Left=�6�   $��
46,257,0,0q�6�   $	��Top=�6�   $��69��6�   6  �� 5z      -   5        $ btnExit��5z      $��False��6&   #��[ 68   $
��Left=�6]   $��	263,3,0,0q�6x   $	��Top=�6�   $��X��6�   $��20(�6�   $��30��6�   $��34��6�   6�   5{      5}      5~      