﻿#pragma checksum "..\..\..\..\Seeker\ItemCompanyChatUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C823C6A1EA9847A351CF358D3B6FAA2015825A05"
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
    /// ItemCompanyChatUC
    /// </summary>
    public partial class ItemCompanyChatUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\..\Seeker\ItemCompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Seeker\ItemCompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Seeker\ItemCompanyChatUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheck;
        
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
            System.Uri resourceLocater = new System.Uri("/GoodJOB;component/seeker/itemcompanychatuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Seeker\ItemCompanyChatUC.xaml"
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
            this.btn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\Seeker\ItemCompanyChatUC.xaml"
            this.btn.Click += new System.Windows.RoutedEventHandler(this.btn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnCheck = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Seeker\ItemCompanyChatUC.xaml"
            this.btnCheck.Click += new System.Windows.RoutedEventHandler(this.btnCheck_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

