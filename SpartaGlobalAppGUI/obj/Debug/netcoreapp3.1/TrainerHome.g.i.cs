﻿#pragma checksum "..\..\..\TrainerHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A3CB5F57DC957AA36E01282EECC7C7C8E11AC869"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SpartaGlobalAppGUI;
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


namespace SpartaGlobalAppGUI {
    
    
    /// <summary>
    /// TrainerHome
    /// </summary>
    public partial class TrainerHome : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox QList;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox TraineeList;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox TraineeQuestionListbox;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserWelcome;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SpartaButton;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SelectedQTB;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CategoryTB;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Response;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Feedback;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StudentName;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StudentID;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\TrainerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StudentCourse;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpartaGlobalAppGUI;V1.0.0.0;component/trainerhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TrainerHome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 33 "..\..\..\TrainerHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.createQ_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QList = ((System.Windows.Controls.ListBox)(target));
            
            #line 42 "..\..\..\TrainerHome.xaml"
            this.QList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.QList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TraineeList = ((System.Windows.Controls.ListBox)(target));
            
            #line 43 "..\..\..\TrainerHome.xaml"
            this.TraineeList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TraineeListbox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 44 "..\..\..\TrainerHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditQ_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 53 "..\..\..\TrainerHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PoseQ_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 62 "..\..\..\TrainerHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteQ_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 71 "..\..\..\TrainerHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TraineeQuestionListbox = ((System.Windows.Controls.ListBox)(target));
            
            #line 80 "..\..\..\TrainerHome.xaml"
            this.TraineeQuestionListbox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TraineeQuestionListbox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 81 "..\..\..\TrainerHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Feedback_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.UserWelcome = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.SpartaButton = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\..\TrainerHome.xaml"
            this.SpartaButton.Click += new System.Windows.RoutedEventHandler(this.SpartaButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.SelectedQTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.CategoryTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.Response = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.Feedback = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.StudentName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.StudentID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.StudentCourse = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

