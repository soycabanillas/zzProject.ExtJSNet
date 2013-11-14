using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data.Proxy
{
    public class ServerProxy : ProxyBase
    {
        [JsonIgnore]
        public KeyedCollection<string, object> extraParams { get { return this.attributes.GetOrDefault<KeyedCollection<string, object>>("extraParams"); } set { this.attributes["extraParams"] = value; } }        
    }
}
