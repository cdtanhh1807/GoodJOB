﻿#pragma checksum "..\..\..\..\Home\SignUpWD.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E851462177C7E6FA622E9B9452A9C04066E80366"
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
    /// SignUpWD
    /// </summary>
    public partial class SignUpWD : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbUserName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txblPass;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwPass;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbCompany;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbSeeker;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignUp;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbAccID;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Home\SignUpWD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GoodJOB;component/home/signupwd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Home\SignUpWD.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\Home\SignUpWD.xaml"
            ((GoodJOB.SignUpWD)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\..\..\Home\SignUpWD.xaml"
            this.txbUserName.GotFocus += new System.Windows.RoutedEventHandler(this.txbUserName_GotFocus);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\..\Home\SignUpWD.xaml"
            this.txbUserName.LostFocus += new System.Windows.RoutedEventHandler(this.txbUserName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txblPass = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.pwPass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 65 "..\..\..\..\Home\SignUpWD.xaml"
            this.pwPass.GotFocus += new System.Windows.RoutedEventHandler(this.pwPass_GotFocus);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\..\Home\SignUpWD.xaml"
            this.pwPass.LostFocus += new System.Windows.RoutedEventHandler(this.pwPass_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbCompany = ((System.Windows.Controls.CheckBox)(target));
            
            #line 66 "..\..\..\..\Home\SignUpWD.xaml"
            this.cbCompany.Checked += new System.Windows.RoutedEventHandler(this.cbCompany_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbSeeker = ((System.Windows.Controls.CheckBox)(target));
            
            #line 67 "..\..\..\..\Home\SignUpWD.xaml"
            this.cbSeeker.Checked += new System.Windows.RoutedEventHandler(this.cbSeeker_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\Home\SignUpWD.xaml"
            this.btnSignUp.Click += new System.Windows.RoutedEventHandler(this.btnSignUp_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txbAccID = ((System.Windows.Controls.TextBox)(target));
            
            #line 69 "..\..\..\..\Home\SignUpWD.xaml"
            this.txbAccID.GotFocus += new System.Windows.RoutedEventHandler(this.txbAccID_GotFocus);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\..\Home\SignUpWD.xaml"
            this.txbAccID.LostFocus += new System.Windows.RoutedEventHandler(this.txbAccID_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\Home\SignUpWD.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

