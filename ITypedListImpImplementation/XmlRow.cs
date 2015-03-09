/**************************************************************************************************
 * <copyright file="XmlRow.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Xml Row. Represent some row in XmlTable.
    /// </summary>
    public class XmlRow : ObservableObject, IDataErrorInfo, ICustomTypeDescriptor
    {
        #region Publis Properties

        public List<XmlColumn> Columns
        {
            get
            {
                if (null == Table)
                {
                    return null;
                }

                return Table.Columns;
            }
        }

        public Dictionary<XmlColumn, XmlRowItemValue> Items { get; private set; }

        public XmlTable Table { get; private set; }

        #endregion

        #region Constructor

        internal XmlRow(XmlTable table, XElement element)
        {
            Table = table;
            Items = new Dictionary<XmlColumn, XmlRowItemValue>();

            foreach (XmlColumn column in Columns)
            {
                Items.Add(column, new XmlRowItemValue(element.GetValue(column.FieldName, column.Type)));
            }

            rowChanged = false;
        }

        internal XmlRow(XmlTable table)
        {
            Table = table;
            Items = new Dictionary<XmlColumn, XmlRowItemValue>();
            PopulateDefaultValues();
            rowChanged = false;
        }

        public XmlRow(XmlTable table, bool populateWithDefValue)
        {
            Table = table;
            Items = new Dictionary<XmlColumn, XmlRowItemValue>();

            if (populateWithDefValue)
            {
                PopulateDefaultValues();
            }

            rowChanged = false;
        }

        #endregion

        #region Protected Methods

        protected void PopulateDefaultValues()
        {
            foreach (XmlColumn column in Columns)
            {
                Items.Add(column, new XmlRowItemValue(column.DefaultValue));
            }
        }

        #endregion

        #region Indexers

        public object this[XmlColumn column]
        {
            get
            {
                if (null == column)
                {
                    return null;
                }

                XmlRowItemValue value;
                if (Items.TryGetValue(column, out value))
                {
                    return value;
                }

                return null;
            }
            set
            {
                if (null == column)
                {
                    return;
                }

                if (!column.IsNullable && null == value)
                {
                    throw new ArgumentNullException(column.FieldName, "Value for this column can't be null!");
                }

                if (null != value && column.Type != value.GetType())
                {
                    string message = string.Format("Incorrect type casting, you can't cast type {0} to type {1}.",
                        column.Type.FullName,
                        value.GetType().FullName);
                    throw new ArgumentException(message);
                }

                if (!Items.ContainsKey(column) || null == Items[column])
                {
                    Items[column] = new XmlRowItemValue(column.DefaultValue);
                }

                Items[column].Value = value;
                rowChanged = true;
                NotifyPropertyChanged(column.FieldName);
            }
        }

        public object this[int columnIndex]
        {
            get { return this[GetColumn(columnIndex)]; }
            set { this[GetColumn(columnIndex)] = value; }
        }

        public object this[string fieldName]
        {
            get { return this[GetColumn(fieldName)]; }
            set { this[GetColumn(fieldName)] = value; }
        }

        protected XmlColumn GetColumn(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return null;
            }

            return Columns.FirstOrDefault(col => col.FieldName == fieldName);
        }

        protected XmlColumn GetColumn(int columnIndex)
        {
            if (0 < columnIndex && Columns.Count > columnIndex)
            {
                return null;
            }

            return Columns[columnIndex];
        }

        #endregion

        #region Edit / Update

        private bool rowChanged;

        public bool RowChanged
        {
            get { return rowChanged; }
        }

        public void BeginEdit()
        {
        }

        public void EndEdit()
        {
        }

        public void Delete()
        {
        }

        public bool HasErrors
        {
            get
            {
                return !string.IsNullOrEmpty(Error);
            }
        }

        public void ClearErrors()
        {
            Error = string.Empty;
            foreach (KeyValuePair<XmlColumn, XmlRowItemValue> item in Items)
            {
                if (!string.IsNullOrEmpty(item.Value.Error))
                {
                    item.Value.Error = string.Empty;
                }
            }
        }

        #endregion

        #region IDataErrorInfo

        public void SetError(string error)
        {
            Error = error;
        }

        public void SetError(string columnName, string error)
        {
            XmlColumn column = GetColumn(columnName);
            if (null == column)
            {
                return;
            }

            Items[column].Error = error;
            Error = error;
        }

        public string Error { get; protected set; }

        string IDataErrorInfo.Error
        {
            get { return Error; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                XmlColumn column = GetColumn(columnName);
                if (null == column)
                {
                    return string.Empty;
                }

                XmlRowItemValue value;
                if (Items.TryGetValue(column, out value))
                {
                    return value.Error;
                }

                return string.Empty;
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
            //PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, attributes, true);
            //return props;
            return Table.PropertyCollection;
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            //PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, true);
            //return props;
            return Table.PropertyCollection;
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("XmlRow - Status: {0}", RowChanged);
        }

        #endregion
    }
}