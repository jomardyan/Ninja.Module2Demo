using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NinjaDomain.Classes.Interfaces
{
    interface IModificationHostory
    {
        DateTime DataModified { get; set; }
        DateTime DataCreated { get; set; }
        bool IsDirty { get; set; }

    }
}
