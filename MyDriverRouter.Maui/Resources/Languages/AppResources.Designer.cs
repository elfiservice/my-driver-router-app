﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyDriverRouter.Maui.Resources.Languages {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("MyDriverRouter.Maui.Resources.Languages.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string SettingPage_Title {
            get {
                return ResourceManager.GetString("SettingPage_Title", resourceCulture);
            }
        }
        
        internal static string SettingPage_Input_Placeholder_Server {
            get {
                return ResourceManager.GetString("SettingPage_Input_Placeholder_Server", resourceCulture);
            }
        }
        
        internal static string SettingPage_Input_Placeholder_SelectTheLanguage {
            get {
                return ResourceManager.GetString("SettingPage_Input_Placeholder_SelectTheLanguage", resourceCulture);
            }
        }
        
        internal static string SettingPage_Button_Save {
            get {
                return ResourceManager.GetString("SettingPage_Button_Save", resourceCulture);
            }
        }
    }
}
