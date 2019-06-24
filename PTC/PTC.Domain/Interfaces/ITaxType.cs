using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Interfaces
{
    public interface ITaxType
    {
        int? Id { get; set; }

        string TypeName { get; set; }
    }
}
