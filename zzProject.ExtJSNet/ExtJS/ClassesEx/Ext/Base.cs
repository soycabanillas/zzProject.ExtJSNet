using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zzProject.MVCExtender.ExtJS.ClassesOld;
using zzProject.MVCExtender.ExtJS.HtmlHelper;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext {
    public partial class Base {
        public Attributes attributes = new Attributes();

        public class Converter : WriteOnlyJsonConverter {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
                var myValue = (Component)value;
                //myValue.OnBeforeSerialize();
                myValue.Serialize(writer, value, serializer);
                //myValue.OnAfterSerialize();
            }

        }

        //protected virtual void SeriealizeCustomAttributes(JsonWriter writer, JsonSerializer serializer)
        //{

        //}

        protected virtual void Serialize(JsonWriter writer, object value, JsonSerializer serializer) {
            var myValue = (Component)value;
            Attributes attributes = myValue.attributes;

            //writer.WriteRaw("{");
            //bool isFirstElement = true;
            //foreach (var attribute in attributes)
            //{
            //    if (!isFirstElement) { writer.WriteRaw(","); }
            //    else { isFirstElement = false; }
            //    serializer.Serialize(writer, attribute.Key);
            //    writer.WriteRaw(":");
            //    serializer.Serialize(writer, attribute.Value);
            //}
            //this.SeriealizeCustomAttributes(writer, serializer);
            //writer.WriteRaw("}");

            serializer.Serialize(writer, attributes);
        }

    }
}
