   M S B A M L   `   `   `  ���� P  LDockingLibrary, Version=0.1.7425.26128, Culture=neutral, PublicKeyToken=null/clr-namespace:DockingLibraryDockingLibrary  !    DockingLibrary.DockablePane   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /customclr-namespace:DockingLibrary       � 	Resources     TabItemFocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  TabControlNormalBorderBrush �� Color  TabItemNormalBackground �� EndPoint �� 
StartPoint � Color	 � Offset  TabItemHotBorderBrush  TabItemHotBorderBackround  TabItemHotBackground  TabItemSelectedBorderBrush " TabItemSelectedBorderBackround  TabItemSelectedBackground 	 TabItemDisabledBackground 
 TabItemDisabledBorderBrush  DockablePaneTabItemStyle
 �� 
TargetType �� 
TargetType �Name ��Name �� CornerRadius �� Padding �� Path �� RelativeSource �� AncestorType �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY �� Angle ]� 
Conditions �� Property �� Value & "DockableContentsTabControlTemplate-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions ��Name  � RowDefinitions! ��Name"   TabIndex#   DirectionalNavigation$ ��Name% �� SelectedContent& �� SelectedContentTemplate&' �� SelectedContentTemplateSelector( � DataContext1  +DockingLibrary.DockableContentTabItemsPanel) K� IsItemsHost  DockingHeaderButtonStyle* �� Triggers��%�
  &	        &	 X     &	 k     &	 �     &	 �     &	 �     &	 A    &	 V    &	 k    &		 �    &	
 �    &	 �    7   7  7  7  7 	 7 
 &	     &	 �	    �� .���  � �� �� .R���  . 
���   �$	 1 2R�$��1��$��3,3,3,1q��� $ #919B9C���� $	 0,1&�$	 0,0&�.��� $ 	#FFFFFFFF��$	 0Q�� $ 	#FFECEBE6��$	 1Q��� $ 	#FFE68B2C���� $ 	#FFFFC73C���� $	 0,1&�$	 0,0&�.��� $ 	#FFFFFFFF��$	 0Q�� $ 	#FFECEBE6��$	 1Q��� $ 	#FFE68B2C���� $ 	#FFFFC73C���� $ 	#FFFCFCFE���� $ 	#FFF5F4EA���� $ 	#FFC9C7BA���� "
 ��.���  �@�FocusVisualStyle8   ��  � ��$ 	12,2,12,2q���  � ��$ 1,1,1,0q���  � ��8  ��  � ��# � ����  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R���  . ._�� $��0,0,1,0q�.+�� $ 	Transform��.+��� $ Bd��#��z��#��z��#��z��$ 3,3,0,0���� #��z��# z��._��� -   # z $��Header����. ���� $  HorizontalContentAlignment� �� " ������ $ VerticalContentAlignment� �� " �� P�  �@��
IsSelected . . ���  �@K�ZIndex$ 1���� $ Bd��8   � ����  � �� �� $	 0,1&�$	 0,0&�.��� $ 	#FF574D1A��$	 0Q�� $ 	#FF1D6829��$	 1Q���  � ��$ 1,1,1,0q�P�  �@��TabStripPlacement$ Bottom=�. ��� $ 	Transform�� �@�LayoutTransform �� $ 1Q�$ -1Q�P�  �@��TabStripPlacement$
 Left=�. ��� $ 	Transform�� �@�LayoutTransform �� $	 -90Q�P�  �@��TabStripPlacement$ Right=�. ��� $ 	Transform�� �@�LayoutTransform �� $ 90Q�P�  � {� .  . ��� # � �� � ���� $ Bd��8   � ���� $ Bd��8   � ��]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$	 Top=�./���  � ��$ -2,-2,-2,-1q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$ Bottom=�./���  � ��$ -2q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$
 Left=�./���  � ��$ -2,-2,-1,-2q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$ Right=�./���  � ��$ -1,-2,-2,-2q��� " ��.R�� $
 Grid��$ Local=� �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 �  �� $! RowDefinition0��$��* ��� $! RowDefinition1��$
��Auto �.+��� $ ContentPanel��$��0��$��0�����	#FFD0CEBF$��0,0,1,1q�$" 2��$ Local=�$# 	Contained=�._��� $ Border��#��z��#��z��._��� $ Border1��#��z��._��� $$ PART_SelectedContentHost��#��z��#��z% #��z& #��z' $��SelectedContent��( Z�   ) . $��1��$��0���� "
 �* P�  �@J�IsMouseOver . . ���  � ��
 �  ��.��]� .+��� -   $��
PaneHeader��$��18��$
��Auto��$	��Top=����	#FF000000���� $ 0.5,0&�$ 0.5,1&�.��� # � ��$	 0Q�� # � ��$	 1Q�._�]� $
��Auto��$
��Auto����. .+�� $��2,3,0,4q�$
��Auto��$
��Auto��.+�A� $��4��$��4��$��Right=�$��	0,0,5.5,0q�$��Bottom=����� # � ������ $ 1,0.5&�$ 0,0.5&�.��� $ 	#FF000000��$	 0Q�� $ 	#FFFFFFFF��$	 1Q�A� $
��Left=�$	��Top=�$��4��$��4������ # � ������ $ 1,0.5&�$ 0,0.5&�.��� $ 	#FF000000��$	 0Q�� $ 	#FFFFFFFF��$	 1Q�A� $��4��$��Right=�$	��Top=�$��4������ # � ������ $ 1,0.5&�$ 0,0.5&�.��� $ 	#FF000000��$	 0Q�� $ 	#FFFFFFFF��$	 1Q�� -   $ btnClose��$��16��$
��Auto��$��Right=�$��0,1,0,1q�#���  ���� $ 0.5,0&�$ 0.5,1&�.��� # � ��$	 0Q�� # � ��$	 1Q�.+�F� ���	#FFFFFFFF+ �� Stretch$
+ Fill=����	#FF000000$��3,3,3,3q�����        �@B @B 	F� ���	#FFFFFFFF$
+ Fill=����	#FF000000$��3,3,3,3q�����@B     �    @B 	� -   $ btnAutoHide��$��16��$��16��$��Right=�.+��� $��0��$��3,3,3,6q����� $ 1,0.5&�$ 0,0.5&�.��� $ 	#FF000000��$	 0Q�� $ 	#FFFFFFFF��$	 1Q����� $ 1,0.5&�$ 0,0.5&�.��� $ 	#FF000000��$	 0Q�� $ 	#FFFFFFFF��$	 1Q�F� ���	#FFFFFFFF$
+ Fill=����	#FF000000$��6,9,6,2q�$��Stretch=�����        �    @B 	F� ���	#FFFFFFFF$
+ Fill=����	#FF000000$��2,0,2,6q�$��Bottom=�$��1������        �@B     	� -   $ btnMenu��$��16��$
��Auto��$��0,0,0,0q�$��Right=����� $ 0.5,0&�$ 0.5,1&�.��� # � ��$	 0Q�� # � ��$	 1Q�.+�F� $
+ Fill=����	#FF000000, �� StrokeEndLineCap$, Square=�- �� StrokeLineJoin$- Round=�$��0��$
��Auto��"������- ��- �@]� ��- � z ��� 	$��3,6,3,3q����� # � ��. � ContextMenu. �� -   .@�m� -   $��menuFloatingWindow��$��Floating window��m� -   $��menuDockedWindow��$��Docked window��m� -	   $��menuTabbedDocument��$��Tabbed document��m� -
   $��menuAutoHide��$��	Auto hide��m� -   $��	menuClose��$��Close���� -   / ��Name$/ tbTitle��$��2,0,0,0q�$
��Auto��$
��Auto��$��Title��$��NoWrap=�$��Center=�$��12(����� # � ���� $
��Auto��$
��Auto�����	#FF000000._�� 
�������.+��� -   $��cpClientWindowContent��$y�	Collapsed=��� -   $��tbcContents��$y�	Collapsed=�#���  $0 �� IsSynchronizedWithCurrentItem$
0 TrueY�1 �� TabStripPlacement$1 Bottom=����� "
 ]�* P�  �@J�	IsFocused . . ���  � ��$ 20(�