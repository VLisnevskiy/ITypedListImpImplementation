using System;

namespace ITypedListImpImplementation.Entity
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnDescriptionAttribute : Attribute
    {
        public ColumnDescriptionAttribute() : base()
        {
        }

        public ColumnDescriptionAttribute(string caption, bool isNullable, Type type) : this()
        {
            Caption = caption;
            IsNullable = isNullable;
            Type = type;
        }

        /// <summary>
        /// Caption.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type <see cref="System.Type"/>.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Is nullable.
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Default value.
        /// </summary>
        public string DefaultValue { get; set; }

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
            return string.Format("{0}", string.IsNullOrEmpty(Caption) ? base.ToString() : Caption);
        }

        #endregion
    }
}