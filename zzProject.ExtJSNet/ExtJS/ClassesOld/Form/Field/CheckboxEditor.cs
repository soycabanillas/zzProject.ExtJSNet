using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.Utils.Text;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field
{
    public class CheckboxEditor : EditorBase
    {
        //public bool? checked { get; set; }

        public CheckboxEditor()
        {
            this.attributes["xtype"] = "checkboxfield";

            //bool isFirstElement = false;
            //if (this.defaultValue.HasValue)
            //    result.AppendFormatComma(ref isFirstElement, "value: {0}", this.defaultValue.Value);
            //if (this.minValue.HasValue)
            //    result.AppendFormatComma(ref isFirstElement, "minValue: {0}", this.minValue.Value);
            //if (this.maxValue.HasValue)
            //    result.AppendFormatComma(ref isFirstElement, "maxValue: {0}", this.maxValue.Value);
        }
    }
}
