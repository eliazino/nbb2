   M S B A M L   `   `   `  ����F  Bprovisioner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:provisionerprovisioner  5   	   H DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu 5   	       provisioner.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:provisioner     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5	   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � WindowState$ 	Maximized=�65   .��5      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DataGrid.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6)   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.GroupBox.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6)   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml?�6)   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6)   %    5       � ColumnDefinitions 5   
   �� 5      $��0.15* �6   6/   �� 5      $��0.95* �6   6/   .+�5    
   � $��0��6   .+�5!      !  HamburgerMenu.HamburgerMenu  -   5          Name$ hamMenu��5!   *   ���#323542   MenuIconColor
 �����   SelectionIndicatorColor
 �����	   MenuItemForeground
	 �����$
��Left=�6�   
 � Cursor$

 Hand��6�      Content 5#      %  HamburgerMenu.HamburgerMenuItem  -   5        $��LogIn��5#   �   $��80��66   $

 Hand��6D   $��80��6R      Icon$2 ,pack://application:,,,/Assets/Images/key.png��6b      Text$ Log in��6�   .��5$      �� .+�5%      �� 
���  ��.��65   Log In6=   5&      5'        5(      -   5        $��cards��5(   a   $��80��66   $

 Hand��6D   $��80��6R   $3 -pack://application:,,,/Assets/Images/card.png��6p   $ Cards��6�      SelectionCommand 6�   ��  �� ElementName$ this_��.��5)      �� .+�5*      �� 
���  ��.��65   Cards6<   5+      5,        5-      -   5        $��80��5-   6   $

 Hand��6D   $��80��6R   $6 0pack://application:,,,/Assets/Images/user.fw.png��6b   $ Staffs��6�    6�   �� $ this_��.��5.      �� .+�5/      �� 
���  ��.��65   Staffs6=   50      51        52      -   5        $��80��52   6   $

 Hand��6D   $��80��6R   $5 /pack://application:,,,/Assets/Images/logout.png��6b   $ Log out��6�    6�   �� $ this_��.��53      �� .+�54      �� 
���  ��.��65   	Log out6>   55      56      58      59      � 5:   
   $��1��6   .+�5;      � .+�5<       � -   5          �Name$ ContentPage��5<   6   $��Stretch=�6     � NavigationUIVisibility$ Hidden=�6K   $��Visible=�6k   ��. $�� ��5>      5?      5@      5A      5B      