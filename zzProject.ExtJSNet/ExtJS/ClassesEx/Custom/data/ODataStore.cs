using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.Services;
using System.Linq.Expressions;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using Mvc = System.Web.Mvc;
using zzProject.Utils.Text;
using zzProject.MVCExtender.ExtJS.ModelMetadata;
using Newtonsoft.Json;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data.Proxy;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data
{
    public class ODataStore : Store
    {
        //[JsonIgnore]
        //public string url { get { return this.attributes.GetOrDefault<string>("url"); } set { this.attributes["url"] = value; } }
        [JsonIgnore]
        private string _url;

        public ODataStore(string modelName, string url) : base(modelName)
        {
            this._url = url;
        }

        public ODataStore(Model model, string url) : base(model)
        {
            this._url = url;
        }

        protected override void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
        {
            attributes.Add("proxy", new ODataProxy(this._url));
            base.Serialize(writer, value, serializer);
        }
    }
}
