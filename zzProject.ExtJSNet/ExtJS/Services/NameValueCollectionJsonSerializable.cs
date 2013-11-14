using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.Services
{
    public class NameValueCollectionJsonSerializable : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsAssignableFrom(typeof(NameValueCollection)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            NameValueCollection oData = (NameValueCollection)value;
            writer.WriteStartArray();
            for (int i = 0; i < oData.Count; i++)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(oData.GetKey(i));
                writer.WriteValue(oData.Get(i));
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}