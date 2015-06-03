﻿#pragma checksum "..\..\BlockWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D003BC0F39D0F7AD506A832ACC5474C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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
    /// BlockWindow
    /// </summary>
    public partial class BlockWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 127 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox floorNameComboBox;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox newblockidTextBox;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox newBlockNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button @new;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveNewBlockButton;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateNewBlockButton;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteNewBlockButton;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshButton;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mydataGrid1;
        
        #line default
        #line hidden
        
        
        #line 304 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previouswindowButton;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 335 "..\..\BlockWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextwindowButton;
        
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
            System.Uri resourceLocater = new System.Uri("/HallManagementSystem;component/blockwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BlockWindow.xaml"
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
            
            #line 4 "..\..\BlockWindow.xaml"
            ((HallManagementSystem.BlockWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.mydataGrid1_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.floorNameComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.newblockidTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.newBlockNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.@new = ((System.Windows.Controls.Button)(target));
            
            #line 192 "..\..\BlockWindow.xaml"
            this.@new.Click += new System.Windows.RoutedEventHandler(this.new_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.saveNewBlockButton = ((System.Windows.Controls.Button)(target));
            
            #line 210 "..\..\BlockWindow.xaml"
            this.saveNewBlockButton.Click += new System.Windows.RoutedEventHandler(this.saveNewBlockButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.updateNewBlockButton = ((System.Windows.Controls.Button)(target));
            
            #line 226 "..\..\BlockWindow.xaml"
            this.updateNewBlockButton.Click += new System.Windows.RoutedEventHandler(this.updateNewBlockButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.deleteNewBlockButton = ((System.Windows.Controls.Button)(target));
            
            #line 243 "..\..\BlockWindow.xaml"
            this.deleteNewBlockButton.Click += new System.Windows.RoutedEventHandler(this.deleteNewBlockButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.refreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 259 "..\..\BlockWindow.xaml"
            this.refreshButton.Click += new System.Windows.RoutedEventHandler(this.refreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.mydataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 272 "..\..\BlockWindow.xaml"
            this.mydataGrid1.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.mydataGrid1_SelectedCellsChanged_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.previouswindowButton = ((System.Windows.Controls.Button)(target));
            
            #line 306 "..\..\BlockWindow.xaml"
            this.previouswindowButton.Click += new System.Windows.RoutedEventHandler(this.previouswindowButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 323 "..\..\BlockWindow.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.nextwindowButton = ((System.Windows.Controls.Button)(target));
            
            #line 339 "..\..\BlockWindow.xaml"
            this.nextwindowButton.Click += new System.Windows.RoutedEventHandler(this.nextwindowButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

