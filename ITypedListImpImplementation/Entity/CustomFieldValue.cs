using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ITypedListImpImplementation.Entity
{
    public class CustomFieldValue : ITable<int>
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// Field Name.
        /// </summary>
        //[ForeignKey("CustomFieldSetup")]
        //[Column(Order = 0)]
        public virtual string FieldName { get; set; }

        /// <summary>
        /// Field Value.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Custom Field Setup Id.
        /// </summary>
        [ForeignKey("CustomFieldSetup")]
        [Column(Order = 0)]
        public virtual int FieldSetupId { get; set; }

        /// <summary>
        /// Lookup Setup.
        /// </summary>
        public virtual CustomFieldSetup CustomFieldSetup { get; set; }

        /// <summary>
        /// Project Item Id.
        /// </summary>
        [ForeignKey("ProjectItem")]
        [Column(Order = 1)]
        public virtual int ProjectItemId { get; set; }

        /// <summary>
        /// Project Item.
        /// </summary>
        public virtual ProjectItem ProjectItem { get; set; }
    }
}
