﻿#pragma checksum "..\..\..\ManagePostUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CD76F0A9851A5A6568575708A49CA0D4A6149B67"
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
    /// ManagePostUC
    /// </summary>
    public partial class ManagePostUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 209 "..\..\..\ManagePostUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scr;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\ManagePostUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrap;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\ManagePostUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbl;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\..\ManagePostUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPre;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\ManagePostUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
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
            System.Uri resourceLocater = new System.Uri("/GoodJOB;V1.0.0.0;component/managepostuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManagePostUC.xaml"
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
            
            #line 206 "..\..\..\ManagePostUC.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.scr = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 209 "..\..\..\ManagePostUC.xaml"
            this.scr.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.scr_PreviewMouseWheel);
            
            #line default
            #line hidden
            
            #line 209 "..\..\..\ManagePostUC.xaml"
            this.scr.Loaded += new System.Windows.RoutedEventHandler(this.scr_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.wrap = ((System.Windows.Controls.WrapPanel)(target));
            
            #line 210 "..\..\..\ManagePostUC.xaml"
            this.wrap.Loaded += new System.Windows.RoutedEventHandler(this.wrap_Loaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btnPre = ((System.Windows.Controls.Button)(target));
            
            #line 215 "..\..\..\ManagePostUC.xaml"
            this.btnPre.Click += new System.Windows.RoutedEventHandler(this.btnPre_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 216 "..\..\..\ManagePostUC.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.btnNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

