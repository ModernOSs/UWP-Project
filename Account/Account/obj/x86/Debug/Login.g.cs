﻿#pragma checksum "C:\Users\liuren\Desktop\Account\Account\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "169D8AFCC95A97CB470980F536CC2480"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Account
{
    partial class Login : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.loginView = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.registerView = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.registerErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.toLogin = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 65 "..\..\..\Login.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.toLogin).Click += this.toLogin_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.submit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 66 "..\..\..\Login.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.submit).Click += this.submit_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.password_ = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7:
                {
                    this.username_ = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.loginErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.progressBar = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 10:
                {
                    this.auto = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 11:
                {
                    this.toRegister = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 39 "..\..\..\Login.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.toRegister).Click += this.toRegister_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.login = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 40 "..\..\..\Login.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.login).Click += this.login_Click;
                    #line default
                }
                break;
            case 13:
                {
                    this.password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 14:
                {
                    this.username = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

