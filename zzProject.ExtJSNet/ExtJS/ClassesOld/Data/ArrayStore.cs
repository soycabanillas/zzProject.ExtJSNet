using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using zzProject.MVCExtender.ExtJS.ModelMetadata;
using zzProject.MVCExtender.ExtJS.Services;
using zzProject.Utils.Text;
using Mvc = System.Web.Mvc;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data
{
    public class ArrayStore : StoreBase
    {
        private IEnumerable _data;

        //public ArrayStore(string modelName, IEnumerable data) : base(modelName)
        //{
        //    this._data = data;
        //}

        //public ArrayStore(Model model, IEnumerable data) : base(model)
        //{
        //    this._data = data;
        //}
        protected override void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
        {
            attributes.Add("data", this._data);
            base.Serialize(writer, value, serializer);
        }
    }
}
