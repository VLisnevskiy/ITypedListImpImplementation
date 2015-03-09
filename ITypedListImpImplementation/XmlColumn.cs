/**************************************************************************************************
 * <copyright file="XmlColumn.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using ITypedListImpImplementation.Entity;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Xml Column. Contains all information about some column in XmlTable.
    /// </summary>
    [XmlRoot("Column")]
    public class XmlColumn
    {
        public XmlColumn()
        {
            IsNullable = true;
        }

        internal XmlColumn(XElement element)
        {
            FieldName = element.GetAttributeValue<string>("FieldName");
            Caption = element.GetAttributeValue<string>("Caption");
            Description = element.GetAttributeValue<string>("Description");
            TypeName = element.GetAttributeValue<string>("TypeName");
            IsNullable = element.GetAttributeValue<bool>("IsNullable");
            ReadOnly = element.GetAttributeValue<bool>("ReadOnly");
            Required = element.GetAttributeValue<bool>("Required");

            DefaultValue = element.GetAttributeValue<string>("DefaultValue");            
        }

        internal XmlColumn(string fieldName, ColumnDescriptionAttribute attribute)
        {
            FieldName = fieldName;
            Caption = attribute.Caption;
            Description = attribute.Description;
            Type = attribute.Type;
            IsNullable = attribute.IsNullable;
            ReadOnly = attribute.ReadOnly;
            Required = attribute.Required;
            DefaultValue = attribute.DefaultValue;
        }

        internal XmlColumn(CustomFieldSetup customField)
        {
            FieldName = customField.FieldName;
            Caption = customField.Caption;
            Description = customField.Description;
            TypeName = customField.TypeName;
            IsNullable = customField.IsNullable;
            ReadOnly = customField.ReadOnly;
            Required = customField.Required;

            DefaultValue = customField.DefaultValue;            
        }

        [NonSerialized]
        private Type type;

        /// <summary>
        /// Field Name.
        /// </summary>
        [XmlAttribute]
        public string FieldName { get; set; }

        /// <summary>
        /// Caption.
        /// </summary>
        [XmlAttribute]
        public string Caption { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [XmlAttribute]
        public string Description { get; set; }

        /// <summary>
        /// Type name.
        /// </summary>
        [XmlAttribute]
        public string TypeName
        {
            get { return type.FullName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                type = Type.GetType(value, false, true);
            }
        }

        /// <summary>
        /// Type <see cref="System.Type"/>.
        /// </summary>
        [XmlIgnore]
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Is nullable.
        /// </summary>
        [XmlAttribute]
        public bool IsNullable { get; set; }

        /// <summary>
        /// Default value.
        /// </summary>        
        [XmlAttribute]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Is read only.
        /// </summary>
        [XmlAttribute]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Is required.
        /// </summary>
        [XmlAttribute]
        public bool Required { get; set; }

        #region Overrided

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("{0}", string.IsNullOrEmpty(Caption) ? FieldName ?? base.ToString() : Caption);
        }

        #endregion
    }
}