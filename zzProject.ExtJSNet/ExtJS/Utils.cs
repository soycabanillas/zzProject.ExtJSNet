using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using zzProject.Utils.Text;
using System.Text.RegularExpressions;
using zzProject.Utils.Date;

namespace zzProject.MVCExtender.ExtJS
{
    public static class Utils
    {
        internal static string DataToJson(object data)
        {
            StringBuilder result = new StringBuilder();
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new IsoDateTimeConverter());
            using (var sw = new System.IO.StringWriter(result))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
            return result.ToString();
        }
    }
}
