   M S B A M L   `   `   `  ����P  LDockingLibrary, Version=0.1.7425.19377, Culture=neutral, PublicKeyToken=null/clr-namespace:DockingLibraryDockingLibrary  5           DockingLibrary.DockManager   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      ,localclr-namespace:DockingLibrary    5      -   5          � 	Resources  5         DockLeftButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius � LayoutTransform �� Angle �� Color  DockTopButtonStyle��%W  &	        &	 6    �� 5      " ��6&   .�5      ��  � �� 5      �� 5	      " ��6   .R�5
      �� $ 4,4,0,0��6   $��1q�6&   
������� 5   	   �� 5   
   $ 90Q�6   ��5   	   �� 5   
   # � ��6   ._�5   	   �� #��z��6   $��2,2,2,2q�6>   5   	   5      5      5      �� 5      " ��6%   .�5      ��  � �� 5      �� 5      " ��6   .R�5      �� $ 0,0,4,4��6   $��1q�6&   
���������5   	   �� 5    
   # � ��6   ._�5"   	   �� #��z��6   $��2,2,2,2q�6>   5#   	   5$      5&      5'      5(      .��5)      � 	 � ColumnDefinitions	 5*      �� 5+      $
��Auto �6   �� 5,      �� 5-      $
��Auto �6   
 � RowDefinitions
 5/      �� 50      $
��Auto �6   �� 51      �� 52      $
��Auto �6   .+�54      �� -   5        $��btnPanelLeft��54      $��0��6#   $��1��63    �� Orientation$ Vertical=�6@   55      �� 56      -   5        $��btnPanelRight��56      $��2��6$   $��1��64   $ Vertical=�6B   57      �� 58      -   5        $��btnPanelTop��58      $��1��6"   $��0��62   $ 
Horizontal=�6?   59      �� 5:      -   5        $��btnPanelBottom��5:      $��1��6%   $��2��65   $ 
Horizontal=�6B   5;      � 5<      $��1��6	   $��1��6   .+�5=          DockingLibrary.DockingGrid  -   5          Name$ gridDocking��5=          DockingLibrary.DockingGrid   
MouseEnter$ OnHideAutoHidePane��6,   ]� 5>      -   5        $��
panelFront��5>       J� Opacity$ 0Q�6!   ��.  6.   5?      5@      5A      