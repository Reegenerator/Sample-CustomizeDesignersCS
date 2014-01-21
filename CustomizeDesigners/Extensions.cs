using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Kodeo.Reegenerator.Language;

namespace CustomizeDesigners
{
    static class Extensions
    {
      
        static public string Attr(this XElement ele, string attrName)
        {
            return ele.Attribute(attrName).Value;
        }

    }
}
