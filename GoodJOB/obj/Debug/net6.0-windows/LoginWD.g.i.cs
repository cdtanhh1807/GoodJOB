﻿#pragma checksum "..\..\..\LoginWD.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53689111F52480F56D37C0BA0234CB7EAC9F8605"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GoodJOB;
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


namespace GoodJOB {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 96 "..\..\..\LoginWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbUserName;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\LoginWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txblPass;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\LoginWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwPass;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GoodJOB;component/loginwd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LoginWD.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\LoginWD.xaml"
            this.txbUserName.GotFocus += new System.Windows.RoutedEventHandler(this.txbUserName_GotFocus);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\LoginWD.xaml"
            this.txbUserName.LostFocus += new System.Windows.RoutedEventHandler(this.txbUserName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txblPass = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.pwPass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 98 "..\..\..\LoginWD.xaml"
            this.pwPass.GotFocus += new System.Windows.RoutedEventHandler(this.pwPass_GotFocus);
            
            #line default
            #line hidden
            
            #line 98 "..\..\..\LoginWD.xaml"
            this.pwPass.LostFocus += new System.Windows.RoutedEventHandler(this.pwPass_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

