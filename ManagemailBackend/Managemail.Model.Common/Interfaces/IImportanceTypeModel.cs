using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Model.Common.Interfaces
{
    public interface IImportanceTypeModel
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        String Name { get; set; }
        String Abrv { get; set; }
        Int32 Sort { get; set; }
    }
}
