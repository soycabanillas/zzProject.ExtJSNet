using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace zzProject.MVCExtender.ExtJS.Services
{
    public class ExtJSCallbackResult<T>// where T : System.Collections.ICollection
    {
        public ExtJSCallbackResult()
        {
        }

        //public ExtJSResult(bool success, T data)
        //{
        //    this.success = success;
        //    this.data = data;
        //}

        //public ExtJSResult(bool success, T data, int total)
        //{
        //    this.success = success;
        //    this.data = data;
        //    this.total = total;
        //}

        public static ExtJSCallbackResult<T> CreateUniqueInstancePostResult(T data)
        {
            ExtJSCallbackResult<T> returnValue = new ExtJSCallbackResult<T>();
            returnValue.success = true;
            returnValue.data = data;
            returnValue.errors = null;
            returnValue.total = 0;
            return returnValue;
        }

        public static ExtJSCallbackResult<T> CreateNonPaginableResult(T data)
        {
            ExtJSCallbackResult<T> returnValue = new ExtJSCallbackResult<T>();
            returnValue.success = true;
            returnValue.data = data;
            returnValue.errors = null;
            returnValue.total = 0;
            return returnValue;
        }

        public static ExtJSCallbackResult<T> CreatePaginableResult(T data, int total)
        {
            ExtJSCallbackResult<T> returnValue = new ExtJSCallbackResult<T>();
            returnValue.success = true;
            returnValue.data = data;
            returnValue.errors = null;
            returnValue.total = total;
            return returnValue;
        }

        public static ExtJSCallbackResult<T> CreateErrorResult(NameValueCollection errors)
        {
            ExtJSCallbackResult<T> returnValue = new ExtJSCallbackResult<T>();
            returnValue.success = false;
            returnValue.errors = errors;
            returnValue.total = 0;
            return returnValue;
        }

        public bool success { get; set; }
        public T data { get; set; }
        public int total { get; set; }

        //[XmlInclude(typeof(NameValueCollectionXmlSerializable)]
        [XmlIgnore]
        [JsonConverterAttribute(typeof(NameValueCollectionJsonSerializable))]
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