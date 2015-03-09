/**************************************************************************************************
 * <copyright file="XmlColumn.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Xml Column. Contains all information about some column in XmlTable.
    /// </summary>
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
            TypeName= element.GetAttributeValue<string>("TypeName");
            IsNullable = element.GetAttributeValue<bool>("IsNullable");
            ReadOnly = element.GetAttributeValue<bool>("ReadOnly");
            Required = element.GetAttributeValue<bool>("Required");

            string defValue = element.GetAttributeValue<string>("DefaultValue");
            if (!string.IsNullOrEmpty(defValue))
            {
                defaultValue = defValue.Convert(Type);
            }
        }

        [NonSerialized]
        private Type type;

        /// <summary>
        /// Field Name.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Caption.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type name.
        /// </summary>
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
        public bool IsNullable { get; set; }

        private object defaultValue = DBNull.Value;

        /// <summary>
        /// Default value.
        /// </summary>
        public object DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        /// <summary>
        /// Is read only.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Is required.
        /// </summary>
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