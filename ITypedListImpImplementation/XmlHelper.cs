/**************************************************************************************************
 * <copyright file="XmlHelper.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.Xml.Linq;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Xml helper.
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Get value of xml attribute.
        /// </summary>
        /// <typeparam name="TResult">Type of results.</typeparam>
        /// <param name="element">Input element.</param>
        /// <param name="name">Name of attribute.</param>
        /// <returns>Return value of attribute.</returns>
        public static TResult GetAttributeValue<TResult>(this XElement element, string name)
        {
            TResult result = default(TResult);
            XmlQueryStringConverter converter = new XmlQueryStringConverter();
            XAttribute attribute = element.Attribute(name);
            if (null != attribute)
            {
                if (converter.CanConvert(typeof(TResult)))
                {
                    result = converter.ConvertStringToValue<TResult>(attribute.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Get value of xml element.
        /// </summary>
        /// <typeparam name="TResult">Type of results.</typeparam>
        /// <param name="rootElement">Input element.</param>
        /// <param name="name">Name of element.</param>
        /// <returns>Return value of element.</returns>
        public static TResult GetValue<TResult>(this XElement rootElement, string name)
        {
            TResult result = default(TResult);
            XmlQueryStringConverter converter = new XmlQueryStringConverter();
            XElement element = rootElement.Element(name);
            if (null != element)
            {
                if (converter.CanConvert(typeof(TResult)))
                {
                    result = converter.ConvertStringToValue<TResult>(element.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Get value of xml element.
        /// </summary>
        /// <param name="rootElement">Input element.</param>
        /// <param name="name">Name of element.</param>
        /// <param name="type">Type of results.</param>
        /// <returns>Return value of element.</returns>
        public static object GetValue(this XElement rootElement, string name, Type type)
        {
            object result = DBNull.Value;
            XmlQueryStringConverter converter = new XmlQueryStringConverter();
            XElement element = rootElement.Element(name);
            if (null != element)
            {
                if (converter.CanConvert(type))
                {
                    result = converter.ConvertStringToValue(element.Value, type);
                }
            }

            return result;
        }

        /// <summary>
        /// Convert input string value to some type.
        /// </summary>
        /// <param name="value">Input string value.</param>
        /// <param name="type">Type of convertation.</param>
        /// <returns>Return converted value.</returns>
        public static object Convert(this object value, Type type)
        {
            if (null == value || typeof (string) != value.GetType())
            {
                return null;
            }

            XmlQueryStringConverter converter = new XmlQueryStringConverter();
            if (converter.CanConvert(type))
            {
                return converter.ConvertStringToValue(value.ToString(), type);
            }

            return null;
        }
    }
}
