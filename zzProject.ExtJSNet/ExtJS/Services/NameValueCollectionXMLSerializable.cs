using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace zzProject.MVCExtender.ExtJS.Services
{
    public class NameValueCollectionXmlSerializable : IXmlSerializable
    {
        private NameValueCollection data;

        public NameValueCollectionXmlSerializable()
        {
        }

        public NameValueCollectionXmlSerializable(NameValueCollection data)
        {
            this.data = data;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                writer.WriteElementString(this.data.GetKey(i), this.data.Get(i));
            }
        }
    }
}