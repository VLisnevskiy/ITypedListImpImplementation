using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ITypedListImpImplementation.Entity
{
    [XmlRoot("Row")]
    public class ProjectItem : ITable<int>, ICustomFieldsValue, IXmlSerializable, ICustomTypeDescriptor
    {
        public ProjectItem()
        {
            //CustomFieldValues = new List<CustomFieldValue>();
        }

        /// <summary>
        /// Id.
        /// </summary>
        [ColumnDescription("Item Id", false, typeof(int), ReadOnly = true)]
        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// Item Name.
        /// </summary>
        [ColumnDescription("Item Name", false, typeof(string))]
        public virtual string Name { get; set; }

        /// <summary>
        /// Lookup values collection.
        /// </summary>
        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }


        [ColumnDescription("Item Field0", false, typeof(string))]
        public virtual string Field0 { get; set; }


        [ColumnDescription("Item Field1", false, typeof(string))]
        public virtual string Field1 { get; set; }


        [ColumnDescription("Item Field2", false, typeof(string))]
        public virtual string Field2 { get; set; }


        [ColumnDescription("Item Field3", false, typeof(string))]
        public virtual string Field3 { get; set; }


        [ColumnDescription("Item Field4", false, typeof(string))]
        public virtual string Field4 { get; set; }


        [ColumnDescription("Item Field5", false, typeof(string))]
        public virtual string Field5 { get; set; }

        /*[ColumnDescription("Item Field6", false, typeof(string))]
        public virtual string Field6 { get; set; }*/

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XDocument doc = XDocument.Load(reader);
            if (null != doc.Root)
            {
                Dictionary<string, PropertyDescriptor> descriptors = DescriptorManager.GetCollection<ProjectItem>();
                foreach (XElement element in doc.Root.Elements())
                {
                    if (descriptors.ContainsKey(element.Name.ToString()))
                    {
                        PropertyDescriptor descriptor = descriptors[element.Name.ToString()];
                        descriptor.SetValue(this, element.GetValue(descriptor.PropertyType));
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            Dictionary<string, PropertyDescriptor> descriptors = DescriptorManager.GetCollection<ProjectItem>();
            foreach (XmlColumn column in ColumnsManager.GetColumns<ProjectItem>())
            {
                if (descriptors.ContainsKey(column.FieldName))
                {
                    object value = descriptors[column.FieldName].GetValue(this);
                    if (null != value)
                    {
                        writer.WriteStartElement(column.FieldName);
                        if (descriptors[column.FieldName] is ProjectItemCustomFieldPropertyDescriptor)
                        {
                            CustomFieldValue customFieldValue = CustomFieldValues
                                .FirstOrDefault(fieldValue => fieldValue.FieldName == column.FieldName);
                            if (null != customFieldValue)
                            {
                                writer.WriteStartAttribute("FieldValueId");
                                writer.WriteValue(customFieldValue.Id);
                                writer.WriteEndAttribute();
                            }
                        }

                        writer.WriteValue(value);
                        writer.WriteEndElement();
                    }
                }
            }
        }

        #endregion

        #region ICustomTypeDescriptor implementation

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, attributes, true);
            GetCustomProperties(ref props);
            return props;
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, true);
            GetCustomProperties(ref props);
           return props;
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        private void GetCustomProperties(ref PropertyDescriptorCollection collection)
        {
            List<PropertyDescriptor> newCollection = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor descriptor in collection)
            {
                newCollection.Add(descriptor);
            }

            foreach (CustomFieldSetup customField in ColumnsManager.CustomFields)
            {
                newCollection.Add(new ProjectItemCustomFieldPropertyDescriptor(customField));
            }

            collection = new PropertyDescriptorCollection(newCollection.ToArray(), false);
        }

        #endregion
    }
}
