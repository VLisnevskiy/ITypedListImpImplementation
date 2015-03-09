using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ITypedListImpImplementation.Entity
{
    public class CustomFieldSetup : ITable<int>
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        //[Column(Order = 0)]*/
        public virtual int Id { get; set; }

        /// <summary>
        /// Field Name.
        /// </summary>
        //[Key]
        //[Column(Order = 1)]
        public virtual string FieldName { get; set; }

        /// <summary>
        /// Caption.
        /// </summary>
        public virtual string Caption { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Type name.
        /// </summary>
        public virtual string TypeName { get; set; }

        /// <summary>
        /// Is nullable.
        /// </summary>
        public virtual bool IsNullable { get; set; }

        /// <summary>
        /// Default value.
        /// </summary>
        public virtual string DefaultValue { get; set; }

        /// <summary>
        /// Is read only.
        /// </summary>
        public virtual bool ReadOnly { get; set; }

        /// <summary>
        /// Is required.
        /// </summary>
        public virtual bool Required { get; set; }
    }
}
