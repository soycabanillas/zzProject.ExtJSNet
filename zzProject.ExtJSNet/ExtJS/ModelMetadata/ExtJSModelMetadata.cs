using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;
using zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field;
using zzProject.MVCExtender.ExtJS.ClassesOld.Grid.Column;
using Mvc = System.Web.Mvc;
using zzProject.MVCExtender.ExtJS.ClassesOld.Params;
using zzProject.MVCExtender.ExtJS.ClassesOld.Relations;

namespace zzProject.MVCExtender.ExtJS.ModelMetadata
{
    public class ExtJSModelMetadata
    {
        private Mvc.ModelMetadata _modelMetadata;

        public ExtJSModelMetadata(Mvc.ModelMetadata modelMetadata)
        {
            this._modelMetadata = modelMetadata;
        }

        public Mvc.ModelMetadata ModelMetadata { get { return this._modelMetadata; } }
        public IStore store { get; set; }
        public IColumn column { get; set; }
        public IEditor editor { get; set; }
        public ParamsCollection @params { get; set; }
        public ChildrenCollection childs { get; set; }
    }
}
