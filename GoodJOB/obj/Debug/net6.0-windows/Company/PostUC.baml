   M S B A M L   `   `   `  ����B  >GoodJOB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GoodJOBGoodJOB  5          GoodJOB.PostUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:GoodJOB     5      LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5        � 	Resources  5
       �� 
TargetType   btnPost �� Property �� Value �� 
TargetType ��Name J� Opacity �� Triggers P� Property	 P� Value
 �� 
TargetName  btnPostReview  	cbbSelect  cbbItem  cbb �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation��%l  &	        &	 �    &	 n    &	 �    &	 5    7  �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $	 btn��6!   $	��1.5q�6.   ���	#FF061615���	#FF284241$ 1Q�6s   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   ��  � �� �#F9F2e86?   5      P� 5       �@J�IsMouseOver$	 False��6=   . �5   "   ��  � �� �#F9F2e86?   5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $	
 btn��6)    � �� �#516d6b6P   5      P� 5       �@J�IsMouseOver$	 False��6=   . �5   "   �� $	
 btn��6)    � �� �	#FF2842416P   5      P� 5       � ��$
	 True��6;   . �5    "   ��  � �� �#F9F2e86?   5!      P� 5"       � ��$
	 True��6;   . �5#   "   �� $	
 btn��6)    � �� �	#FF3B53516P   5$      5&      5(      5)      �� 5+   
   " ��6   .�5,      ��  � �� 5-      �� 5.      " ��6&   .R�5/      �� $ border��6!   $��1q�61   ���	#FF284241
������ ._�50      �� $��Center=�6/   $��Center=�6L   51       52      P� 53       �@J�IsMouseOver$
	 True��6=   . �54   "   �� $
 border��6)    � �� �#516d6b6S   55      P� 56       �@J�IsMouseOver$
	 True��6=   . �57   "   ��  � �� �#F9F2e86?   58      P� 59       � {�$	 False��6;   . �5:   "   �� $
 border��6)    � �� �#516d6b6S   5;      P� 5<       � ��$
	 True��6;   . �5=   "   �� $
 border��6)    � �� �	#FF3B53516S   5>      5@      5B      5C      �� 5E   
   " d�6   .�5F      ��  � �� 5G      �� 5H      " d�6&   .R�5I      �� $ border��6!   ���	#FF284241$��2q�6H   ���	#FF061615._�5J      �� $��Right=�6/   $��Center=�6K   5K       5L      P� 5M       �@J�IsMouseOver$
	 True��6=   . �5N   "   �� $
 border��6)    � �� �#516d6b6S   5O      P� 5P       � {�$	 False��6;   . �5Q   "   �� $
 border��6)    � �� �#516d6b6S   5R      P� 5S       � ��$
	 True��6;   . �5T   "   �� $
 border��6)    � �� �	#FF3B53516S   5U      5W      5Y      5Z      �� 5[   
   " ��6   .�5\      ��  � �� 5]      �� 5^      " ��6&   .R�5_      �� $ border��6!   ���	#FF284241$��0q�6H   ._�5`      �� $��Center=�6/   $��Center=�6L   5a       5b      P� 5c       �@J�IsMouseOver$
	 True��6=   . �5d   "   �� $
 border��6)    � �� �#516d6b6S   5e      P� 5f       � {�$	 False��6;   . �5g   "   �� $
 border��6)    � �� �#516d6b6S   5h      P� 5i       �@��
IsSelected$
	 True��6<   . �5j   "   �� $
 border��6)    � �� �	#FF3B53516S   5k      5m      5o      5p      �� 5q   
   " ��6   .�5r      ��  � �� 5s      �� 5t      " ��6&   .R�5u      � .+�5v      �� $ border��6%   ���	#FF284241$��2q�6L   ���#F9F2e8._�5w   "   �� $��Center=�63   $��Center=�6P   5x      d� 5y      $��ToggleButton��5{      8��  $��1��5|      $|�false��5}      $ Press=�5~      
������ 
������ $��0q�5�      $��Right=�5�      $��0q�5�       5�      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+��5�   "   �� 5�   &   ���#F9F2e8$��10��5�   !   $��5��5�   !   $��0,5,0,0q�5�   !   $��Center=�5�   !   $��Center=�5�   !   5�      �� 5�      $ ContentSite��5�      $ False��5�      $��Center=�5�      $��Center=�5�      #��z 5�      #��z 5�      $��3,3,23,3q�5�      �� 5�      $ PART_EditableTextBox��5�      $
��Left=�5�      $��Center=�5�      $��3,3,23,3q�5�      $
|�True��5�      
������ $y�Hidden=�5�      # z 5�      ��5�      Z� 5�      � 5�      $��Popup��5�      $��Bottom=�5�      #��z 5�      $
 True��5�      $|�False��5�      $��Slide=�5�      .��5�   "   � $��DropDown��5�      $
 True��5�      #��z 5�      #��z 5�      .+�5�   &   �� $ DropDownBorder��5�   !   ���	#FF284241$	��1.5q�5�   )   ���	#FF0616155�   )   �� 5�   &   $��4,6,4,6q�63   $
 True��6D   .��5�   *   �� $
 True��65   $ 	Contained=�6H   5�   '   5�   #   5�      5�      5�      5�      5�      5�      .��5�      � -   5        ���	#FF284241.+�5�   
   �� $
 0.15Q�6   $
��Left=�6   $	��298��6:   $��701,162,0,0q�6G   $	��Top=�6\   $	��284��6t   $��/Picture/Logo1.png��6�   � 5�   
   $��	10,0,10,8q�6   ���#F9F2e8$	 0.8Q�67   5�      �� 5�   
   $��Hidden=�6   $��0,0,0,10q�6<   .��5�      � $
��1240��6   .+�5�      �� $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��	39,24,0,0q�6n   $
��Wrap=�6�   $��Công việc��6�   $	��Top=�6�   �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��380,124,0,0q�6n   $
��Wrap=�6�   $��Hình thức��6�   $	��Top=�6�   �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��
513,73,0,0q�6n   $
��Wrap=�6�   $��Kinh nghiệm��6�   $	��Top=�6�   �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��
28,174,0,0q�6n   $
��Wrap=�6�   $��Mức lương��6�   $	��Top=�6�   �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��	50,74,0,0q�6n   $
��Wrap=�6�   $��Lĩnh vực��6�   $	��Top=�6�   �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��
31,843,0,0q�6n   $
��Wrap=�6�   $��Mô tả công việc��6�    �� TextAlignment$ Right=�6�   $	��Top=�6�   $��90��6�   �� 5�      -   5         ��Name$ 
cbFullTime��5�      $��15(�6/   $��	Full-time��6=   $
��Left=�6Q   $��478,130,0,0q�6l   $	��Top=�6�   6�   �� 5�      -   5        $ 
cbPartTime��5�      $��15(�6/   $��	Part-time��6=   $
��Left=�6Q   $��593,130,0,0q�6l   $	��Top=�6�   6�   �� 5�      -   5        $ cbIntern��5�      $��15(�6-   $��Thực tập��6;   $
��Left=�6N   $��710,130,0,0q�6i   $	��Top=�6~   6�   �� 5�      -   5         ��Name$ cbbField��5�      $��14(�6-   #��[ 6;   $
��Left=�6X   $��
133,71,0,0q�6s   $	��Top=�6�   $	��160��6�   ���#F9F2e8$��30��6�   ��5�      �� 5�        �� BasedOn#  [ 6    " ��6C   .@�5�      �� .��6#   Chọn6)   �� 5�      .��6#   Công nghệ6.   �� 5�      .��6#   Kỹ thuật6-   �� 5�      .��6#   Thiết kế6-   �� 5�      .��6#   	Kinh tế6,   �� 5�      .��6#   	Du lịch6,   �� 5�      .��6#   Khác6)   5�      �� 5�      -   5        $ 
txbJobName��5�      $��Medium"�6.   $��15(�6B   $�� ��6P   $	��1.5q�6X   ���	#FF284241
������ $
��Left=�6�   $��
133,21,0,0q�6�   ! �� TextWrapping$
! Wrap=�6�   $	��Top=�6�   $	��655��6�   $��30��6  $��2q�6  �� 5�      -   5        $ cbbExp��5�      #��[ 6+   $��14(�6H   $
��Left=�6V   $��
628,71,0,0q�6q   $	��Top=�6�   $	��160��6�   ���	#FFF9F2E8$��30��6�   ��5�      �� 5�      #  [ 6    " ��6C   .@�5�      �� $��Chọn��6#   �� 5�      $��Không cần��6#   �� 5�      $��1 năm��6#   �� 5�      $��2 năm��6#   �� 5�      $��3 năm��6#   �� 5�      $��Trên 3 năm��6#   5�      �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��
42,124,0,0q�6n   $
��Wrap=�6�   $��Thời gian��6�   $	��Top=�6�   �� 5�      -   5        $ cbbWorkTime��5�      $��14(�60   #��[ 6>   $
��Left=�6[   $��133,123,0,0q�6v   $	��Top=�6�   $	��160��6�   ���	#FFF9F2E8$��30��6�   ��5�      �� 5�      #  [ 6    " ��6C   .@�5�      �� $��Chọn��6#   �� 5�      $��Dưới 1 tháng��6#   �� 5�      $��1 đến 3 tháng��6#   �� 5�      $��3 đến 6 tháng��6#   �� 5�      $��	12 tháng��6#   �� 5�      $��
Dài hạn��6#   5�      �� 5�      -	   5        $ 	cbbSalary��5�      $��14(�6.   #��[ 6<   $
��Left=�6Y   $��133,174,0,0q�6t   $	��Top=�6�   $	��160��6�   ���	#FFF9F2E8$��30��6�   ��5�      �� 5�      #  [ 6    " ��6C   .@�5�      �� $��Chọn��6#   �� 5�      $��Theo sản phẩm��6#   �� 5�      $��
Theo giờ��6#   �� 5�      $��Theo tháng��6#   5�      �� 5�      -
   5        " ��Name$" txblSalaryFrom��5�      $��18(�64   ���	#FF284241$
��Left=�6Y   $��312,177,0,0q�6t   $
��Wrap=�6�   $
��Từ��6�   $	��Top=�6�   �� 5�      -   5        $" txblSalaryTo��5�      $��18(�62   ���	#FF284241$
��Left=�6W   $��500,177,0,0q�6r   $
��Wrap=�6�   $��Đến��6�   $	��Top=�6�   �� 5�      $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��385,1112,0,0q�6n   $
��Wrap=�6�   $��Thời hạn��6�   $	��Top=�6�   $��75��6�   �� 5      -   5        $ cbbPostTime��5      $��14(�60   #��[ 6>   $
��Left=�6[   $��468,1109,0,0q�6v   $	��Top=�6�   $	��153��6�   ���	#FFF9F2E8$��30��6�   ��5     �� 5     #  [ 6    " ��6C   .@�5     �� $��Chọn��6#   �� 5     $��Dưới 1 tháng��6#   �� 5     $��1 tháng��6#   �� 5     $��2 tháng��6#   �� 5     $��3 tháng��6#   �� 5	     $��4 tháng��6#   �� 5
     $��5 tháng��6#   �� 5     $��6 tháng��6#   �� 5     $��7 tháng��6#   �� 5     $��8 tháng��6#   �� 5     $��9 tháng��6#   �� 5     $��	10 tháng��6#   �� 5     $��	11 tháng��6#   �� 5     $��1 năm��6#   �� 5     $��Trên 1 năm��6#   5     �� 5     $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��
53,225,0,0q�6n   $
��Wrap=�6�   $��
Kỹ năng��6�   $	��Top=�6�   �� 5     -   5        $ txbSkill��5     $��5q�6,   $��Medium"�68   $	��1.5q�6L   ���	#FF284241
������ # �� 	MaxLength$
# 3000��6�   $��15(�6�   ���	#FF284241$ �� AcceptsReturn$
$ True��6�   $
! Wrap=�6�   % �� TextAlignment$
% Left=�6�   $��133,225,62,756q�6  �� 5     -   5        $ txbDescription��5     $��5q�62   $��Medium"�6>   $	��1.5q�6R   ���	#FF284241
������ $
# 3000��6�   $��15(�6�   ���	#FF284241$
$ True��6�   $
! Wrap=�6�   $
% Left=�6�   $��133,843,62,169q�6  & J� RenderTransformOrigin$& 0.5,0.5&�6%  .��6E  z�5     V� 5     .~�5     �� ' �� ScaleY$' 1Q�6-   �� 5     �� 5     T� 5     5     .��5   /   5!     �� 5#     -   5        $ txbField��5#     $��Medium"�6,   ${�False��6@   $��15(�6R   $�� ��6`   $	��1.5q�6h   ���	#FF284241
������ $
��Left=�6�   $��
300,71,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��160��6
  $��30��6  $��2q�6"  6K  �� 5$     -   5        $ txbSalaryFrom��5$     $��Medium"�61   ${�False��6E   $��15(�6W   $�� ��6e   $	��1.5q�6m   ���	#FF284241
������ $��Center=�6�   $��	0,174,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��140��6  $��30��6  $��2q�6(  6V  �� 5%     -   5        $ txbSalaryTo��5%     $��Medium"�6/   ${�False��6C   $��15(�6U   $�� ��6c   $	��1.5q�6k   ���	#FF284241
������ $
��Left=�6�   $��544,174,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��140��6  $��30��6  $��2q�6&  6R  �� 5&     -   5        $ txbDateOfPost��5&     ${�False��62   $��15(�6D   $�� ��6R   $	��1.5q�6Z   ���	#FF284241
������ $
��Left=�6�   $��634,1109,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��154��6�   $��30��6
  $��2q�6  6D  �� 5'     $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��39,1110,0,0q�6n   $
��Wrap=�6�   $��Số lượng��6�   $	��Top=�6�   $��83��6�   $ Right=�6�   �� 5(     -   5        $ cbbNumOfRecrui��5(     $��14(�63   #��[ 6A   $
��Left=�6^   $��133,1109,0,0q�6y   $	��Top=�6�   $	��111��6�   ���	#FFF9F2E8$��30��6�   ��5)     �� 5*     #  [ 6    " ��6C   .@�5,     �� $��Chọn��6#   �� 5-     $��
1 người��6#   �� 5.     $��
2 người��6#   �� 5/     $��
3 người��6#   �� 50     $��
4 người��6#   �� 51     $��
5 người��6#   �� 52     $��Trên 5 người��6#   53     �� 54     -   5        $ txbNumOfRecrui��54     $��Medium"�62   ${�False��6F   $��15(�6X   $�� ��6f   $	��1.5q�6n   ���	#FF284241
������ $
��Left=�6�   $��255,1109,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��111��6  $��30��6  $��2q�6*  6Y  �� 55     -   5        $ txbSalaryNote��55     $��Medium"�61   ${�False��6E   $��15(�6W   $�� ��6e   $	��1.5q�6m   ���	#FF284241
������ $
��Left=�6�   $��713,174,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $��75��6  $��30��6  $��2q�6'  6U  �� 56     $��18(�6   ���	#FF284241$
��Left=�6A   $��695,174,0,0q�6\   $
��Wrap=�6q   $��/��6�   $	��Top=�6�   �� 57     $��18(�6   ���	#FF284241$
��Bold"�6A   $
��Left=�6S   $��
54,513,0,0q�6n   $
��Wrap=�6�   $��Phúc lợi��6�   $	��Top=�6�   �� 58     -   5        $ 
txbWelfare��58     $��5q�6.   $��Medium"�6:   $	��1.5q�6N   ���	#FF284241
������ $
# 3000��6�   $��15(�6�   ���	#FF284241$
$ True��6�   $
! Wrap=�6�   $
% Left=�6�   $��133,513,62,426q�6	  5:     5;     �� 5<  
   -   5        ( ��Name$( btnPost��5<     #��[  6"   $
��Bold"�6C   ���	#FF284241$��Đăng��6l   $��13(�6{   $
��Left=�6�   $��706,419,0,0q�6�   $	��Top=�6�   $��79��6�   $��30��6�   6�   �� 5=  
   -   5        $( btnPostReview��5=     #��[ 6(   $
��Bold"�6O   $��Xem trước��6a   $��13(�6u   $
��Left=�6�   $��613,419,0,0q�6�   $	��Top=�6�   $��79��6�   $��30��6�   6�   �� 5>  
   -   5        $( btnSave��5>     $y�	Collapsed=�6"   #��[  69   $
��Bold"�6Z   ���	#FF284241$
��Lưu��6�   $��13(�6�   $
��Left=�6�   $��706,419,0,0q�6�   $	��Top=�6�   $��79��6�   $��30��6�   6�   �� 5?  
   -   5        $( btnExit��5?     $y�	Collapsed=�6"   #��[  69   $
��Bold"�6Z   ���	#FF284241$��Thoát��6�   $��13(�6�   $
��Left=�6�   $��517,419,0,0q�6�   $	��Top=�6�   $��79��6�   $��30��6�   6   5@     5A     