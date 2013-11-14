using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.ModelMetadata;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using Mvc = System.Web.Mvc;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using zzProject.MVCExtender.Metadata.CommonExtension;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data.Proxy;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data
{
    public class ModelUtils
    {
        //public static IEnumerable<string> GetKeys(object modelMetadata)
        //{
        //    List<string> keys = new List<string>();
        //    Mvc.ModelMetadata metadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
        //    foreach (Mvc.ModelMetadata item in metadata.Properties)
        //    {
        //        CommonExtensionModelMetadata common = ModelExtractor.FromObjectToCommonExtensionsModelMetadata(item);
        //        if (common.IsKey)
        //        {
        //            keys.Add(common.ModelMetadata.PropertyName);
        //        }
        //    }
        //    return keys;
        //}

        public static string GetKey(object modelMetadata)
        {
            string result = null;
            Mvc.ModelMetadata metadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
            foreach (Mvc.ModelMetadata item in metadata.Properties)
            {
                CommonExtensionModelMetadata common = ModelExtractor.FromObjectToCommonExtensionsModelMetadata(item);
                if (common.IsKey)
                {
                    if (result != null) throw new NotSupportedException("More than one key field has been found in the model metadata.");
                    else result = item.PropertyName;
                }
            }
            return result;
        }

        public static string GetKeyOrDefault(object modelMetadata, string defaultKey = "id")
        {
            string result = null;
            Mvc.ModelMetadata metadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
            foreach (Mvc.ModelMetadata item in metadata.Properties)
            {
                CommonExtensionModelMetadata common = ModelExtractor.FromObjectToCommonExtensionsModelMetadata(item);
                if (common.IsKey)
                {
                    if (result != null) throw new NotSupportedException("More than one key field has been found in the model metadata.");
                    else result = item.PropertyName;
                }
            }
            return result ?? defaultKey;
        }

        public static IEnumerable<string> GetNonKeyFields(object modelMetadata)
        {
            List<string> keys = new List<string>();
            Mvc.ModelMetadata metadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
            foreach (Mvc.ModelMetadata item in metadata.Properties)
            {
                CommonExtensionModelMetadata common = ModelExtractor.FromObjectToCommonExtensionsModelMetadata(item);
                if (!common.IsKey)
                {
                    keys.Add(common.ModelMetadata.PropertyName);
                }
            }
            return keys;
        }

        public static string GetNonKeyField(object modelMetadata)
        {
            string result = null;
            Mvc.ModelMetadata metadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
            foreach (Mvc.ModelMetadata item in metadata.Properties)
            {
                CommonExtensionModelMetadata common = ModelExtractor.FromObjectToCommonExtensionsModelMetadata(item);
                if (!common.IsKey)
                {
                    if (result != null) throw new NotSupportedException("More than one no key field has been found in the model metadata.");
                    else result = item.PropertyName;
                }
            }
            return result;
        }

        public static IEnumerable<Field> GetFields(object modelMetadata)
        {
            List<Field> keys = new List<Field>();
            Mvc.ModelMetadata metadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
            foreach (Mvc.ModelMetadata item in metadata.Properties)
            {
                CommonExtensionModelMetadata common = ModelExtractor.FromObjectToCommonExtensionsModelMetadata(item);
                keys.Add(new Field(common.ModelMetadata.PropertyName));
            }
            return keys;
        }
    }

    public partial class Model : Base //Component
    {
        //#region Properties
        //[JsonIgnore]
        //public string idProperty { get { return this.attributes.GetOrDefault<string>("idProperty"); } set { this.attributes["idProperty"] = value; } }
        //[JsonIgnore]
        //public IEnumerable<Field> fields { get { return this.attributes.GetOrDefault<IEnumerable<Field>>("fields"); } set { this.attributes["fields"] = value; } }
        //[JsonIgnore]
        //private IProxy proxy { get { return this.attributes.GetOrDefault<IProxy>("proxy"); } set { this.attributes["proxy"] = value; } }
        //#endregion

        private ExtJSModelMetadata _extJSModelMetadata;
        public ExtJSModelMetadata ExtJSModelMetadata { get { return this._extJSModelMetadata; } }

        protected Model()
        {
        }

        public Model(object modelMetadata) : this(modelMetadata, null)
        {
        }

        public Model(object modelMetadata, IProxy proxy)
        {
            ExtJSModelMetadata extJSModelMetadata;
            if (ModelExtractor.TryFromObjectToExtJSModelMetadata(modelMetadata, out extJSModelMetadata) && extJSModelMetadata.column != null)
            {
                this._extJSModelMetadata = extJSModelMetadata;
            }
            else
            {
                this._extJSModelMetadata = new ExtJSModelMetadata(ModelExtractor.FromObjectToModelMetadata(modelMetadata));
            }
            this.idProperty = ModelUtils.GetKeyOrDefault(this);
            this.fields = ModelUtils.GetFields(this);
            if (proxy != null) this.proxy = proxy;
        }

        public virtual string ModelCreateClassName { get { return "Ext.data.Model"; } }

        public string RenderCreate()
        {
            return string.Format("Ext.create('Ext.data.Model', {{{0}}})", zzProject.MVCExtender.ExtJS.Utils.DataToJson(this));
        }

        public string RenderDefine(string modelName)
        {
            attributes.Add("extend", this.ModelCreateClassName);
            return string.Format("Ext.define('{0}', {1})", modelName, zzProject.MVCExtender.ExtJS.Utils.DataToJson(this));
        }

        protected override void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.Serialize(writer, value, serializer);
        }
    }

    public class Model<TElement> : Model
    {
        [JsonIgnore]
        private TElement _element;

        protected Model(TElement element)
            : base(element)
        {
            this._element = element;
        }
    }
}
