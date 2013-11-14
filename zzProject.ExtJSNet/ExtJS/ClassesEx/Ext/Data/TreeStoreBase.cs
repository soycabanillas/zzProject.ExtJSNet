using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data
{
    public class TreeStoreBase : Store, ITreeStore
    {
        private Model _model;
        private new Model model { 
            get { return this._model; } 
            set { 
                base.model = value;
                this._model = value; } 
        }

        [JsonIgnore]
        public NodeInterface root { get { return this.attributes.GetOrDefault<NodeInterface>("root"); } set { this.attributes["root"] = value; } }
        [JsonIgnore]
        public string nodeParam { get { return this.attributes.GetOrDefault<string>("nodeParam", "node"); } set { this.attributes["nodeParam"] = value; } }

        protected TreeStoreBase(NodeInterface root)
            : base()
        {
            this.root = root;
        }

        public TreeStoreBase(string modelName, NodeInterface root)
            : base(modelName)
        {
            this.root = root;
        }

        public TreeStoreBase(Model model, NodeInterface root)
            : base(model)
        {
            this.root = root;
        }

        public override string StoreCreateClassName { get { return "Ext.data.TreeStore"; } }
    }
}
