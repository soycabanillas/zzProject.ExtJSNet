using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.Services.Clasess.CustomJsonConverters
{
    [JsonConverter(typeof(IDictionary_object_object_JsonSerializable))]
    public class IDictionary_object_object_Wrapper
    {
        private IDictionary<object, object> _dictionary;
        private string _valueField;
        private string _displayField;
        public IDictionary<object, object> dictionary { get { return this._dictionary; } }
        public string valueField { get { return this._valueField; } }
        public string displayField { get { return this._displayField; } }

        public IDictionary_object_object_Wrapper(IDictionary<object, object> dictionary, string valueField, string displayField)
        {
            this._dictionary = dictionary;
            this._valueField = valueField;
            this._displayField = displayField;
        }
    }

    public class IDictionary_object_object_JsonSerializable : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsAssignableFrom(typeof(IDictionary_object_object_Wrapper)))
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
            IDictionary_object_object_Wrapper wrapper = (IDictionary_object_object_Wrapper)value;
            IDictionary<object, object> oData = wrapper.dictionary;
            writer.WriteStartArray();
            foreach (var item in oData)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(wrapper.valueField);
                writer.WriteValue(item.Key);
                
                writer.WritePropertyName(wrapper.displayField);
                writer.WriteValue(item.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}