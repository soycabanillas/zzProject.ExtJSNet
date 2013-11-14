using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data
{
    public class TreeStoreBase : StoreBase, ITreeStore
    {
        private Model _model;
        private new Model model { 
            get { return this._model; } 
            set { 
                base.model = value;
                this._model = value; } 
        }

        [JsonIgnore]
        public NodeInterfaceBase root { get { return this.attributes.GetOrDefault<NodeInterfaceBase>("root"); } set { this.attributes["root"] = value; } }
        [JsonIgnore]
        public string nodeParam { get { return this.attributes.GetOrDefault<string>("nodeParam", "node"); } set { this.attributes["nodeParam"] = value; } }

        protected TreeStoreBase(NodeInterfaceBase root)
            : base()
        {
            this.root = root;
        }

        public TreeStoreBase(string modelName, NodeInterfaceBase root)
            : base(modelName)
        {
            this.root = root;
        }

        public TreeStoreBase(Model model, NodeInterfaceBase root)
            : base(model)
        {
            this.root = root;
        }

        public override string StoreCreateClassName { get { return "Ext.data.TreeStore"; } }
    }
}
