   M S B A M L   `   `   `  ����P  LDockingLibrary, Version=0.1.7425.26129, Culture=neutral, PublicKeyToken=nullG4clr-namespace:DockingLibrary;assembly=DockingLibraryDockingLibrary  5   	   	 MyApp   MyApp.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Gcustom4clr-namespace:DockingLibrary;assembly=DockingLibrary     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#667788  MaterialDesignFont#���  5   	   $	��450��5   !   $	��800��6.    � Title 6	   �� *Title+ � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      ��   OpenMenu#��[ 6   5      :� 5   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5      ��   	CloseMenu#��[ 6   5      .��5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5       � $��1��6   .+�5!      �  � RowDefinitions 5"      �� 5#      $
��Auto �6(   �� 5$      $
��Auto �6(   �� 5%      $��* �6(   .+�5'      � $��0��6   $��15��5(      $
��Left=�5)       5*      �� 5+      $
��Auto �6/   �� 5,      $
��Auto �6/   5.      �� 5/      $��1��6!    �� Orientation$ 
Horizontal=�6.   .+�50      �� $��View A��6!     PluginButtons#��[ 51   !   ��52   !   �� *ViewACommand+�� 53      $��View B��6!   #��[ 54      �� 55      $��View C��6!   #��[ 56      57          DockingLibrary.DockManager  58      -   5        $��dockManager��58   6   $��2��6)   $��0��6J     MaterialDesignPaper#���  6Z   59      5:      � 5;      -   5        	 �Name$	 GridMenu��5;   #   $��0��6   $��50��65   $
��Left=�6@   ���#778899.+�5<      �� .+�5=      � $	��150��6   
�������
 J� RenderTransformOrigin$
 0.5,0.5&�68   z�5>      V� 5?      .~�5@      �� �� 5A      �� 5B      T� 5C      5D      .+�5F      �� -   5         ��Name$ ButtonCloseMenu��5F        OpenCloseButtons#��[ 5G   !   ��5H   !   �� *CloseMenuCommand+y�5I   !   �� *CloseButtonVisibility+ �� UpdateSourceTrigger$ PropertyChanged=�.��5J      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�66   $��25��5K   6   $��25��5L   6   
���   �y�5N   6   �� *CloseButtonVisibility+$ PropertyChanged=�5O      �� 5P      -   5        $ ButtonOpenMenu��5P   !   #��[ 5Q   !   ��5R   !   �� *OpenMenuCommand+y�5S   !   �� *OpenButtonVisibility+$ PropertyChanged=�.��5T        $
 Menu=�66   $��30��5U   6   $��30��5V   6   $��3q�5W   7   
���   �5X   6   5Y      5Z      �� 5[      $��Disabled=�6   .@�5\      �� $��60��6'   .��5]      �� $ 
Horizontal=�6)   .+�5^   "     $ ViewDashboard=�6:   $��25��5_   :   $��25��5`   :   $��2q�5a   :   ���#556677$��Center=�5c   :   �� 5d   "   $
��Home��6,   ���#556677$��Center=�5f   ,   $��20 10 q�5g   ,   5h      5i      �� 5j      $��60��6'   .��5k      �� $ 
Horizontal=�6)   .+�5l   "     $ Pencil=�6:   $��25��5m   :   $��25��5n   :   $��2q�5o   :   ���#556677$��Center=�5q   :   �� 5r   "   $��Create��6,   ���#556677$��Center=�5t   ,   $��20 10 q�5u   ,   5v      5w      �� 5x      $��60��6'   .��5y      �� $ 
Horizontal=�6)   .+�5z   "     $
 Call=�6:   $��25��5{   :   $��25��5|   :   $��2q�5}   :   ���#556677$��Center=�5   :   �� 5�   "   $
��Call��6,   ���#556677$��Center=�5�   ,   $��20 10 q�5�   ,   5�      5�      �� 5�      $��60��6'   .��5�      �� $ 
Horizontal=�6)   $��Bottom=�6B   .+�5�   "     $ 	ExitToApp=�6:   $��25��5�   :   $��25��5�   :   $��2q�5�   :   ���#556677$��Center=�5�   :   �� 5�   "   $
��Exit��6,   ���#556677$��Center=�5�   ,   $��20 10 q�5�   ,   5�      5�      5�      5�      5�      5�      5�      