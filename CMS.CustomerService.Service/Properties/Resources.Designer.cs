﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DUC.CMS.CustomerService.Service.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DUC.CMS.CustomerService.Service.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Delete Beneficiary is not allowed.
        /// </summary>
        internal static string DeleteBeneficiaryValidationMessage {
            get {
                return ResourceManager.GetString("DeleteBeneficiaryValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete Token is not allowed.
        /// </summary>
        internal static string DeleteTokenValidationMessage {
            get {
                return ResourceManager.GetString("DeleteTokenValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Balance notification threshold should be lesser than suspension threshold.
        /// </summary>
        internal static string PostPaidMessge {
            get {
                return ResourceManager.GetString("PostPaidMessge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Balance notification threshold should be more than suspension threshold.
        /// </summary>
        internal static string PrePaidMessage {
            get {
                return ResourceManager.GetString("PrePaidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid recharge amount.
        /// </summary>
        internal static string RechargeAmountValidationMessage {
            get {
                return ResourceManager.GetString("RechargeAmountValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The from and to date should differ max by 6 months only.
        /// </summary>
        internal static string UpdateCustomerStatusDateRangeMessage {
            get {
                return ResourceManager.GetString("UpdateCustomerStatusDateRangeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to From date and To date are mandatory.
        /// </summary>
        internal static string UpdateCustomerStatusDateValidationMessage {
            get {
                return ResourceManager.GetString("UpdateCustomerStatusDateValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Update PIN is not allowed.
        /// </summary>
        internal static string UpdatePINMessage {
            get {
                return ResourceManager.GetString("UpdatePINMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Restriction Group is not allowed.
        /// </summary>
        internal static string UpdateTokenInfoDriverCardMessage {
            get {
                return ResourceManager.GetString("UpdateTokenInfoDriverCardMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Card Serial is mandatory.
        /// </summary>
        internal static string UpdateTokenInfoEmirateIDMessage {
            get {
                return ResourceManager.GetString("UpdateTokenInfoEmirateIDMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle information needs to be provided.
        /// </summary>
        internal static string UpdateTokenInfoVehicleTagMessage {
            get {
                return ResourceManager.GetString("UpdateTokenInfoVehicleTagMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot have a driver or Odometer with this token type.
        /// </summary>
        internal static string UpdateTokenRestriction {
            get {
                return ResourceManager.GetString("UpdateTokenRestriction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Product, Quantity and Uplift price are mandatory.
        /// </summary>
        internal static string UpliftDiscountProductMessage {
            get {
                return ResourceManager.GetString("UpliftDiscountProductMessage", resourceCulture);
            }
        }
    }
}