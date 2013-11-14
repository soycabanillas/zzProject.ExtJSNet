using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Linq.Expressions;

using zzProject.MVCExtender.Metadata.CommonExtension;
using Mvc = System.Web.Mvc;
using zzProject.MVCExtender.ExtJS;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;
using System.Runtime.InteropServices;
using zzProject.MVCExtender.ExtJS.ClassesOld.Grid.Column;

namespace zzProject.MVCExtender.ExtJS.HtmlHelper
{
    public static class ExtJSHtmlHelper
    {
        public static MvcHtmlString ExtJS_ModelKey(this Mvc.HtmlHelper helper)
        {
            Mvc.ModelMetadata modelMetadata = helper.ViewData.ModelMetadata;
            return ExtJS_ModelKey(helper, modelMetadata);
        }
        public static MvcHtmlString ExtJS_ModelKey(this Mvc.HtmlHelper helper, object source)
        {
            return new MvcHtmlString(Utils.DataToJson(ModelUtils.GetKey(source)));
        }

        public static MvcHtmlString ExtJS_ModelFields(this Mvc.HtmlHelper helper)
        {
            Mvc.ModelMetadata modelMetadata = helper.ViewData.ModelMetadata;
            return ExtJS_ModelFields(helper, modelMetadata);
        }
        public static MvcHtmlString ExtJS_ModelFields(this Mvc.HtmlHelper helper, object source)
        {
            return new MvcHtmlString(Utils.DataToJson(ModelUtils.GetFields(source)));
        }

        public static MvcHtmlString ExtJS_Colum<TModel>(this Mvc.HtmlHelper helper, Expression<Func<TModel, object>> expression)
        {
            Mvc.ModelMetadata modelMetadata = ModelExtractor.FromLambdaExpression_Property<TModel, object>(expression);
            return ExtJS_Column(helper, modelMetadata);
        }
        public static MvcHtmlString ExtJS_Column(this Mvc.HtmlHelper helper, object source)
        {
            return new MvcHtmlString(Utils.DataToJson(Column.GetFromModel(source)));
        }
        public static MvcHtmlString ExtJS_Column(this Mvc.HtmlHelper helper, IColumn column)
        {
            return new MvcHtmlString(Utils.DataToJson(column));
        }
        //public static MvcHtmlString ExtJS_ColumnBody(this Mvc.HtmlHelper helper, object source, object jsonAttributes)
        //{
        //    Mvc.ModelMetadata modelMetadata = ModelExtractor.FromObjectToModelMetadata(source);
        //    string stringResult = ExtJSGenerator.ColumBody(modelMetadata);
        //    stringResult = Utils.AddJsonPropertiesToString(stringResult, jsonAttributes);
        //    MvcHtmlString result = new MvcHtmlString(stringResult);
        //    return result;
        //}
        //public static MvcHtmlString ExtJS_ColumnBody(this Mvc.HtmlHelper helper, object source, IDictionary<string, object> jsonAttributes)
        //{
        //    Mvc.ModelMetadata modelMetadata = ModelExtractor.FromObjectToModelMetadata(source);
        //    string stringResult = ExtJSGenerator.ColumBody(modelMetadata);
        //    stringResult = Utils.AddJsonPropertiesToString(stringResult, jsonAttributes);
        //    MvcHtmlString result = new MvcHtmlString(stringResult);
        //    return result;
        //}

        public static MvcHtmlString ExtJS_Columns(this Mvc.HtmlHelper helper)
        {
            Mvc.ModelMetadata modelMetadata = helper.ViewData.ModelMetadata;
            return ExtJS_Columns(helper, modelMetadata);
        }
        public static MvcHtmlString ExtJS_Columns(this Mvc.HtmlHelper helper, object source)
        {
            Mvc.ModelMetadata modelMetadata = ModelExtractor.FromObjectToModelMetadata(source);
            Columns columns = new Columns(modelMetadata.Properties);

            MvcHtmlString result = new MvcHtmlString(Utils.DataToJson(columns));
            return result;
        }

        public static MvcHtmlString ExtJS_ModelCreate(this Mvc.HtmlHelper helper)
        {
            return new MvcHtmlString(new Model(helper.ViewData.ModelMetadata).RenderCreate());
        }
        public static MvcHtmlString ExtJS_ModelCreate(this Mvc.HtmlHelper helper, object source)
        {
            return new MvcHtmlString(new Model(source).RenderCreate());
        }
        public static MvcHtmlString ExtJS_ModelCreate(this Mvc.HtmlHelper helper, Model model)
        {
            return new MvcHtmlString(model.RenderCreate());
        }
        public static MvcHtmlString ExtJS_ModelDefine(this Mvc.HtmlHelper helper, string modelName)
        {
            return new MvcHtmlString(new Model(helper.ViewData.ModelMetadata).RenderDefine(modelName));
        }
        public static MvcHtmlString ExtJS_ModelDefine(this Mvc.HtmlHelper helper, object source, string modelName)
        {
            return new MvcHtmlString(new Model(source).RenderDefine(modelName));
        }
        public static MvcHtmlString ExtJS_ModelDefine(this Mvc.HtmlHelper helper, Model model, string modelName)
        {
            return new MvcHtmlString(model.RenderDefine(modelName));
        }

        public static MvcHtmlString ExtJS_StoreCreate(this Mvc.HtmlHelper helper)
        {
            return ExtJS_StoreCreate(helper, helper.ViewData.ModelMetadata);
        }
        public static MvcHtmlString ExtJS_StoreCreate(this Mvc.HtmlHelper helper, object source)
        {
          return ExtJS_StoreCreate(helper, ModelExtractor.FromObjectToExtJSModelMetadata(source).store);
        }
        public static MvcHtmlString ExtJS_StoreCreate(this Mvc.HtmlHelper helper, IStore store)
        {
            return new MvcHtmlString(store.RenderCreate().ToString());
        }
        public static MvcHtmlString ExtJS_StoreDefine(this Mvc.HtmlHelper helper, string storeName)
        {
            return ExtJS_StoreDefine(helper, helper.ViewData.ModelMetadata, storeName);
        }
        public static MvcHtmlString ExtJS_StoreDefine(this Mvc.HtmlHelper helper, object source, string storeName)
        {
            return ExtJS_StoreDefine(helper, ModelExtractor.FromObjectToExtJSModelMetadata(source).store, storeName);
        }
        public static MvcHtmlString ExtJS_StoreDefine(this Mvc.HtmlHelper helper, IStore store, string storeName)
        {
            return new MvcHtmlString(store.RenderDefine(storeName).ToString());
        }
    }
}