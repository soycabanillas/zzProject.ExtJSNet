using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvc = System.Web.Mvc;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Grid.Column
{
    public class Columns : System.Collections.Generic.List<IColumn>
    {
        public Columns(IEnumerable<Column> properties) : base(properties)
        {
        }

        public Columns(IEnumerable<Mvc.ModelMetadata> properties)
        {
            foreach (Mvc.ModelMetadata property in properties)
            {
                this.Add(Column.GetFromModel(property));
            }
        }
    }
}
