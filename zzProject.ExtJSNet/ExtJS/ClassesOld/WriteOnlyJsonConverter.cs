using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld
{
    public abstract class WriteOnlyJsonConverter : JsonConverter
    {
        public sealed override bool CanRead { get { return false; } }

        public sealed override bool CanWrite { get { return true; } }

        public sealed override bool CanConvert(System.Type objectType)
        {
            return (objectType is Type);
        }

        public sealed override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        //public sealed override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    this.WriteJson(writer, (Type)value, serializer);
        //}
    }
}
