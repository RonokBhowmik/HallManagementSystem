﻿#pragma checksum "..\..\NewSeatRentWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DFF71D3D0090F7EDFF828E3F82310693"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace HallManagementSystem {
    
    
    /// <summary>
    /// NewSeatRentWindow
    /// </summary>
    public partial class NewSeatRentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 121 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox seatRentIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox seatRentTextBox;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveNewBlockButton;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateNewBlockButton;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshButton;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid seatRentdataGrid;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\NewSeatRentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/HallManagementSystem;component/newseatrentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewSeatRentWindow.xaml"
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
            this.seatRentIdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.seatRentTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.saveNewBlockButton = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\NewSeatRentWindow.xaml"
            this.saveNewBlockButton.Click += new System.Windows.RoutedEventHandler(this.saveNewBlockButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.updateNewBlockButton = ((System.Windows.Controls.Button)(target));
            
            #line 181 "..\..\NewSeatRentWindow.xaml"
            this.updateNewBlockButton.Click += new System.Windows.RoutedEventHandler(this.updateNewBlockButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.refreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 196 "..\..\NewSeatRentWindow.xaml"
            this.refreshButton.Click += new System.Windows.RoutedEventHandler(this.refreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.seatRentdataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 207 "..\..\NewSeatRentWindow.xaml"
            this.seatRentdataGrid.Loaded += new System.Windows.RoutedEventHandler(this.seatRentdataGrid_Loaded);
            
            #line default
            #line hidden
            
            #line 208 "..\..\NewSeatRentWindow.xaml"
            this.seatRentdataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.seatRentdataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 254 "..\..\NewSeatRentWindow.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
