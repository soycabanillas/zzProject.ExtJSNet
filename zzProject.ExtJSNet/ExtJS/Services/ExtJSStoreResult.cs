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
    public class ExtJSStoreResult<T>// where T : System.Collections.ICollection
    {
        public ExtJSStoreResult()
        {
        }

        public static ExtJSStoreResult<T> CreateResult(IQueryable<T> data)
        {
            ExtJSStoreResult<T> returnValue = new ExtJSStoreResult<T>();
            returnValue.success = true;
            returnValue.data = data;
            returnValue.errors = null;
            returnValue.total = data.Count();
            return returnValue;
        }

        public static ExtJSStoreResult<T> CreatePaginatedResult(IQueryable<T> data, int skip, int take)
        {
            ExtJSStoreResult<T> returnValue = new ExtJSStoreResult<T>();
            returnValue.success = true;
            returnValue.data = data.Skip(skip).Take(take);
            returnValue.errors = null;
            returnValue.total = data.Count();
            return returnValue;
        }

        public static ExtJSStoreResult<T> CreateFilteredAndPaginatedResult(IQueryable<T> data, string oDataQuery)
        {
            ExtJsUtils.QueryUtils.PaginableQueryResult<T> paginable = ExtJsUtils.QueryUtils.GetFilteredAndPaginableResult<T>(data, HttpContext.Current.Request.Url);

            ExtJSStoreResult<T> returnValue = new ExtJSStoreResult<T>();
            returnValue.success = true;
            returnValue.data = paginable.QueryByPage;
            returnValue.errors = null;
            returnValue.total = paginable.Query.Count();
            return returnValue;
        }

        public static ExtJSStoreResult<T> CreateErrorResult(NameValueCollection errors)
        {
            ExtJSStoreResult<T> returnValue = new ExtJSStoreResult<T>();
            returnValue.success = false;
            returnValue.errors = errors;
            returnValue.total = 0;
            return returnValue;
        }

        public bool success { get; set; }
        public IQueryable<T> data { get; set; }
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