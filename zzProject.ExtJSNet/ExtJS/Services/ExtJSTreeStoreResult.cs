using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Specialized;
using ExtJsUtils = zzProject.MVCExtender.ExtJS.Services.Utils;

namespace zzProject.MVCExtender.ExtJS.Services
{
    public class ExtJSTreeStoreResult<T>// where T : System.Collections.ICollection
    {
        public ExtJSTreeStoreResult()
        {
        }

        public static ExtJSTreeStoreResult<T> CreateResult(IQueryable<T> data)
        {
            ExtJSTreeStoreResult<T> returnValue = new ExtJSTreeStoreResult<T>();
            returnValue.success = true;
            returnValue.children = data;
            returnValue.errors = null;
            returnValue.total = data.Count();
            return returnValue;
        }

        public static ExtJSTreeStoreResult<T> CreateErrorResult(NameValueCollection errors)
        {
            ExtJSTreeStoreResult<T> returnValue = new ExtJSTreeStoreResult<T>();
            returnValue.success = false;
            returnValue.errors = errors;
            returnValue.total = 0;
            return returnValue;
        }

        public bool success { get; set; }
        public IQueryable<T> children { get; set; }
        public int total { get; set; }

        //[XmlInclude(typeof(NameValueCollectionXmlSerializable)]
        [XmlIgnore]
        [JsonConverter(typeof(NameValueCollectionJsonSerializable))]
        [JsonProperty(PropertyName = "errors", NullValueHandling = NullValueHandling.Ignore)]
        public NameValueCollection errors { get; set; }
        [XmlElement("errors")]
        [JsonIgnore]
        public NameValueCollectionXmlSerializable XMLSerializationerrors
        {
            get
            {
                if (this.errors == null)
                {
                    return null;
                }
                else
                {
                    return new NameValueCollectionXmlSerializable(this.errors);
                }
            }
            set
            {
                ;
            }
        }
    }
}