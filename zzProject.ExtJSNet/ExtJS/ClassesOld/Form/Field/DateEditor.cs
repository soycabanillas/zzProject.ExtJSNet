using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using zzProject.Utils.Text;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field
{
    public class DateEditor : IEditor
    {
        public string value { get; set; }
        public string minValue { get; set; }
        public string maxValue { get; set; }
        public string format { get; set; }

        public String Render()
        {
            StringBuilder result = new StringBuilder();

            result.Append(@"editor: {  xtype: 'datefield'");

            bool isFirstElement = false;
            if (this.value != null)
                result.AppendFormatComma(ref isFirstElement, "value: '{0}'", this.value);
            if (this.minValue != null)
                result.AppendFormatComma(ref isFirstElement, "minValue: '{0}'", this.minValue);
            if (this.maxValue != null)
                result.AppendFormatComma(ref isFirstElement, "maxValue: '{0}'", this.maxValue);
            if (this.format != null)
                result.AppendFormatComma(ref isFirstElement, "format: '{0}'", this.format);

            
            result.AppendLine("}");
            
            return result.ToString();
        }
    }
}
