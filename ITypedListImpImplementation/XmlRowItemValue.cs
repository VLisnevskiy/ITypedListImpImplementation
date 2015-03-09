/**************************************************************************************************
 * <copyright file="XmlRowItemValue.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Contains value of some column in XmlRow.
    /// </summary>
    public class XmlRowItemValue
    {
        internal XmlRowItemValue()
        {
        }

        public XmlRowItemValue(object original)
        {
            Original = original;
            Value = original;
        }

        public object Value { get; set; }

        public string Error { get; set; }

        internal object Original { get; private set; }

        protected void SetOriginal(object value)
        {
            Value = value;
        }

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0}", Value);
        }

        #endregion
    }
}