   M S B A M L   `   `   `  ����F  Bprovisioner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:provisioner.pagesprovisioner.pages  5          provisioner.pages.login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:provisioner.pages     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        N� Title$  login��5      .��5      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DataGrid.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6)   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.GroupBox.xaml?�6)   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6)   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml?�6)   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6)   %    5      .+�5   
   �� ._�5      �� $%��../Assets/Images/login_back.jpg��6   $
��Fill=�6=   6O   5      )  #MaterialDesignThemes.Wpf.DialogHost  5   
   -   5        $��Dialog1��5    Z      IsOpen .  $��Center=�6"   $��Center=�6?   $��
0,-150,0,0q�6i      DialogContent 5!      �� 5"       �� Orientation$ Vertical=�6   $��Center=�64   $��Center=�6O   $	��350��6m   $��10q�6y   .+�5#      �� -   5        $5��/pack://application:,,,/Assets/Images/cancel.png��5#       � Cursor$
 Hand��6U   $��
21,16,16,0q�6�   $��Right=�6�   $��30��6�   �� 5%      $��	0,20,0,10q�6   $��Center=�6/   $��30(�6J   $��Center=�6X   .��6u   Device IMEI6�   (  "MaterialDesignThemes.Wpf.ColorZone  5&         Mode$ Standard=�6/   	   CornerRadius$	 2��6?   
 K� ZIndex$
 1��6P   $��	10 0 0 10q�5'   $   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5(   $   $	��300��6U   .��5*      �� -   5        $
��IMEI��5*   a   $��8 0 0 0q�6#   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Enter IMEI��64   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5+   6   $��0q�6s   $	��300��5,   6   $��Center=�6B   $��30��6]   $��15(�6i   5.      �� 50      -   5        $
��Save��50   �   $	��300��6   $
��Save��6*   $��	10,0,0,40q�69   ���#909092$��20(�6b   
�������6�   52      54      #  MaterialDesignThemes.Wpf.Card  57   
   $	��500��6   ���#5B8BB3$	��320��6B   $��Center=�6R   $��Center=�6o   $��10q�6�   .��58        $	��600��6"   ���#CFCFCF$	��320��6F   .��59      �� $ Vertical=�6   .+�5:      �  � Orientation$ 
Horizontal=�6    .+�5;      �� $��../Assets/Images/key.png��6    $��20��6B   $��20��6M   $��	30,5,10,5q�6Y   6n   �� 5<      $��
Login Form��6    $��25(�65   $��Normal$�6C   ���#6464646n   5=      �� 5>      $��../Assets/Images/line.JPG��6   $	��600��6?   6M   �� 5?      -   5         ��Name$ statusMessage��5?   r   $��Center=�6!   $��Center=�6<   $ 
Horizontal=�6Y   $y�	Collapsed=�6�   .+�5@      "  FontAwesome.WPF.ImageAwesome  -   5          Name$ 	warningIC��5@   U      Icon$ Warning=�6*      
Foreground
 �  ��$��20��6J   $��Center=�6h   $��Center=�6�   6�   �� 5A      -   5         ��Name$ 
warningLab��5A       
���  ��$��20(�6E   .��6S   	Warning6\   5B      �� 5C      -   5        $ loaderIm��5C   !   $y�	Collapsed=�63   $��Center=�6J   $��Center=�6g   .+�5D        -	   5        $ loader��5D   a   $ Spinner=�6*      Spin .    SpinDuration$ 1Q�6E   $��30��6V   6a   5E      � 5F      $ 
Horizontal=�6    $��Center=�69   $��Center=�6T   $��25q�6q   .+�5G      ��  �� CornerRadius$ 
5, 0, 0, 5��6!   ���#4A4A4A �� Padding$ 2q�6P   ._�5H      �� ���#4A4A4A$��Center=�6>   $��Center=�6Y   $��45��6v   .+�5I   "   (� $��48��6*   $��48��65   .��5J   &   '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Account=�6>   
�������$��25��6`   5K   #   5L      5M      �� 5N      $ 
0, 5, 5, 0��6!   ���#616161$ 2q�6P   ._�5O        $��15,0,0,0q�67   $��45��6K   $ Standard=�6W   $	 3��6g   $��-5,0,0,0q�6x   $ Depth1=�6�   
������ .��5P   "   �� -
   5         ��Name$ username��5P   A   ���#616161$	��400��6S   $��18(�6_   $ Username or Email...��6n   
�������6�   5Q      5R      5S      � 5T      $ 
Horizontal=�6    $��Center=�69   $��Center=�6T   $��25q�6q   .+�5U      �� $ 
5, 0, 0, 5��6!   ���#4A4A4A$ 2q�6P   ._�5V      �� ���#4A4A4A$��Center=�6>   $��Center=�6Y   $��45��6v   .+�5W   "   (� $��48��6*   $��48��65   .��5X   &     $ 
KeyVariant=�6>   
�������$��25��6c   5Y   #   5Z      5[      �� 5\      $ 
0, 5, 5, 0��6!   ���#616161$ 2q�6P   ._�5]        $��15,0,0,0q�67   $��45��6K   $ Standard=�6W   $	 3��6g   $��-5,0,0,0q�6x   $ Depth1=�6�   
������ .��5^   "   G� -   5         G�Name$ password��5^   C   ���#616161$	��400��6U   $��18(�6a   $ Password here��6p   
������� � ToolTip$ Enter Password��6�   5_      5`      5a      �� 5e      $ 
Horizontal=�6!   $��0,0,0,20q�6:   .+�5g      �� $ Vertical=�6%   $��Right=�6=   .+�5h      �� -   5         ��Name$ BtnLogin��5h   h   $	��200��6%   $��Sign-In Now��61   $��40��6G   ���#3B88D6$��Right=�6�   
�������$��	210,0,0,0q�6�   6�   5i      5j      5l      5n      5o      5p      5q      