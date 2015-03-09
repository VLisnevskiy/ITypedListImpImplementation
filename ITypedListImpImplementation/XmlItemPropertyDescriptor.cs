/**************************************************************************************************
 * <copyright file="XmlItemPropertyDescriptor.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.ComponentModel;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Property descriptor for Xml row item.
    /// </summary>
    public sealed class XmlItemPropertyDescriptor : PropertyDescriptor
    {
        private XmlColumn column;

        public XmlItemPropertyDescriptor(XmlColumn column) : base(column.FieldName, null)
        {
            this.column = column;
        }

        public override Type ComponentType
        {
            get { return typeof (XmlRow); }
        }

        public override bool IsReadOnly
        {
            get { return column.ReadOnly; }
        }

        public override Type PropertyType
        {
            get { return column.Type; }
        }

        public override string Description
        {
            get { return column.Description; }
        }

        public override string DisplayName
        {
            get { return column.Caption; }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            return ((XmlRow) component)[Name];
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException("ResetValue(...) method not implemented!");
        }

        public override void SetValue(object component, object value)
        {
            ((XmlRow) component)[Name] = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}