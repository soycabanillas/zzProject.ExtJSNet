using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.Utils.Text;
using zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field.ComboboxStore;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field
{
    public class ComboboxEditor : EditorBase
    {
        private IComboboxStore _store;

        public ComboboxEditor(IComboboxStore store)
        {
            this._store = store;
            
            this.attributes["xtype"] = "combobox";
            this.attributes["queryMode"] = this._store.GetQueryMode().ToString();
            this.attributes["valueField"] = this._store.GetValueField();
            this.attributes["displayField"] = this._store.GetDisplayField();
        }

        protected override void Serialize(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            this.attributes["store"] = this._store;
            base.Serialize(writer, value, serializer);
        }
    }
}
