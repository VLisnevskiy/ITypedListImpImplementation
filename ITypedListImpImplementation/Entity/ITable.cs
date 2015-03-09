using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ITypedListImpImplementation.Entity
{
    public interface ITable<TId>
    {
        [Key]
        TId Id { get; set; }
    }
}
