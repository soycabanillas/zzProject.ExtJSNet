using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using Newtonsoft.Json;
using zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field;
using Mvc = System.Web.Mvc;
using zzProject.MVCExtender.ExtJS.ModelMetadata;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Grid.Column
{
    public class Column : Component, IColumn
    {
        #region Properties

        [JsonIgnore]
        public string text { get { return this.attributes.GetOrDefault<string>("text"); } set { this.attributes["text"] = value; } }
        [JsonIgnore]
        public int width { get { return this.attributes.GetOrDefault<int>("width"); } set { this.attributes["width"] = value; } }
        [JsonIgnore]
        public bool sortable { get { return this.attributes.GetOrDefault<bool>("sortable", false); } set { this.attributes["sortable"] = value; } }
        [JsonIgnore]
        public bool hideable { get { return this.attributes.GetOrDefault<bool>("hideable", false); } set { this.attributes["hideable"] = value; } }
        [JsonIgnore]
        public int flex { get { return this.attributes.GetOrDefault<int>("flex"); } set { this.attributes["flex"] = value; } }
        [JsonIgnore]
        public string dataIndex { get { return this.attributes.GetOrDefault<string>("dataIndex"); } set { this.attributes["dataIndex"] = value; } }
        //[JsonIgnore]
        //public IEditor editor { get { return this.attributes.GetOrDefault<IEditor>("editor"); } set { this.attributes["editor"] = value; } }

        //public string xtype { get; set; }

        #endregion

        #region Constructors
        public Column()
        {
        }

        public Column(object modelMetadata)
        {
            Mvc.ModelMetadata MvcModelMetadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
            this.attributes["text"] = MvcModelMetadata.DisplayName ?? MvcModelMetadata.PropertyName;
            this.attributes["dataIndex"] = MvcModelMetadata.PropertyName;
        }
        //public Column(IEditor editor)
        //{
        //    this.attributes["editor"] = editor;
        //}

        //public Column(object modelMetadata)
        //{
        //    ExtJSModelMetadata extJSModelMetadata;
        //    if (ModelExtractor.TryFromObjectToExtJSModelMetadata(modelMetadata, out extJSModelMetadata))
        //    {
        //        //this.attributes["editor"] = metadata.editor;
        //    }
        //    else
        //    {
        //        Mvc.ModelMetadata MvcModelMetadata = ModelExtractor.FromObjectToModelMetadata(modelMetadata);
        //        this.attributes["dataIndex"] = MvcModelMetadata.PropertyName;
        //    }
        //}

        //public Column(Mvc.ModelMetadata metadata)
        //{
        //    this.attributes["editor"] = ModelExtractor.FromObjectToExtJSModelMetadata(metadata).editor;
        //}

        public static IColumn GetFromModel(object modelMetadata)
        {
            IColumn result;
            ExtJSModelMetadata extJSModelMetadata;
            if (ModelExtractor.TryFromObjectToExtJSModelMetadata(modelMetadata, out extJSModelMetadata) && extJSModelMetadata.column != null)
            {
                result = extJSModelMetadata.column;
            }
            else
            {
                result = new Column(modelMetadata);
            }
            return result;
        }
        #endregion

        #region Methods
        #endregion
    }
}
