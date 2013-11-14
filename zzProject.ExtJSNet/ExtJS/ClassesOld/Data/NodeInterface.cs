using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.ComponentModel;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data
{
    public class NodeInterfaceUtils
    {
        public static NodeInterface Create<TQueryElement>(TQueryElement element)
        {
            NodeInterface oNode = new NodeInterface();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(element);
            foreach (PropertyDescriptor property in properties)
            {
                oNode.attributes.Add(property.Name, property.GetValue(element));
            }
            return oNode;
        }

        public static void Update<TQueryElement>(NodeInterface oNode, TQueryElement element)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(element);
            foreach (PropertyDescriptor property in properties)
            {
                oNode.attributes.Add(property.Name, property.GetValue(element));
            }
        }
    }

    public class NodeInterfaceBase : Component
    {
        protected NodeInterfaceBase()
        {
        }

        [JsonIgnore]
        public string text { get { return this.attributes.GetOrDefault<string>("text"); } set { this.attributes["text"] = value; } }
        [JsonIgnore]
        public bool leaf { get { return this.attributes.GetOrDefault<bool>("leaf", false); } set { this.attributes["leaf"] = value; } }
        [JsonIgnore]
        public bool expanded { get { return this.attributes.GetOrDefault<bool>("expanded", false); } set { this.attributes["expanded"] = value; } }
        [JsonIgnore]
        public bool? @checked { get { return this.attributes.GetOrDefault<bool?>("checked"); } set { this.attributes["checked"] = value; } }
    }

    public class NodeInterface : NodeInterfaceBase
    {
        [JsonIgnore]
        public List<NodeInterface> children { get { return this.attributes.GetOrDefault<List<NodeInterface>>("children"); } set { this.attributes["children"] = value; } }

        //public static NodeInterface ExpandRootNode<T>(IQueryable<T> query, Expression<Func<T, object>> groupProperty, Func<IGrouping<object, T>, NodeInterface, int, NodeInterface> createNode)
        //{
        //    NodeInterface root = new NodeInterface() { text = "root", expanded = true };
        //    var x = query.GroupBy(groupProperty);
        //    root.children = new List<NodeInterface>();
        //    foreach (var item in x)
        //    {
        //        root.children.Add(createNode(item, root, 1));
        //    }
        //    return root;
        //}

        //private static NodeInterface ExpandChildNode<T>(IQueryable<T> query, Expression<Func<T, string>> groupProperty, Func<IGrouping<string, T>, NodeInterface, int, NodeInterface> createNode)
        //{
        //    NodeInterface root = new NodeInterface() { text = "root", expanded = true };
        //    var x = query.GroupBy(groupProperty);
        //    foreach (var item in x)
        //    {
        //        root.children.Add(createNode(item, root, 1));
        //    }
        //    return root;
        //}
    }

    public class NodeInterface<TElement> : NodeInterfaceBase
    {
        [JsonIgnore]
        private TElement _element;
        [JsonIgnore]
        public TElement element { get { return this._element; } set { this._element = value; } }
        [JsonIgnore]
        public List<NodeInterface<TElement>> children { get { return this.attributes.GetOrDefault<List<NodeInterface<TElement>>>("children"); } set { this.attributes["children"] = value; } }
        [JsonIgnore]
        private static PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TElement));
        
        public NodeInterface()
        {
        }

        public NodeInterface(TElement element)
        {
            this.element = element;
        }

        protected override void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (this.element != null)
            {
                foreach (PropertyDescriptor property in properties)
                {
                    this.attributes.Add(property.Name, property.GetValue(this.element));
                }
            }
            base.Serialize(writer, value, serializer);
        }
    }
}
