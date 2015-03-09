/**************************************************************************************************
 * <copyright file="ObservableObject.cs" company="" author="Vyacheslav Lisnevskiy">
 * Copyright (c) 2015 All Rights Reserved.
 * </copyright>
 *************************************************************************************************/

using System;
using System.ComponentModel;
using System.Linq;

namespace ITypedListImpImplementation
{
    /// <summary>
    /// Class that represent simple implementation of INotifyPropertyChanged.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        protected event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                if (null != PropertyChanged &&
                    PropertyChanged.GetInvocationList().Any(@delegate => @delegate == (Delegate) value))
                {
                    return;
                }

                PropertyChanged += value;
            }
            remove
            {
                if (null != PropertyChanged &&
                    PropertyChanged.GetInvocationList().Any(@delegate => @delegate == (Delegate) value))
                {
                    PropertyChanged -= value;
                }
            }
        }

        protected void NotifyPropertyChanged()
        {
            if (null != PropertyChanged)
            {
                var callingMethod = new System.Diagnostics.StackTrace(1, false).GetFrame(0).GetMethod();
                string propertyName = "Items";

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}