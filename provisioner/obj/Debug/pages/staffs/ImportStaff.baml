   M S B A M L   `   `   `  ����F  Bprovisioner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:provisioner.pages.staffsprovisioner.pages.staffs  5      *    $provisioner.pages.staffs.ImportStaff   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:provisioner.pages.staffs     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          N� Title$  Import Staff: ��5      .��5      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DataGrid.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6)   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.GroupBox.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6)   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml?�6)   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6)   %    5       � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $
��400* �6   6.    � RowDefinitions 5    
   �� 5!      $��50 �6   6*   �� 5"      $��70 �6   6*   �� 5#      $��* �6   6)   �� 5$      $��50 �6   6*   .+�5&   
   �� $��0��6   $��2��6"   $
��Left=�66   $	��300��6Q   .+�5'      �� $��35��6   ���#323542$��
0,0,-900,0q�6=   $
��1200��6Q    �� Orientation$ Vertical=�6^    J� RenderTransformOrigin$	 0,0&�6u   $	��Top=�6�   $��Right=�6�   .+�5(      �� $��27(�6   
�������
 � Tag$ NuLam��69   $��Center=�6E   $��Center=�6`   $��Import Staff Data��6}   5)      5*      �� 5+   
   $��1��6   $��2��6"   $��0,0,0,0q�66   $��Stretch=�6G   $ 
Horizontal=�6e   .+�5,      �� $��	10,0,0,20q�6   $ 
Horizontal=�6,   .+�5-      �� -   5        	 ��Name$	 syncStaffType��5-   H   ���	#FF10B1C1$	��250��60   $��40��6<   $	��Top=�6_   .��5.      �� $ 
Horizontal=�6!   .+�5/      "  FontAwesome.WPF.ImageAwesome  -   5        
  Name$
 syncIcon��5/   9      Icon$ Refresh=�6*      Spin .  $��18��6X      
Foreground
 �����6y   �� 50      $��Sync. Staff Type��6    $��18(�6;   $
��Bold"�6I   
�������6q   51      52      �� 53      $��1��6   $��0��6-   $��	25,0,25,0q�6:   .+�54      �� -   5         ��Name$ 	staffType��54      $��30��62   $	��200��6>    � ToolTip$ Choose Staff type��6J   $
��Bold"�6f   $��Center=�6x   .@�55      �� $
��Bold"�6     �� 
IsSelected . $��Center=�6M   .��6h   !Select Staff type to upload to:6�   56      57      �� 58      -   5        $
	 load��58      $��40��6(   $	��250��64   $��20 0 0 0q�6@   ���	#FF323542$	��Top=�6z   .��59      �� $ 
Horizontal=�6!   .+�5:        -   5        $	��ico��5:   8   $ Upload=�6*   
 �����$��18��6V   $��Center=�6a   $��Center=�6|   6�   �� 5;      -   5        $
��uico��5;   C   
�������$
��18px(�63   $��Center=�6O   $��Center=�6l   .��6�   Upload .CSV File Only6�   5<      5=      �� 5>      -   5        $	 
syncStaffs��5>      $��40��6.   $	��250��6:   $��20 0 0 0q�6F   ���	#FF128080$	��Top=�6~   .��5?      �� $ 
Horizontal=�6!   .+�5@        -	   5        $��syncIco��5@   7   $ Cloud=�6*   
 �����$��18��6Y   $��Center=�6d   $��Center=�6   6�   �� 5A      -
   5        $��	syncLabel��5A   C   
�������$
��18px(�63   $��Center=�6T   $��Center=�6q   .��6�   Sync Staffs6�   5B      5C      5D      5E      �� 5F   
   $��2��6   $��2��6$   $��Stretch=�68   $��Stretch=�6T   .��5G      �� .@�5H      �� $��Staff��6   $��18(�6)   ���	#FF06A406$
��20pxq�6N   .��5I      �� .+�5J        -   5        $��spinner2��5J   Z   $ Spinner=�6*    . $y�Visible=�6E   $��30��6j    �	#FFFF01466�   &   System.Windows.Controls.DataGrid  5K      -   5          Name$ transTab��5K   ~      AutoGenerateColumns .  $��Stretch=�6@   $
��Bold"�6^   $��15(�6p   $	��500��6�   $
��auto��6�   
���   �   
IsReadOnly . ��6�   ��  �� Source$
 list��   Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M   "      
FontWeight$
 Bold"�65      FontSize$ 15Q�6G   ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6U      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *ID+6x     5N   "   $
 Bold"�65   $ 15Q�6G   $ FullName��6U    6g   �� *
fullname+  5O   "   $
 Bold"�65   $ 15Q�6G   $ Staff ID��6U    6g   �� *	staffID+  5P   "   $
 Bold"�65   $ 15Q�6G   $ Card Serial��6U    6j   �� *
cardSerial+  5Q   "   $
 Bold"�65   $ 15Q�6G   $ Staff Synced��6U    6k   �� *staffSynced+  5R   "   $
 Bold"�65   $ 15Q�6G   $ Designation��6U    6j   �� *designation+  5S   "   $
 Bold"�65   $ 15Q�6G   $ 
Staff type��6U    6i   �� *	staffType+  5T   "   $
 Bold"�65   $ 15Q�6G   $ Location��6U    6g   �� *
location+5V      5W      5X      �� 5Y      $��Duplicate Entry��6   $��18(�63   ���	#FFEA083B$
��20pxq�6X   .��5Z      �� .+�5[      �� -   5        ���	#FFE02E12$��40��5[   N   .��5\      �� $ 
Horizontal=�6)   .+�5]   "     $ Trash=�62   $��15��6?   
 �����6_   �� 5^   "   $��Center=�6(   $��Center=�6E   
�������.��6s   Delete past logs6�   5_      5`        5a      -   5        $��spinner3��5a   Z   $ Spinner=�6*    . $y�Visible=�6E   $��30��6j    �	#FFFF01466�     5b      -   5        $ 	transTab2��5b   ~    .  $��Stretch=�6@   $
��Bold"�6^   $��15(�6p   $	��500��6�   $
��auto��6�   
���   � . ��6�   �� $
 list�� 5c        5d   "   $
 Bold"�65   $ 15Q�6G   $ ID��6U    .  6a   �� *ID+6x     5e   "   $
 Bold"�65   $ 15Q�6G   $ FullName��6U    6g   �� *
fullname+  5f   "   $
 Bold"�65   $ 15Q�6G   $ Staff ID��6U    6g   �� *	staffID+  5g   "   $
 Bold"�65   $ 15Q�6G   $ Card Serial��6U    6j   �� *
cardSerial+  5h   "   $
 Bold"�65   $ 15Q�6G   $ Staff Synced��6U    6k   �� *staffSynced+  5i   "   $
 Bold"�65   $ 15Q�6G   $ Designation��6U    6j   �� *designation+  5j   "   $
 Bold"�65   $ 15Q�6G   $ 
Staff type��6U    6i   �� *	staffType+  5k   "   $
 Bold"�65   $ 15Q�6G   $ Location��6U    6g   �� *
location+5m      5n      5o      5p      5q      �� 5r   
   $��2��6   $��3��6)   $ 
Horizontal=�66   .+�5s      �� $��Center=�6   .��6/   Total Staffs6=   �� 5t      -   5         ��Name$ total��5t   /   $��Center=�6   .��6>   06A   �� 5u      $��20 0 0 0q�6   $��Center=�6'   .��6B   Total Staffs Synced6W   �� 5v      -   5        $ synced��5v   /   $��Center=�6   .��6?   06B   5w      5x      5y      