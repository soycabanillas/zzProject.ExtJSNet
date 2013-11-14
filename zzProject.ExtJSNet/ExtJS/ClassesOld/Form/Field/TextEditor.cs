using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.Utils.Text;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field
{
    public class TextEditor : EditorBase
    {
        [JsonIgnore]
        public bool allowBlank { get { return this.attributes.GetOrDefault<bool>("allowBlank"); } set { this.attributes["allowBlank"] = value; } }
        [JsonIgnore]
        public int minLength { get { return this.attributes.GetOrDefault<int>("minLength"); } set { this.attributes["minLength"] = value; } }
        [JsonIgnore]
        public int maxLength { get { return this.attributes.GetOrDefault<int>("maxLength"); } set { this.attributes["maxLength"] = value; } }
        [JsonIgnore]
        public string regEx { get { return this.attributes.GetOrDefault<string>("regEx"); } set { this.attributes["regEx"] = value; } }

        public TextEditor()
        {
            this.attributes["xtype"] = "textfield";
        }
    }
}
