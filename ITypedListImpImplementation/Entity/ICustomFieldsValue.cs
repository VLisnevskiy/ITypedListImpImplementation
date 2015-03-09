using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITypedListImpImplementation.Entity
{
    public interface ICustomFieldsValue
    {
        ICollection<CustomFieldValue> CustomFieldValues { get; set; }
    }
}
