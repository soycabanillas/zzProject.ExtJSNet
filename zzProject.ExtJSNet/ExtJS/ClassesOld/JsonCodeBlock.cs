using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld
{
    [JsonConverter(typeof(JsonCodeBlock.Converter))]
    public class JsonCodeBlock
    {
        public class Converter : WriteOnlyJsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var myValue = (JsonCodeBlock)value;
                writer.WriteRawValue(myValue._codeToRender);
            }
        }

        private string _codeToRender;

        private JsonCodeBlock(string codeToRender)
        {
            this._codeToRender = codeToRender;
        }

        public static JsonCodeBlock Create(string code)
        {
            return new JsonCodeBlock(code);
        }

        public override string ToString()
        {
            return Utils.DataToJson(this);
        }
    }
}
