using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using zzProject.MVCExtender.ExtJS.ModelMetadata;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using zzProject.Utils.Text;
using Newtonsoft.Json;
using zzProject.MVCExtender;
using zzProject.MVCExtender.ExtJS.ClassesOld;
using zzProject.MVCExtender.ExtJS;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data
{
    public abstract partial class Store : AbstractStore, IStore
    {
        private Model _dmodel;
        protected Model model
        {
            get { return this._dmodel; }
            set { this._dmodel = value; }
        }

        //[JsonIgnore]
        //public int pageSize { get { return this.attributes.GetOrDefault<int>("pageSize", 25); } set { this.attributes["pageSize"] = value; } }
        //[JsonIgnore]
        //public bool autoLoad { get { return this.attributes.GetOrDefault<bool>("autoLoad", false); } set { this.attributes["autoLoad"] = value; } }
        //[JsonIgnore]
        //public bool remoteSort { get { return this.attributes.GetOrDefault<bool>("remoteSort", false); } set { this.attributes["remoteSort"] = value; } }
        //[JsonIgnore]
        //public bool remoteFilter { get { return this.attributes.GetOrDefault<bool>("remoteFilter", false); } set { this.attributes["remoteFilter"] = value; } }

        protected Store()
        {
        }

        public Store(string modelName)
        {
            this.attributes.Add("model", modelName);
        }

        public Store(Model model)
        {
            this.attributes.Add("model", Common.UnikeID());
            this.model = model;
        }

        public virtual string StoreCreateClassName { get { return "Ext.data.Store"; } }

        public JsonCodeBlock RenderCreate()
        {
            if (this.model != null)
            {
                return JsonCodeBlock.Create(string.Format(@"MVCExtJS_Ext_Create('{0}',
                                                                                {1},
                                                                                function(){{{2};}})", this.StoreCreateClassName, zzProject.MVCExtender.ExtJS.Utils.DataToJson(this), this.model.RenderDefine((string)this.attributes["model"])));
            }
            else
            {
                return JsonCodeBlock.Create(string.Format(@"Ext.create('{0}',
                                                                       {1})", this.StoreCreateClassName, zzProject.MVCExtender.ExtJS.Utils.DataToJson(this)));
            }
        }

        public JsonCodeBlock RenderDefine(string storeName)
        {
            attributes.Add("extend", this.StoreCreateClassName);
            if (this.model != null)
            {
                return JsonCodeBlock.Create(string.Format(@"{0}; 
                                                            Ext.define('{1}', 
                                                                       {2})",
                                                            this.model.RenderDefine((string)this.attributes["model"]),
                                                            storeName,
                                                            zzProject.MVCExtender.ExtJS.Utils.DataToJson(this)));
            }
            else
            {
                return JsonCodeBlock.Create(string.Format(@"Ext.define('{0}', 
                                                                       {1})",
                                                            storeName,
                                                            zzProject.MVCExtender.ExtJS.Utils.DataToJson(this)));
            }
        }
    }
}
