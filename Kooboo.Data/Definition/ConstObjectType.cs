//Copyright (c) 2018 Yardi Technology Limited. Http://www.kooboo.com 
//All rights reserved.
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace Kooboo
{
    /// <summary>
    /// the defined object type of entire kooboo system. 
    /// </summary>
    public class ConstObjectType
    {
        public const byte Page = 91;
        public const byte Script = 92;
        public const byte Style = 93;
        public const byte Layout = 98;
        public const byte Label = 99;
        public const byte View = 10;
        public const byte HtmlBlock = 11;
        public const byte CssRule = 13;
        public const byte File = 14;
        public const byte Route = 15;
        public const byte Relation = 16;
        public const byte Image = 17;
        public const byte TextContent = 18;
        public const byte Binding = 19;
        public const byte Menu = 21;
        public const byte WebSite = 22;
        public const byte User = 23;
        public const byte ContentFolder = 24;
        public const byte Domain = 25;
        public const byte UserGroup = 26;
        // public const byte SyncItem = 27; 
        public const byte ExternalResource = 28;
        public const byte Thumbnail = 29;
        public const byte Folder = 30;
        public const byte CssDeclaration = 31;
        public const byte Notification = 32;
        public const byte DataMethodSetting = 33;
        public const byte Link = 34;
        public const byte Embedded = 35; // embed video or flash.
        public const byte Form = 36;
        public const byte SyncSetting = 37;
        public const byte ContentCategory = 38;
        public const byte ContentType = 39;
        public const byte FormValue = 41;
        public const byte ViewDataMethod = 42;
        public const byte DomElement = 43;
        public const byte Unknown = 9;
        public const byte KoobooSystem = 44;
        public const byte ResourceGroup = 45;
        public const byte Synchronization = 46;
        public const byte DiskSync = 47;

        public const byte SiteCluster = 48;

        public const byte FormSetting = 50;

        // public const byte KScript = 52;

        public const byte SiteUser = 55;

        public const byte Code = 58;

        public const byte BusinessRule = 65;

        public const byte Product = 70;
        public const byte Cateogry = 71;
        public const byte ProductCategory = 72;
        public const byte ProductVariants = 73;
        public const byte ProductType = 74;
                                           

        public const byte kfile = 80; 

        private static Dictionary<string, byte> _Types;

        private static object _locker = new object();

        public static Dictionary<string, byte> Types
        {
            get
            {
                if (_Types == null)
                {
                    lock (_locker)
                    {
                        if (_Types == null)
                        {
                            _Types = new Dictionary<string, byte>(StringComparer.OrdinalIgnoreCase);

                            var allfields = typeof(ConstObjectType).GetFields(BindingFlags.Static | BindingFlags.Public);

                            var instance = Activator.CreateInstance(typeof(ConstObjectType));

                            foreach (var item in allfields)
                            {
                                var value = item.GetValue(instance);
                                var bytevalue = Convert.ToByte(value);
                                if (bytevalue != 0)
                                {
                                    _Types.Add(item.Name, bytevalue);
                                }
                            }
                        }

                    }
                }

                return _Types;
            }
        }

        public static byte GetByte(string constName)
        {
            if (string.IsNullOrEmpty(constName))
            {
                return 0;
            }

            if (Types.ContainsKey(constName))
            {
                return Types[constName];
            }
            return 0;
        }

        public static string GetName(byte constType)
        {
            foreach (var item in Types)
            {
                if (item.Value == constType)
                {
                    return item.Key;
                }
            }
            return null;
        }
    }
}
