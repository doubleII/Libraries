   M S B A M L   `   `   `  ���� P  LDockingLibrary, Version=0.1.7425.25937, Culture=neutral, PublicKeyToken=null/clr-namespace:DockingLibraryDockingLibrary  "    DockingLibrary.DocumentsPane   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /customclr-namespace:DockingLibrary       � 	Resources     DocTabItemStyle �� 
TargetType �� Property �� Value ��Name �� CornerRadius �� EndPoint �� 
StartPoint � Color	 � Offset
 �� Color ��Name �� Triggers P� Property P� Value �� 
TargetName % !DocumentsTabSwitchMenuButtonStyle �� Stretch �� StrokeEndLineCap �� StrokeLineJoin   DocumentsTabCloseButtonStyle �� Padding  DocumentsTabControlTemplate �� 
TargetType �Name-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions ��Name � RowDefinitions ��Name   TabIndex   DirectionalNavigation �� SelectedContent �� SelectedContentTemplate& �� SelectedContentTemplateSelector  � DataContext! ��Name" K� IsItemsHost# �� Orientation��%�  &	        &	 u    &	 :    &	 ;    7  7  �� " ��.���  � �� �� .R��� $ border��-   $��Bottom=�$��18��$��1,1,1,0q�$ 4,4,0,0������ $ 0.5,0.0&�$ 0.5,1&�.��� # � ��$	 0Q�� $ 	#FFFFFFFF��$	 1Q����� #
 � ��._��� $ header��#��z��$��2,0,0,0q� P�  �@��
IsSelected . . ��� $ border�� � �� �� #
 � ���� $ header�� � ��$
 Bold"��� " ��.���  � �� �� .R��� $��18��._�F� $
 Fill=����	#FF000000$ Square=�$ Round=�$��0��$
��Auto��"������- ��- �@]� ��- � z ��� 	$��3,6,3,3q����� #
 � ���� " ��.���  � �� �� .R��� $��18��$ 0,1,0,1q�._�� .+�F� ���	#FFFFFFFF$
 Fill=����	#FF000000$��3,3,3,3q�����        �@B @B 	F� ���	#FFFFFFFF$
 Fill=����	#FF000000$��3,3,3,3q�����@B     �    @B 	�� " ��.R�� $
 Grid��$ Local=� �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ ContentPanel��$��1��$��0�����	#FFD0CEBF$��0,0,1,1q�$ 2��$ Local=�$ 	Contained=�._��� $ Border��#��z��#��z��._��� $ Border1��#��z��._��� $ PART_SelectedContentHost��#��z��#��z #��z #��z $��SelectedContent��  Z� �� $! HeaderPanel��$��0��$��0��$��Stretch=�$��Stretch=�$��0,0,0,0q�$��Hidden=�$��Disabled=����� " ��.���  � �� �� .R�� $ HeaderPanel��$��0,0,0,0q�$��0��$��0�� �� $��* ��� $��16 ��� $��16 � �� $
��Auto �.+��� $��0��#��z���� -   $��1��8��  �� -   $��2��8�� .���� " . $# 
Horizontal=�$ 1����Z� .��� .+��� -   $��tbcDocuments��$$ �� IsSynchronizedWithCurrentItem$
$ TrueY�#���  $y�	Collapsed=�