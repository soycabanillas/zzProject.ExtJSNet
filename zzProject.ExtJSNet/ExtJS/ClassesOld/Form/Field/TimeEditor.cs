using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.Utils.Text;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field
{
    public class TimeEditor : EditorBase
    {
        [JsonIgnore]
        public int minValue { get { return this.attributes.GetOrDefault<int>("minValue"); } set { this.attributes["minValue"] = value; } }
        [JsonIgnore]
        public int maxValue { get { return this.attributes.GetOrDefault<int>("maxValue"); } set { this.attributes["maxValue"] = value; } }
        [JsonIgnore]
        public int increment { get { return this.attributes.GetOrDefault<int>("increment"); } set { this.attributes["increment"] = value; } }

        public TimeEditor()
        {
            this.attributes["xtype"] = "timefield";
        }
    }
}
