   M S B A M L   `   `   `  ����F  Bprovisioner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:provisioner.pages.cardsprovisioner.pages.cards  5      &     provisioner.pages.cards.addCards   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:provisioner.pages.cards     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          N� Title$  addCards��5      .��5      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DataGrid.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6)   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.GroupBox.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6)   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml?�6)   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6)   %    5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��600 �6   6-    � RowDefinitions 5    
   �� 5!      $��50 �6   6*   �� 5"      $��* �6   6)   �� 5#      $��70 �6   6*   �� 5$      $��50 �6   6*   .+�5&   
   �� $��0��6   $��2��6"   $
��Left=�66   $	��300��6Q   .+�5'      �� $��35��6   ���#323542$��
0,0,-900,0q�6=   $
��1200��6Q    �� Orientation$ Vertical=�6^    J� RenderTransformOrigin$	 0,0&�6u   $	��Top=�6�   $��Right=�6�   .+�5(      �� $��27(�6   
�������$��Center=�69   $��Center=�6T   $��Create Cards��6q   5)      5*      �� 5+   
   $��1��6   $	��Top=�6"   $��Center=�6:   $��1��6W   $��	25,0,-5,0q�6g   $��2��6z   $	��580��6�   .+�5,      �� $��	0 100 0 0q�6   $��27(�6(   $��Bottom=�66   $��Center=�6Q   .��6n   	StaffID6w   �� 5-      -   5         ��Name$ staffID��5-      $��Center=�6'   $��Center=�6B   $	��300��6_   $��45��6k   $��27(�6w   
���   �$��1q�6�   6�   �� 5.      $��27(�6   $��Center=�6"   $��Center=�6=   .��6Z   
CardSerial6f   �� 5/      -   5        $ 
cardSerial��5/   N   $��Center=�6   $��Center=�61   	 �� 
IsReadOnly	 . $	��300��6t   $��45��6�   $��27(�6�   
���   �$��1q�6�   6�   �� 50      $ 
Horizontal=�6   $��Center=�62   $��Center=�6O   $��0 20 0 0q�6j   .+�51      �� ���	#FF870F0F$��40��60   $	��120��6<   $��15(�6H   
�������$��10q�6i   .��52      �� $ 
Horizontal=�6!   .+�53      "  FontAwesome.WPF.ImageAwesome  
   Icon$
 Remove=�6*   $��14��68      
Foreground
 �����$��Center=�6W   $��Center=�6t   6�   �� 54      $��15(�6    
�������$��Center=�6A   $��Center=�6^   .��6y   Clear Field6�   55      56      �� 57      -   5        ���	#FF1E9CB8$��40��57   0   $	��120��6<   $��15(�6H   
�������$��10q�6i   .��58      �� $ 
Horizontal=�6!   .+�59        $

 Save=�6*   $��14��66   
 �����$��Center=�6U   $��Center=�6r   6�   �� 5:      $��15(�6    
�������$��Center=�6A   $��Center=�6^   .��6y   
Save Field6�   5;      5<      5=      5?      �� 5@   
   $��2��6   $��2��6)   $��20 0 0 0q�66   .+�5A      �� $��Center=�6   $��Bottom=�66   $ 
Horizontal=�6Q   .+�5B      �� -   5         ��Name$ 
cardSyncer��5B   H   ���	#FF138CC5$	��200��60   $��50��6<   $��Right=�6\   .��5C      �� $ 
Horizontal=�6!   .+�5D        -   5          Name$ syncIcon��5D   7   $
 Cloud=�6*   $��20��6I   
 �����6j   �� 5E      
�������.��63   
Sync Cards6?   5F      5G      �� 5H      -   5        ���	#FF18189C$	��200��5H   0   $��50��6<   $��Right=�6H   .��5I      �� $ 
Horizontal=�6!   .+�5J        $

 List=�6*   $��20��66   
 �����6W   �� 5K      
�������.��63   
Go to logs6?   5L      5M      5N      5O      �� 5P   
   $��2��6   $��3��6)   $ 
Horizontal=�66   .+�5Q      �� $��Center=�6   .��6/   Total Cards Provisioned6H   �� 5R      -   5         ��Name$ total��5R   /   $��Center=�6   .��6>   06A   �� 5S      $��20 0 0 0q�6   $��Center=�6'   .��6B   Total Cards Synced6V   �� 5T      -	   5        $ synced��5T   /   $��Center=�6   .��6?   06B   5U      5V      5W      