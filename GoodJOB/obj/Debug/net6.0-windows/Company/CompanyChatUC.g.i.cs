﻿#pragma checksum "..\..\..\..\Company\CompanyChatUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9D90B4975DA75520EC952B183010E71F1002EE08"
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
    /// CompanyChat
    /// </summary>
    public partial class CompanyChat : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stack;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bd;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bdInput;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbInput;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bdSend;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSend;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scr;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Company\CompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackChat;
        
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
            System.Uri resourceLocater = new System.Uri("/GoodJOB;component/company/companychatuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Company\CompanyChatUC.xaml"
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
            
            #line 33 "..\..\..\..\Company\CompanyChatUC.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.stack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.bd = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.bdInput = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.txbInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\..\Company\CompanyChatUC.xaml"
            this.txbInput.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txbInput_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\Company\CompanyChatUC.xaml"
            this.txbInput.GotFocus += new System.Windows.RoutedEventHandler(this.txbInput_GotFocus);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\Company\CompanyChatUC.xaml"
            this.txbInput.LostFocus += new System.Windows.RoutedEventHandler(this.txbInput_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bdSend = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.btnSend = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Company\CompanyChatUC.xaml"
            this.btnSend.Click += new System.Windows.RoutedEventHandler(this.btnSend_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txbName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.scr = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 10:
            this.stackChat = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

