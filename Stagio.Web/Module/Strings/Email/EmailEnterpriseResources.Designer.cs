﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stagio.Web.Module.Strings.Email {
    using System;


    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
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
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
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
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
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
        ///   Recherche une chaîne localisée semblable à &lt;h3&gt;Stagio&lt;/h3&gt;&lt;p&gt; Bonjour, &lt;/p&gt;&lt;br/&gt;Vous êtes invité à vous inscrire au site Stagio..
        /// </summary>
        internal static string InviteCoworker {
            get {
                return ResourceManager.GetString("InviteCoworker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pour vous créer un compte, copier-coller ce lien: &lt;a href =&quot;http://jenkins.cegep-ste-foy.qc.ca/thomarelau/ContactEnterprise/Reactivate?token={0}&quot;/&gt;jenkins.cegep-ste-foy.qc.ca/thomarelau/ContactEnterprise/Reactivate?token={0}&lt;/a&gt;.
        /// </summary>
        internal static string InviteLink {
            get {
                return ResourceManager.GetString("InviteLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pour vous créer un compte, copier-coller ce lien: &lt;a href =&quot;http://jenkins.cegep-ste-foy.qc.ca/thomarelau/ContactEnterprise/Reactivate?token={0}&quot;/&gt;jenkins.cegep-ste-foy.qc.ca/thomarelau/ContactEnterprise/Reactivate?token={0}&lt;/a&gt;.
        /// </summary>
        internal static string InviteLinkCoworker {
            get {
                return ResourceManager.GetString("InviteLinkCoworker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à &lt;h3&gt;Stagio&lt;/h3&gt;&lt;p&gt; Bonjour, &lt;/p&gt;&lt;br/&gt;Un coordonateur de stage vous invite à vous inscrire au site Stagio. &lt;/br&gt;.
        /// </summary>
        internal static string InviteMessageBody {
            get {
                return ResourceManager.GetString("InviteMessageBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Invitation du Cégep de Sainte-Foy.
        /// </summary>
        internal static string InviteSubject {
            get {
                return ResourceManager.GetString("InviteSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à &lt;/br&gt;&lt;/br&gt; &lt;h3&gt;Message:&lt;/h3&gt;&lt;/br&gt;.
        /// </summary>
        internal static string MessageHeader {
            get {
                return ResourceManager.GetString("MessageHeader", resourceCulture);
            }
        }
    }
}
