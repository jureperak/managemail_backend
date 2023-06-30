using Managemail.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Service.Common.Interfaces
{
    public interface IImportanceTypeLookup
    {
        Task<IEnumerable<IImportanceTypeModel>> GetAllAsync();
    }
}
