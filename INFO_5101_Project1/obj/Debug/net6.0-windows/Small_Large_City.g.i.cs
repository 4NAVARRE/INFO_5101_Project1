#pragma checksum "..\..\..\Small_Large_City.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EF92D4CEC90A9282F07AEEEC78042795F2F5119F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using INFO_5101_Project1;
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


namespace INFO_5101_Project1 {
    
    
    /// <summary>
    /// Small_Large_City
    /// </summary>
    public partial class Small_Large_City : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Small_Large_City.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LargestCity;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Small_Large_City.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SmallestCity;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Small_Large_City.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchInfo_CitySize;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Small_Large_City.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProvinceCombo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/INFO_5101_Project1;component/small_large_city.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Small_Large_City.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LargestCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.SmallestCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SearchInfo_CitySize = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Small_Large_City.xaml"
            this.SearchInfo_CitySize.Click += new System.Windows.RoutedEventHandler(this.SearchInfo_CitySize_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ProvinceCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\Small_Large_City.xaml"
            this.ProvinceCombo.Loaded += new System.Windows.RoutedEventHandler(this.ProvinceCombo_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

