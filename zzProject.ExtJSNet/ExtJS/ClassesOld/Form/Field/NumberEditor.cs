using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.Utils.Text;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field
{
    public class NumberEditor : EditorBase
    {
        [JsonIgnore]
        public int defaultValue { get { return this.attributes.GetOrDefault<int>("defaultValue"); } set { this.attributes["defaultValue"] = value; } }
        [JsonIgnore]
        public int minValue { get { return this.attributes.GetOrDefault<int>("minValue"); } set { this.attributes["minValue"] = value; } }
        [JsonIgnore]
        public int maxValue { get { return this.attributes.GetOrDefault<int>("maxValue"); } set { this.attributes["maxValue"] = value; } }

        public NumberEditor()
        {
            this.attributes["xtype"] = "numberfield";
        }
    }
}
