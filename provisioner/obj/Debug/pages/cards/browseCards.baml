   M S B A M L   `   `   `  ����F  Bprovisioner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:provisioner.pages.cardsprovisioner.pages.cards  5      )    #provisioner.pages.cards.browseCards   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:provisioner.pages.cards     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          N� Title$  Browse cards: ��5      .��5      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DataGrid.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6)   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.GroupBox.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6)   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml?�6)   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6)   %    5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��60* �6   6-    � RowDefinitions 5    
   �� 5!      $��50 �6   6*   �� 5"      $��* �6   6)   �� 5#      $��70 �6   6*   .+�5%   
   �� $��0��6   $��2��6"   $
��Left=�66   $	��300��6Q   .+�5&      �� $��35��6   ���#323542$��
0,0,-900,0q�6=   $
��1200��6Q    �� Orientation$ Vertical=�6^    J� RenderTransformOrigin$	 0,0&�6u   $	��Top=�6�   $��Right=�6�   .+�5'      �� $��27(�6   
�������$��Center=�69   $��Center=�6T   $��
Cards Logs��6q   5(      5)      �� 5*   
   $��1��6   $��2��6$   $��Stretch=�68   $��Stretch=�6V   .��5+      �� .@�5,      �� $��Cards��6   $��18(�6)   ���	#FF06A406$
��10pxq�6N   .��5-      �� .+�5.      "  FontAwesome.WPF.ImageAwesome  -   5        $��spinner2��5.   Z      Icon$ Spinner=�6*   	   Spin	 . $y�Visible=�6E   $��30��6j   
   
Foreground
 �	#FFFF01466�   &   System.Windows.Controls.DataGrid  5/      -   5          Name$ transTab��5/   ~      AutoGenerateColumns .  $��Stretch=�6@   $
��Bold"�6^   $��15(�6p   $	��500��6�   $
��auto��6�   
���   �   
IsReadOnly . ��6�   ��  �� Source$
 list��   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51   "      
FontWeight$
 Bold"�65      FontSize$ 15Q�6G   ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6U      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *ID+6x     52   "   $
 Bold"�65   $ 15Q�6G   $ Card Serial��6U    6j   �� *serial+  53   "   $
 Bold"�65   $ 15Q�6G   $ Staff ID��6U    6g   �� *	staffID+  54   "   $
 Bold"�65   $ 15Q�6G   $ Card Serial��6U    6j   �� *
cardSerial+  55   "   $
 Bold"�65   $ 15Q�6G   $ Card Synced��6U    6j   �� *
cardSynced+  56   "   $
 Bold"�65   $ 15Q�6G   $ 
Date Added��6U    6i   �� *	dateAdded+58      59      5:      �� 5;      $!��Failed and duplicated Cards��6   $��18(�6?   ���	#FFE01F15$
��10pxq�6d   .��5<      �� .+�5=        -   5        $��spinner3��5=   Z   $ Spinner=�6*   	 . $y�Visible=�6E   $��30��6j   
 �	#FFFF01466�     5>      -   5        $ 	transTab2��5>   ~    .  $��Stretch=�6@   $
��Bold"�6^   $��15(�6p   $	��500��6�   $
��auto��6�   
���   � . ��6�   �� $
 list�� 5?        5@   "   $
 Bold"�65   $ 15Q�6G   $ ID��6U    .  6a   �� *ID+6x     5A   "   $
 Bold"�65   $ 15Q�6G   $ Card Serial��6U    6j   �� *serial+  5B   "   $
 Bold"�65   $ 15Q�6G   $ Staff ID��6U    6g   �� *	staffID+  5C   "   $
 Bold"�65   $ 15Q�6G   $ Card Serial��6U    6j   �� *
cardSerial+  5D   "   $
 Bold"�65   $ 15Q�6G   $ Card Synced��6U    6j   �� *
cardSynced+  5E   "   $
 Bold"�65   $ 15Q�6G   $ 
Date Added��6U    6i   �� *	dateAdded+5G      5H      5I      5J      5K      �� 5L   
   $��2��6   $��2��6)   $ 
Horizontal=�66   .+�5M      �� $��Center=�6   .��6/   Total Cards Provisioned6H   �� 5N      -   5         ��Name$ total��5N   /   $��Center=�6   .��6>   06A   �� 5O      $��20 0 0 0q�6   $��Center=�6'   .��6B   Total Cards Synced6V   �� 5P      -   5        $ synced��5P   /   $��Center=�6   .��6?   06B   5Q      5R      5S      