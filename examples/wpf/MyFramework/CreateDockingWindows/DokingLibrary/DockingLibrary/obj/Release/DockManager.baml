   M S B A M L   `   `   `  ���� P  LDockingLibrary, Version=0.1.7425.25937, Culture=neutral, PublicKeyToken=null/clr-namespace:DockingLibraryDockingLibrary       DockingLibrary.DockManager   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .localclr-namespace:DockingLibrary     -     � 	Resources     DockLeftButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius � LayoutTransform �� Angle �� Color  DockTopButtonStyle��%"  &	        &	 �     �� " ��.���  � �� �� " ��.R��� $ 4,4,0,0��$��1q�
������� �� $ 90Q����� # � ��._��� #��z��$��2,2,2,2q��� " ��.���  � �� �� " ��.R��� $ 0,0,4,4��$��1q�
����������� # � ��._��� #��z��$��2,2,2,2q�.��� 	 � ColumnDefinitions	 �� $
��Auto ��� �� $
��Auto �
 � RowDefinitions
 �� $
��Auto ��� �� $
��Auto �.+��� -   $��btnPanelLeft��$��0��$��1�� �� Orientation$ Vertical=��� -   $��btnPanelRight��$��2��$��1��$ Vertical=��� -   $��btnPanelTop��$��1��$��0��$ 
Horizontal=��� -   $��btnPanelBottom��$��1��$��2��$ 
Horizontal=�� $��1��$��1��.+�    DockingLibrary.DockingGrid  -     Name$ gridDocking��    DockingLibrary.DockingGrid   
MouseEnter$ OnHideAutoHidePane��]� -   $��
panelFront�� J� Opacity$ 0Q���.  