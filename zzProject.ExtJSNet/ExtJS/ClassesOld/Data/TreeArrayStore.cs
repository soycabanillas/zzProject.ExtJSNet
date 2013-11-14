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

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data
{
    public abstract class TreeArrayStoreAbstract : TreeStoreBase
    {
        public TreeArrayStoreAbstract(NodeInterfaceBase root) : base(root)
        {
        }

        public TreeArrayStoreAbstract(string modelName, NodeInterfaceBase root)
            : base(modelName, root)
        {
        }

        public TreeArrayStoreAbstract(Model model, NodeInterfaceBase root)
            : base(model, root)
        {
        }
    }

    public class TreeArrayStore : TreeArrayStoreAbstract
    {
        //If there isn't a model, the text param is used to show the tree, so you must specify 
        //values for the text property.
        public TreeArrayStore(NodeInterfaceBase root) : base(root)
        {
        }

        public TreeArrayStore(string modelName, NodeInterfaceBase root)
            : base(modelName, root)
        {
        }

        public TreeArrayStore(Model model, NodeInterfaceBase root)
            : base(model, root)
        {
        }
    }

    public class TreeArrayStore<TElement> : TreeArrayStoreAbstract
    {
        public TreeArrayStore(NodeInterface<TElement> root)
            : base(new Model(typeof(TElement)), root)
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
