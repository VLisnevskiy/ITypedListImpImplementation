/**************************************************************************************************
 * <copyright file="XmlTable.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Represent Xml data in table view.
    /// </summary>
    public class XmlTable : BindingList<XmlRow>, ITypedList, IBindingList
        //, IBindingListView
    {
        #region Public Properties

        public string TableName { get; protected set; }

        public List<XmlColumn> Columns { get; protected set; }

        #endregion

        #region Constructor

        public XmlTable(string tableName) : base()
        {
            TableName = tableName;
            Columns = new List<XmlColumn>();
            AllowNew = true;
        }

        public XmlTable(List<XmlColumn> columns, string tableName) : this(tableName)
        {
            if (null == columns)
            {
                throw new ArgumentNullException("columns", "Input columns collection can't be null!");
            }

            Columns = columns;
        }

        #endregion

        #region Static

        public static XmlTable Parse(string xml)
        {
            return Deserialize(XDocument.Parse(xml));
        }

        public static XmlTable Load(Stream stream)
        {
            if (stream.CanSeek)
            {
                stream.Position = 0;
            }

            return Deserialize(XDocument.Load(stream));
        }

        public static XmlTable Load(string url)
        {
            return Deserialize(XDocument.Load(url));
        }

        protected static XmlTable Deserialize(XDocument document)
        {
            if ("XmlTable" != document.Root.Name || document.Root.Element("Header") == null || document.Root.Elements("Row").Count() <= 0)
            {
                throw new ArgumentException("Input source is not compatible with XmlTable!");
            }

            XmlTable table = new XmlTable(document.Root.GetAttributeValue<string>("TableName"));
            foreach (XElement element in document.Root.Elements("Header").Elements("Column"))
            {
                table.Columns.Add(new XmlColumn(element));
            }

            foreach (XElement element in document.Root.Elements("Row"))
            {
                table.Add(new XmlRow(table, element));
            }

            return table;
        }

        #endregion

        #region Protected overrided

        protected override object AddNewCore()
        {
            object newItem = FireAddingNew();

            if (newItem == null)
            {
                newItem = new XmlRow(this);
            }

            Add((XmlRow) newItem);

            return newItem;
        }

        #endregion

        #region Private methods

        private object FireAddingNew()
        {
            AddingNewEventArgs e = new AddingNewEventArgs(null);
            OnAddingNew(e);
            return e.NewObject;
        }

        #endregion

        #region Public New methods

        public new void Add(XmlRow row)
        {
            if (!Contains(row))
            {
                base.Add(row);
            }
        }

        public void AddColumn(XmlColumn column)
        {
            if (!Columns.Contains(column))
            {
                Columns.Add(column);
                propertyCollection = null;
            }
        }

        public XmlColumn FindColumn(string fieldName)
        {
            return Columns.FirstOrDefault(column => column.FieldName == fieldName);
        }

        public XmlColumn FindColumnByCaption(string caption)
        {
            return Columns.FirstOrDefault(column => column.Caption == caption);
        }

        #endregion

        #region ITypedList

        private PropertyDescriptorCollection propertyCollection { get; set; }

        public PropertyDescriptorCollection PropertyCollection
        {
            get
            {
                if (null == propertyCollection)
                {
                    List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
                    foreach (XmlColumn column in Columns)
                    {
                        properties.Add(new XmlItemPropertyDescriptor(column));
                    }

                    propertyCollection = new PropertyDescriptorCollection(properties.ToArray(), false);
                }

                return propertyCollection;
            }
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null || listAccessors.Length == 0)
            {
                return PropertyCollection;
            }

            throw new NotImplementedException("Relations not implemented");
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return TableName;
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format(TableName);
        }

        #endregion
    }
}