using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using zzProject.Utils.Text;
using zzProject.MVCExtender.ExtJS.ClassesOld.Grid.Column;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Tree
{
    public class Panel : Component
    {
        public string title { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool rootVisible { get; set; }
        public string storeName { get; set; }
        public ITreeStore store { get; set; }
        public IEnumerable<IColumn> columns { get; set; }
   
        public void CreateTreePanel(string treeStore)
        {
            this.storeName = treeStore;
        }

        public void CreateTreePanel(ITreeStore treeStore)
        {
            this.store = treeStore;
        }

        //public string Render()
        //{
        //    attributes.AddIfNotNull("title", "Prueba");
        //    attributes.AddIfNotNull("width", width);
        //    attributes.AddIfNotNull("height", height);
        //    attributes.AddIfNotNull("columns", columns);
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append("Ext.create('Ext.tree.Panel', {");
        //    stringBuilder.Append(attributes.ToJS());
        //    stringBuilder.Append("});");
        //    return stringBuilder.ToString();
        //}
    }
}
