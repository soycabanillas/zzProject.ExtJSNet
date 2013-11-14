using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.ModelMetadata;
using zzProject.MVCExtender.ExtJS.HtmlHelper;
using System.Linq.Expressions;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field.ComboboxStore
{
    public class ComboboxRemoteStore : ComboboxStoreBase
    {
        public ComboboxRemoteStore(string valueField, string displayField) : base(valueField, displayField)
        {
        }

        public static ComboboxRemoteStore CreateComboboxRemoteStore<TModel, TValue1, TValue2>(Expression<Func<TModel, TValue1>> expressionValueField, Expression<Func<TModel, TValue2>> expressionDisplayField)
        {
            //ExtJSModelMetadata extJSMM = ModelExtractor.FromObjectToExtJSModelMetadata(typeof(TModel));
            //Model.GetKeys(modelMetadata);
            //Model.GetFields(modelMetadata);
            string valueField = ModelExtractor.FromLambdaExpression_Property<TModel, TValue1>(expressionValueField).PropertyName;
            string displayField = ModelExtractor.FromLambdaExpression_Property<TModel, TValue2>(expressionDisplayField).PropertyName;
            return new ComboboxRemoteStore(valueField, displayField);
        }

        public override QueryMode GetQueryMode()
        {
            return QueryMode.remote;
        }
    }
}
