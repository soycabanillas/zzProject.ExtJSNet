using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvc = System.Web.Mvc;
using System.Linq.Expressions;
using zzProject.MVCExtender.ExtJS.ModelMetadata;
using zzProject.MVCExtender.Metadata.CommonExtension;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;

namespace zzProject.MVCExtender.ExtJS.HtmlHelper
{
    public static class ModelExtractor
    {
        // This helper method extracts the property name from the Expression<T>
        private static string ExpressionToPropertyName<TModel, TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Expression body = expression.Body;

            UnaryExpression unaryExpression = body as UnaryExpression;
            if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Convert)  // Boxing value type to object
                body = unaryExpression.Operand;

            MemberExpression memberExpression = (MemberExpression)body;
            return memberExpression.Member.Name;
        }
        
        public static Mvc.ModelMetadata FromObjectToModelMetadata(object source)
        {
            if (source as ExtJSModelMetadata != null)
                return ((ExtJSModelMetadata)source).ModelMetadata;
            if (source as Model != null)
                return ((Model)source).ExtJSModelMetadata.ModelMetadata;
            if (source as Type != null)
                return Mvc.ModelMetadataProviders.Current.GetMetadataForType(() => null, (Type)source);
            else if (source as Mvc.ModelMetadata != null)
                return (Mvc.ModelMetadata)source;
            else
                return Mvc.ModelMetadataProviders.Current.GetMetadataForType(() => null, source.GetType());
        }
        
        private static ExtJSModelMetadata CommonFromObjectToExtJSModelMetadata(object source)
        {
            if (source as ExtJSModelMetadata != null)
                return ((ExtJSModelMetadata)source);
            if (source as Model != null)
                return ((Model)source).ExtJSModelMetadata;
            Mvc.ModelMetadata modelMetadata = FromObjectToModelMetadata(source);
            if (modelMetadata as IExtJSModelMetadataGetter != null)
                return ((IExtJSModelMetadataGetter)modelMetadata).getMM_ExtJSModelMetadata();
            return null;
        }
        public static ExtJSModelMetadata FromObjectToExtJSModelMetadata(object source)
        {
            var result = CommonFromObjectToExtJSModelMetadata(source);
            if (result == null)
                throw new System.ArgumentException("Cannot be infered a ExtJSModelMetadata from the parameter.");
            else
                return result;
        }
        public static bool TryFromObjectToExtJSModelMetadata(object source, out ExtJSModelMetadata metadata)
        {
            var result = CommonFromObjectToExtJSModelMetadata(source);
            if (result == null)
            {
                metadata = null;
                return false;
            }
            else
            {
                metadata = result;
                return true;
            }
        }

        private static CommonExtensionModelMetadata CommonFromObjectToCommonExtensionModelMetadata(object source)
        {
            if (source as CommonExtensionModelMetadata != null)
                return ((CommonExtensionModelMetadata)source);

            Mvc.ModelMetadata modelMetadata = FromObjectToModelMetadata(source);
            if (modelMetadata as ICommonExtensionModelMetadataGetter != null)
                return ((ICommonExtensionModelMetadataGetter)modelMetadata).getMM_CommonExtensionModelMetadata();
            return null;
        }
        public static CommonExtensionModelMetadata FromObjectToCommonExtensionsModelMetadata(object source)
        {
            var result = CommonFromObjectToCommonExtensionModelMetadata(source);
            if (result == null)
                throw new System.ArgumentException("Cannot be infered a CommonExtensionModelMetadata from the parameter.");
            else
                return result;
        }
        public static bool TryFromObjectToCommonExtensionModelMetadata(object source, out CommonExtensionModelMetadata metadata)
        {
            var result = CommonFromObjectToCommonExtensionModelMetadata(source);
            if (result == null)
            {
                metadata = null;
                return false;
            }
            else
            {
                metadata = result;
                return true;
            }
        }

        public static Mvc.ModelMetadata FromLambdaExpression_Property<TModel, TValue>(Expression<Func<TModel, TValue>> expression)
        {
            string propertyName = ExpressionToPropertyName(expression);
            return Mvc.ModelMetadataProviders.Current.GetMetadataForProperty(() => null, typeof(TModel), propertyName);
        }
    }
}
