using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.Utils.Text;
using System.ComponentModel;
using zzProject.MVCExtender.ExtJS.ClassesOld;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.HtmlHelper
{
    public class Attributes : System.Collections.Generic.Dictionary<string, object>
    {
        [Flags]
        public enum MergeOptions
        {
            None = 0,
            Replace = 1,
            IfNotNull = 2
        }

        public Attributes() : base()
        {
        }

        public Attributes(object htmlAttributes) : base()
        {
            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    this.Add(property.Name, property.GetValue(htmlAttributes));
                }
            }
        }

        public Attributes(Dictionary<string, object> htmlAttributes) : base(htmlAttributes)
        {
        }

        public void AddIfNotNull(string key, object value)
        {
            if (value != null) this.Add(key, value);
        }

        public void AddOrReplace(string key, object value)
        {
            if (this.ContainsKey(key)) this[key] = value;
            else this.Add(key, value);
        }

        public void AddOrReplaceIfNotNull(string key, object value)
        {
            if (value != null)
            {
                if (this.ContainsKey(key)) this[key] = value;
                else this.Add(key, value);
            }
        }

        public void AddIfNotExist(string key, object value)
        {
            if (this.ContainsKey(key)) this[key] = value;
            else this.Add(key, value);
        }

        public void AddIfNotExistIfNotNull(string key, object value)
        {
            if (value != null)
            {
                if (this.ContainsKey(key)) this[key] = value;
                else this.Add(key, value);
            }
        }

        public Attributes Merge(Attributes merge, MergeOptions options)
        {
            foreach (var attribute in this)
            {
                if (!options.HasFlag(MergeOptions.IfNotNull) || attribute.Value != null)
                {
                    if (options.HasFlag(MergeOptions.Replace))
                    {
                        this.AddOrReplace(attribute.Key, attribute.Value);
                    }
                    else
                    {
                        this.Add(attribute.Key, attribute.Value);
                    }
                }
            }
            return this;
        }

        public Type GetOrDefault<Type>(string key)
        {
            object result;
            if (this.TryGetValue(key, out result)) return (Type)result;
            else return default(Type);
        }

        public Type GetOrDefault<Type>(string key, Type defaultValue)
        {
            object result;
            if (this.TryGetValue(key, out result)) return (Type)result;
            else return defaultValue;
        }

        public Type GetOrDefault<Type>(string key, Func<Type> defaultValue) {
            object result;
            if (this.TryGetValue(key, out result)) return (Type)result;
            else return defaultValue();
        }

        public Type GetOrNew<Type>(string key) where Type : new()
        {
            object result;
            if (this.TryGetValue(key, out result)) return (Type)result;
            else
            {
                var newObject = new Type();
                this[key] = newObject;
                return newObject;
            }
        }
        //public string ToJS()
        //{
        //    StringBuilder result = new StringBuilder();
        //    bool isFirstElement = true;
        //    if (this.Count > 1)
        //    {
        //        result.Append("{");
        //    }
        //    foreach (var item in this)
        //    {
        //        string valueSerialization;
        //        if (item.Value is IAttributeSerializable)
        //        {
        //            valueSerialization = ((IAttributeSerializable)item.Value).AttributeRender();
        //        }
        //        else
        //        {
        //            valueSerialization = Utils.DataToJson(item.Value);
        //        }
        //        result.AppendFormatComma(ref isFirstElement, item.Key).Append(": ").Append(valueSerialization);
        //    }
        //    if (this.Count > 1)
        //    {
        //        result.Append("}");
        //    }
        //    return result.ToString();
        //}

        //public string ToJS(string source)
        //{
        //    string attributesString = this.ToJS();
        //    if (attributesString != null && attributesString != string.Empty)
        //    {
        //        if (source == null || source == string.Empty) return attributesString;
        //        else return source + ", " + attributesString;
        //    }
        //    else return source;
        //}
    }
}
