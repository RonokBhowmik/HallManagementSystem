﻿#pragma checksum "..\..\NewProvostEntryWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A4D0C6568217650475249D9B3D50168E"
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
    /// NewProvostEntryWindow
    /// </summary>
    public partial class NewProvostEntryWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 124 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userPasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshButton;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\NewProvostEntryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mydataGrid1;
        
        #line default
        #line hidden
        
        
        #line 305 "..\..\NewProvostEntryWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/HallManagementSystem;component/newprovostentrywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewProvostEntryWindow.xaml"
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
            this.UserTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.userNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.userPasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 190 "..\..\NewProvostEntryWindow.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            
            #line 206 "..\..\NewProvostEntryWindow.xaml"
            this.updateButton.Click += new System.Windows.RoutedEventHandler(this.updateButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 223 "..\..\NewProvostEntryWindow.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.refreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\NewProvostEntryWindow.xaml"
            this.refreshButton.Click += new System.Windows.RoutedEventHandler(this.refreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mydataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 251 "..\..\NewProvostEntryWindow.xaml"
            this.mydataGrid1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.mydataGrid1_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 252 "..\..\NewProvostEntryWindow.xaml"
            this.mydataGrid1.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.mydataGrid1_SelectedCellsChanged_1);
            
            #line default
            #line hidden
            
            #line 253 "..\..\NewProvostEntryWindow.xaml"
            this.mydataGrid1.Loaded += new System.Windows.RoutedEventHandler(this.mydataGrid1_Loaded);
            
            #line default
            #line hidden
            return;
            case 9:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 309 "..\..\NewProvostEntryWindow.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

