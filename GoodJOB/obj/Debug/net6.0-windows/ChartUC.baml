   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      B >GoodJOB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GoodJOBGoodJOB 5         GoodJOB.ChartUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      'localclr-namespace:GoodJOB     5        � 	Resources  5
       �� 
TargetType   
btnWDLogin �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName��%b  &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   ���	#FF284241$��0q�6H   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $	 border��6)    � �� �#516d6b6S   5      P� 5       � {�$ False��6;   . �5   "   �� $	 border��6)    � �� �	#FF3B53516S   5      P� 5       � ��$
 True��6;   . �5   "   �� $	 border��6)    � �� �	#FF3B53516S   5      5      5      5       5!      .��5"      � -   5        
 �Name$
 mainGrid��5"      ���#F9F2e8.+�5#   
   #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6A   ���	#FF284241$��10,85,425,19q�6p      Series 6   �� *SeriesCollection+   AxisX 5%         LiveCharts.Wpf.Axis     
Foreground �	#FF284241   Labels 5&      �� *Labels+5'         AxisY 5*           Title$ Lượt yêu thích��6    �	#FF284241 5+      �� *Values+5,      5.         LiveCharts.Wpf.PieChart  50   
   -   5          Name$ 
myPieChart��50      $ Right=�6+      	Hoverable$ False��6B   $��467,85,10,57q�6s   52      �� 54   
   ���	#FF284241 J� Opacity$	 0.1Q�6(   $��19,25,425,450q�66   �� 55   
   ���	#FF284241$��10,25,831,450q�6(   �� 56   
   ���	#FF284241$	 0.1Q�6(   $��456,25,10,450q�66   �� 57   
   ���	#FF284241$��447,24,394,451q�6(   �� 58   
   $��TOP CÔNG TY��6   $��20(�6'   $
��Bold"�65   $
��Left=�6G   $��	30,34,0,0q�6b   $
��Wrap=�6u   $	��Top=�6�   �� 59   
   $��NHU CẦU NHÂN SỰ��6   $��20(�6+   $
��Bold"�69   $
��Left=�6K   $��
467,34,0,0q�6f   $
��Wrap=�6z   $	��Top=�6�   �� 5:   
   -   5         ��Name$ btnExit��5:      #��[  6"   ���#F9F2e8$��15(�6[   $
��Bold"�6i   $��Thoát��6{   $
��Left=�6�   $��710,468,0,0q�6�   $	��Top=�6�   $	��112��6�   $��33��6�   6�   5;      5<      