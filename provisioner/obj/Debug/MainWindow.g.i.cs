﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BA17AB88057E017260E2CC95ECEC2D0D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using HamburgerMenu;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using provisioner;


namespace provisioner {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenu hamMenu;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem LogIn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem cards;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ContentPage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/provisioner;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\MainWindow.xaml"
            ((provisioner.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MainWindow_OnLoaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\MainWindow.xaml"
            ((provisioner.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_OnClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.hamMenu = ((HamburgerMenu.HamburgerMenu)(target));
            return;
            case 3:
            this.LogIn = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 35 "..\..\MainWindow.xaml"
            this.LogIn.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Home_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cards = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 40 "..\..\MainWindow.xaml"
            this.cards.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.cards_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 45 "..\..\MainWindow.xaml"
            ((HamburgerMenu.HamburgerMenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.staffs_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 50 "..\..\MainWindow.xaml"
            ((HamburgerMenu.HamburgerMenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.logOut_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ContentPage = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

