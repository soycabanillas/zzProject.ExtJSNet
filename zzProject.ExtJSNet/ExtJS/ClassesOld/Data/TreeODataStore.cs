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
using zzProject.MVCExtender.ExtJS.ClassesOld.Data.Proxy;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data
{
    public abstract class TreeODataStoreAbstract : TreeStoreBase
    {
        [JsonIgnore]
        private string _url;

        protected override void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
        {
            attributes.Add("proxy", new ODataProxy(this._url));
            base.Serialize(writer, value, serializer);
        }

        public TreeODataStoreAbstract(NodeInterfaceBase root, string url) : base(root)
        {
            this._url = url;
        }

        public TreeODataStoreAbstract(string modelName, NodeInterfaceBase root, string url)
            : base(modelName, root)
        {
            this._url = url;
        }

        public TreeODataStoreAbstract(Model model, NodeInterfaceBase root, string url)
            : base(model, root)
        {
            this._url = url;
        }
    }

    public class TreeODataStore : TreeODataStoreAbstract
    {
        //If there isn't a model, the text param is used to show the tree, so you must specify 
        //values for the text property.
        public TreeODataStore(NodeInterfaceBase root, string url)
            : base(root, url)
        {
        }

        public TreeODataStore(string modelName, NodeInterfaceBase root, string url)
            : base(modelName, root, url)
        {
        }

        public TreeODataStore(Model model, NodeInterfaceBase root, string url)
            : base(model, root, url)
        {
        }
    }

    public class TreeODataStore<TElement> : TreeODataStoreAbstract
    {
        public TreeODataStore(NodeInterface<TElement> root, string url)
            : base(new Model(typeof(TElement)), root, url)
        {
        }

        //public TreeArrayStore(IQueryable<T> query, Expression<Func<T, object>> groupProperty, Func<IGrouping<object, T>, NodeInterface, int, NodeInterface> createNode)
        //{
        //    this.root = NodeInterface.ExpandRootNode<T>(query, groupProperty, createNode);
        //}

        //public TreeArrayStore(string modelName, IQueryable<T> query, Expression<Func<T, object>> groupProperty, Func<IGrouping<object, T>, NodeInterface, int, NodeInterface> createNode) 
        //    : base(modelName)
        //{
        //    this.root = NodeInterface.ExpandRootNode<T>(query, groupProperty, createNode);
        //}

        //public TreeArrayStore(TreeModel model, IQueryable<T> query, Expression<Func<T, object>> groupProperty, Func<IGrouping<object, T>, NodeInterface, int, NodeInterface> createNode)
        //    : base(model)
        //{
        //    this.root = NodeInterface.ExpandRootNode<T>(query, groupProperty, createNode);
        //}
    }
}
