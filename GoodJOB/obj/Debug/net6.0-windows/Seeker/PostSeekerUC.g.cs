﻿#pragma checksum "..\..\..\..\Seeker\PostSeekerUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "836712AE4EDF975E5117A09B71549415727BBF55"
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
    /// PostSeekerUC
    /// </summary>
    public partial class PostSeekerUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbJob;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbField;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbTime;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbExp;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSalary;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSkill;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPost;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Seeker\PostSeekerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheckInfor;
        
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
            System.Uri resourceLocater = new System.Uri("/GoodJOB;component/seeker/postseekeruc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Seeker\PostSeekerUC.xaml"
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
            this.txbJob = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txbField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbExp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txbSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbSkill = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnPost = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Seeker\PostSeekerUC.xaml"
            this.btnPost.Click += new System.Windows.RoutedEventHandler(this.btnPost_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Seeker\PostSeekerUC.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnCheckInfor = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\Seeker\PostSeekerUC.xaml"
            this.btnCheckInfor.Click += new System.Windows.RoutedEventHandler(this.btnCheckInfor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

