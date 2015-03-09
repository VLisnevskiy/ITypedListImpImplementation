using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ITypedListImpImplementation.Entity
{
    [XmlRoot("XmlTable")]
    public class SerializableContainer<TSource> : IXmlSerializable where TSource : class, new()
    {
        public SerializableContainer()
        {
            ItemsList = new List<TSource>();
        }

        public List<TSource> ItemsList { get; set; }

        public string TableName { get; set; }

        public string TypeName { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XDocument doc = XDocument.Load(reader);
            if (null != doc.Root)
            {
                TableName = doc.Root.GetAttributeValue<string>("TableName");
                TypeName = doc.Root.GetAttributeValue<string>("TypeName");

                XmlSerializer serializer = new XmlSerializer(typeof (TSource));
                foreach (XElement element in doc.Root.Elements("Row"))
                {
                    using (Stream stream = new MemoryStream())
                    {
                        element.Save(stream);
                        stream.Position = 0;
                        TSource item = serializer.Deserialize(stream) as TSource;
                        if (null != item)
                        {
                            ItemsList.Add(item);
                        }
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("TableName", TableName);
            writer.WriteAttributeString("TypeName", TypeName);

            writer.WriteStartElement("Header");
            XmlSerializer serializer = new XmlSerializer(typeof (XmlColumn));
            foreach (XmlColumn column in ColumnsManager.GetColumns<ProjectItem>())
            {
                serializer.Serialize(writer, column);
            }
            writer.WriteEndElement();

            serializer = new XmlSerializer(typeof (TSource));
            foreach (TSource item in ItemsList)
            {
                serializer.Serialize(writer, item);
            }
        }
    }

    public static class DescriptorManager
    {
        private static Dictionary<Type, Dictionary<string, PropertyDescriptor>> map =new Dictionary<Type, Dictionary<string, PropertyDescriptor>>();

        static DescriptorManager()
        {

        }

        public static Dictionary<string, PropertyDescriptor> GetCollection<TSource>() where TSource : class, new()
        {
            if (!map.ContainsKey(typeof (TSource)))
            {
                Dictionary<string, PropertyDescriptor> descriptors = new Dictionary<string, PropertyDescriptor>();
                foreach (PropertyDescriptor descriptor in GetDescriptorCollection<TSource>())
                {
                    descriptors.Add(descriptor.Name, descriptor);
                }

                map.Add(typeof (TSource), descriptors);
            }

            return map[typeof (TSource)];
        }

        private static PropertyDescriptorCollection GetDescriptorCollection<TSource>() where TSource : class, new()
        {
            TSource source = new TSource();
            if (source is ICustomTypeDescriptor)
            {
                List<Attribute> attributes = new List<Attribute>();
                attributes.Add(new ColumnDescriptionAttribute());
                return ((ICustomTypeDescriptor) source).GetProperties(attributes.ToArray());
            }

            return TypeDescriptor.GetProperties(source, true);
        }
    }
}
