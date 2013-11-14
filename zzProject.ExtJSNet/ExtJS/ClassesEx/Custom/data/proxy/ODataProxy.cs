using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using Newtonsoft.Json;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data.proxy
{
    
    public class ODataProxy : zzProject.ExtJSNet.ExtJS.Classes.Ext.data.proxy.Server
    {
        public ODataProxy(string url)
        {
            attributes.Add("url", url);
            attributes.Add("type", "oData");
        }
    }
}
