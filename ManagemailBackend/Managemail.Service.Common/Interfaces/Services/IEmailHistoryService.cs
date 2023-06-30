using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Service.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Service.Common.Interfaces
{
    public interface IEmailHistoryService
    {
        Task<IEnumerable<IEmailHistoryModel>> FindAsync(IOptionsParameters options);
        Task<IResultModel> InsertAsync(IEmailHistoryModel model);
    }
}
