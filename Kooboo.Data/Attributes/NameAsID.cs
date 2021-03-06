//Copyright (c) 2018 Yardi Technology Limited. Http://www.kooboo.com 
//All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kooboo.Attributes
{
    /// <summary>
    /// The id of this site object is generated by the siteobject name. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NameAsID : Attribute
    { 
    }
}
