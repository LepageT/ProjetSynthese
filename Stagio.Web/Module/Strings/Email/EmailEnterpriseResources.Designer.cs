﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stagio.Web.Module.Strings.Email {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class EmailEnterpriseResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EmailEnterpriseResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Stagio.Web.Module.Strings.Email.EmailEnterpriseResources", typeof(EmailEnterpriseResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://thomarelau.local/Enterprise/Create?Email=.
        /// </summary>
        internal static string InviteLink {
            get {
                return ResourceManager.GetString("InviteLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Un coordonateur de stage vous invite à vous inscrire au site Stagio:.
        /// </summary>
        internal static string InviteMessageBody {
            get {
                return ResourceManager.GetString("InviteMessageBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invitation du Cégep de Sainte-Foy.
        /// </summary>
        internal static string InviteSubject {
            get {
                return ResourceManager.GetString("InviteSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;/br&gt;&lt;/br&gt; &lt;h3&gt;Message:&lt;/h3&gt;&lt;/br&gt;.
        /// </summary>
        internal static string MessageHeader {
            get {
                return ResourceManager.GetString("MessageHeader", resourceCulture);
            }
        }
    }
}
