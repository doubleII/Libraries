   M S B A M L   `   `   `  ����   DockingLibrary"    DockingLibrary.OverlayWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  DockingLibrary��$	��300��$	��300�� � AllowsTransparency . 
������  � WindowStyle$
 None=� � ShowInTaskbar .   � 	Resources    DragDockButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 H� Drawing
 � Brush
 � Pen >� Brush >� 	Thickness >� LineJoin � Geometry �� Rect E� IsClosed �� Point O� 	GlowColor O� GlowSize O� Noise O� Opacity  DragPaneButtonStyle  DragIntoPaneButtonStyle��%�  &	        &	 J    &	 �    �� " ��.���  � �� �� " ��.R��� $��dragDockBorder��#��z��#��z��$��1q�._��� ��H� 	 � 

 ��  � >� 
 �   �$ 1Q�$ Round=� � .���� $ 	0,0,18,18�B� .��E�  . .���� $
 9, 9&��� $ 0, 18&���  �@J�BitmapEffect O� $ Black��$ 5Q�$ 0Q�$	 0.4Q��� " ��.���  � �� �� " ��.R��� $��1q��� " ��.���  � �� �� " ��.R��� $��1q�.��� .+�]� -   $��	panelDrag��.+��� -   $��btnDockLeft��$
��Left=�$��32��$��30������ .R��� $��images\DockLeft.png���� -   $��btnDockRight��$��Right=�$��32��$��29������ .R��� $��images\DockRight.png���� -   $��btnDockBottom��$��Bottom=�$��30��$��32������ .R��� $��images\DockBottom.png��$
��None=�$
��Left=�$	��Top=��� -   $��
btnDockTop��$	��Top=�$��30��$��32������ .R��� $��images\DockTop.png��$
��None=�$
��Left=�$	��Top=��� .+�� -   $$��gridPaneRelativeDockingOptions��$y�	Collapsed=�$��88��$��88�� � ColumnDefinitions �� �� ��  � RowDefinitions �� �� �� .+��� $��images\DockPane.png��$��3��$��3��$
��Fill=��� -   $��btnDockPaneTop��$��1��$��0������ �� -	   $��btnDockPaneRight��$��2��$��1������ �� -
   $��btnDockPaneBottom��$��1��$��2������ �� -   $��btnDockPaneLeft��$��0��$��1������ �� -   $��btnDockPaneInto��$��1��$��1������ 