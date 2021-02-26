﻿#pragma checksum "..\..\DockablePane.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C5517AFEAEF8E4A23D448CFD2A60815B15D5A2B6ACF42819ADE7A3065658109"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DockingLibrary;
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


namespace DockingLibrary {
    
    
    /// <summary>
    /// DockablePane
    /// </summary>
    public partial class DockablePane : DockingLibrary.Pane, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 159 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PaneHeader;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid btnClose;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid btnAutoHide;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid btnMenu;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuFloatingWindow;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuDockedWindow;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuTabbedDocument;
        
        #line default
        #line hidden
        
        
        #line 247 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAutoHide;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuClose;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTitle;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentPresenter cpClientWindowContent;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\DockablePane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tbcContents;
        
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
            System.Uri resourceLocater = new System.Uri("/DockingLibrary;component/dockablepane.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DockablePane.xaml"
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
            case 2:
            this.PaneHeader = ((System.Windows.Controls.Border)(target));
            
            #line 159 "..\..\DockablePane.xaml"
            this.PaneHeader.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnHeaderMouseDown);
            
            #line default
            #line hidden
            
            #line 159 "..\..\DockablePane.xaml"
            this.PaneHeader.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.OnHeaderMouseUp);
            
            #line default
            #line hidden
            
            #line 159 "..\..\DockablePane.xaml"
            this.PaneHeader.MouseMove += new System.Windows.Input.MouseEventHandler(this.OnHeaderMouseMove);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnClose = ((System.Windows.Controls.Grid)(target));
            
            #line 202 "..\..\DockablePane.xaml"
            this.btnClose.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnCloseMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAutoHide = ((System.Windows.Controls.Grid)(target));
            
            #line 212 "..\..\DockablePane.xaml"
            this.btnAutoHide.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnAutoHideMouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMenu = ((System.Windows.Controls.Grid)(target));
            
            #line 230 "..\..\DockablePane.xaml"
            this.btnMenu.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnMenuMouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 243 "..\..\DockablePane.xaml"
            ((System.Windows.Controls.ContextMenu)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.OnBtnMenuPopup);
            
            #line default
            #line hidden
            return;
            case 7:
            this.menuFloatingWindow = ((System.Windows.Controls.MenuItem)(target));
            
            #line 244 "..\..\DockablePane.xaml"
            this.menuFloatingWindow.Click += new System.Windows.RoutedEventHandler(this.OnDockingMenu);
            
            #line default
            #line hidden
            return;
            case 8:
            this.menuDockedWindow = ((System.Windows.Controls.MenuItem)(target));
            
            #line 245 "..\..\DockablePane.xaml"
            this.menuDockedWindow.Click += new System.Windows.RoutedEventHandler(this.OnDockingMenu);
            
            #line default
            #line hidden
            return;
            case 9:
            this.menuTabbedDocument = ((System.Windows.Controls.MenuItem)(target));
            
            #line 246 "..\..\DockablePane.xaml"
            this.menuTabbedDocument.Click += new System.Windows.RoutedEventHandler(this.OnDockingMenu);
            
            #line default
            #line hidden
            return;
            case 10:
            this.menuAutoHide = ((System.Windows.Controls.MenuItem)(target));
            
            #line 247 "..\..\DockablePane.xaml"
            this.menuAutoHide.Click += new System.Windows.RoutedEventHandler(this.OnDockingMenu);
            
            #line default
            #line hidden
            return;
            case 11:
            this.menuClose = ((System.Windows.Controls.MenuItem)(target));
            
            #line 248 "..\..\DockablePane.xaml"
            this.menuClose.Click += new System.Windows.RoutedEventHandler(this.OnDockingMenu);
            
            #line default
            #line hidden
            return;
            case 12:
            this.tbTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.cpClientWindowContent = ((System.Windows.Controls.ContentPresenter)(target));
            return;
            case 14:
            this.tbcContents = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 49 "..\..\DockablePane.xaml"
            ((System.Windows.Controls.ContentPresenter)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnTabItemMouseDown);
            
            #line default
            #line hidden
            
            #line 49 "..\..\DockablePane.xaml"
            ((System.Windows.Controls.ContentPresenter)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.OnTabItemMouseUp);
            
            #line default
            #line hidden
            
            #line 49 "..\..\DockablePane.xaml"
            ((System.Windows.Controls.ContentPresenter)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.OnTabItemMouseMove);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

