using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using Newtonsoft.Json;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field.ComboboxStore
{
    public abstract class ComboboxStoreBase : StoreBase, IComboboxStore
    {
        [JsonIgnore]
        public string valueField { get { return this.attributes.GetOrDefault<string>("valueField"); } set { this.attributes["valueField"] = value; } }
        [JsonIgnore]
        public string displayField { get { return this.attributes.GetOrDefault<string>("displayField"); } set { this.attributes["displayField"] = value; } }

        public ComboboxStoreBase(string valueField, string displayField)
            : base()
        {
            this.valueField = valueField;
            this.displayField = displayField;
        }

        public ComboboxStoreBase(string modelName, string valueField, string displayField)
            : base(modelName)
        {
            this.valueField = valueField;
            this.displayField = displayField;
        }

        public ComboboxStoreBase(Model model)
            : base(model)
        {
            this.valueField = ModelUtils.GetKey(model.ExtJSModelMetadata);
            this.displayField = ModelUtils.GetNonKeyField(model.ExtJSModelMetadata);
        }

        public ComboboxStoreBase(Model model, string displayField)
            : base(model)
        {
            this.valueField = ModelUtils.GetKey(model.ExtJSModelMetadata);
            this.displayField = displayField;
        }

        public ComboboxStoreBase(Model model, string valueField, string displayField)
            : base(model)
        {
            this.valueField = valueField;
            this.displayField = displayField;
        }

        public string GetValueField()
        {
            return this.valueField;
        }

        public string GetDisplayField()
        {
            return this.displayField;
        }

        public abstract QueryMode GetQueryMode();
    }
}
