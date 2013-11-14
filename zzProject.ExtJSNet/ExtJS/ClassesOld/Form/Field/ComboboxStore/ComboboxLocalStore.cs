using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.Utils.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;
using zzProject.MVCExtender.ExtJS.Services;
using zzProject.MVCExtender.ExtJS.Services.Clasess.CustomJsonConverters;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field.ComboboxStore
{
    public class ComboboxLocalStore : ComboboxStoreBase
    {
        private static string VALUE_FIELD = "id";
        private static string DISPLAY_FIELD = "text";
        private static string[] FIELDS = { VALUE_FIELD, DISPLAY_FIELD };

        private IDictionary<object, object> _values;

        public ComboboxLocalStore(IDictionary<object, object> values)
            : base(ComboboxLocalStore.VALUE_FIELD, ComboboxLocalStore.DISPLAY_FIELD)
        {
            this._values = values;
        }

        public override QueryMode GetQueryMode()
        {
            return QueryMode.local;
        }

        protected override void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
        {
            this.attributes["fields"] = ComboboxLocalStore.FIELDS;
            this.attributes["data"] = new IDictionary_object_object_Wrapper(this._values, VALUE_FIELD, DISPLAY_FIELD);
            //new IDictionary_object_object_JsonSerializable().WriteJson(writer, _values, serializer);
            base.Serialize(writer, value, serializer);
        }
    }
}
