﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JonCloud.Ztwedit.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("JonCloud.Ztwedit.Properties.Resources", typeof(Resources).Assembly);
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
        
        internal static System.Drawing.Bitmap Link {
            get {
                object obj = ResourceManager.GetObject("Link", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Notes {
            get {
                object obj = ResourceManager.GetObject("Notes", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Open {
            get {
                object obj = ResourceManager.GetObject("Open", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap OverworldTiles {
            get {
                object obj = ResourceManager.GetObject("OverworldTiles", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Properties {
            get {
                object obj = ResourceManager.GetObject("Properties", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Save {
            get {
                object obj = ResourceManager.GetObject("Save", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap SaveAll {
            get {
                object obj = ResourceManager.GetObject("SaveAll", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to February 22nd 2012
        ///Initial release for ztwedit.
        ///Support for opening binary ROM images of with a size of 0x40C8A.
        ///Support for viewing the following overworld tile maps as read only:
        ///* Death Mountain
        ///* East Hyrule
        ///* Maze Island
        ///* West Hyrule.
        /// </summary>
        internal static string Version_1_0_0 {
            get {
                return ResourceManager.GetString("Version_1_0_0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Tabs can now be closed by middle clicking on them.
        ///The tile layout for overworld maps can now be maintained. There are limitations based upon the ROM&apos;s data structure that allows only a certain amount of tiles to be used.  To accomodate this a warning is displayed if too many tiles are used.
        ///The menu item &quot;File\Close View&quot; has been renamed to &quot;File\Close Document.&quot;
        ///Documents have been restricted to only be allowed to open once. For example the East Hyrule Overworld Map may not be opened more than once. [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Version_1_1_0 {
            get {
                return ResourceManager.GetString("Version_1_1_0", resourceCulture);
            }
        }
    }
}
