﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stagio.Web.Module.Strings.Controller
{


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
    internal class StudentResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StudentResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Stagio.Web.Module.Strings.Controller.StudentResources", typeof(StudentResources).Assembly);
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
        ///   Looks up a localized string similar to Votre matricule est déja utilisé..
        /// </summary>
        internal static string MatriculeAlreadyUsed {
            get {
                return ResourceManager.GetString("MatriculeAlreadyUsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Votre matricule ne figure pas dans la liste des matricules autorisés..
        /// </summary>
        internal static string MatriculeNotFound {
            get {
                return ResourceManager.GetString("MatriculeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Il n&apos;y a pas de fichier à importer.
        /// </summary>
        internal static string NoFileToUpload {
            get {
                return ResourceManager.GetString("NoFileToUpload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to L&apos;ancien mot de passe n&apos;est pas valide..
        /// </summary>
        internal static string OldPasswordInvalid {
            get {
                return ResourceManager.GetString("OldPasswordInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ce n&apos;est pas un fichier csv.
        /// </summary>
        internal static string WrongFileType {
            get {
                return ResourceManager.GetString("WrongFileType", resourceCulture);
            }
        }
    }
}
