using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thrifter.Utils
{
    public class HelperMethods
    {
        public static string[] getTagsFromName(string name){
            string[] tags = name.Split(' ');
            return tags;
        }
    }
}