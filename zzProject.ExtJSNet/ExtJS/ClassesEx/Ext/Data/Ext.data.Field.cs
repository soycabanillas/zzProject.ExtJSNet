using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data {
    public partial class Field : Base { //: Component {
        //[JsonIgnore]
        //public string name { get { return this.attributes.GetOrDefault<string>("name"); } set { this.attributes["name"] = value; } }
        //[JsonIgnore]
        //public string type { get { return this.attributes.GetOrDefault<string>("type"); } set { this.attributes["type"] = value; } }
        //[JsonIgnore]
        //public string defaultValue { get { return this.attributes.GetOrDefault<string>("defaultValue"); } set { this.attributes["defaultValue"] = value; } }
        //[JsonIgnore]
        //public string convert { get { return this.attributes.GetOrDefault<string>("convert"); } set { this.attributes["convert"] = value; } }
        //[JsonIgnore]
        //public string persist { get { return this.attributes.GetOrDefault<string>("persist"); } set { this.attributes["persist"] = value; } }

        public Field(string name) {
            this.name = name;
        }
    }
}
