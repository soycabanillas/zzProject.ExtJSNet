using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data.Proxy
{
    
    public class ODataProxy : ServerProxy
    {
        public ODataProxy(string url)
        {
            attributes.Add("url", url);
            attributes.Add("type", "oData");
        }
    }
}
