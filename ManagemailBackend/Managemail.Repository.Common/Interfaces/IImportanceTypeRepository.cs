using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Repository.Common.Interfaces
{
    public interface IImportanceTypeRepository
    {
        Task<IEnumerable<IImportanceTypeModel>> GetAllAsync(IOptionsParameters optionsParameters);
    }
}
