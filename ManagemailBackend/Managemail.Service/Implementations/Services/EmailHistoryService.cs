using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Repository.Common.Interfaces;
using Managemail.Service.Common.Infrastructure;
using Managemail.Service.Common.Interfaces;
using Managemail.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Service.Implementations.Services
{
    public class EmailHistoryService : IEmailHistoryService
    {
        public EmailHistoryService(IEmailHistoryRepository repository)
        {
            Repository = repository;
        }

        public IEmailHistoryRepository Repository { get; }

        public Task<IEnumerable<IEmailHistoryModel>> FindAsync(IOptionsParameters options)
        {
            return Repository.FindAsync(options);
        }

        public async Task<IResultModel> InsertAsync(IEmailHistoryModel model)
        {
            IResultModel result = new ResultModel();

            try
            {
                await OnInsertAsync(model);
                bool succeeded = await Repository.InsertAsync(model);

                if (succeeded)
                {
                    result.Succeeded = true;
                    result.Value = model;
                }
                else
                {
                    result.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Message = "Something went wrong.";
                //handle exception e.g. contact developer
            }
            return result;
        }

        private Task OnInsertAsync(IEmailHistoryModel model)
        {
            model.Id = Guid.NewGuid();
            model.DateCreated = DateTime.UtcNow;
            model.DateUpdated = DateTime.UtcNow;
            return Task.FromResult(true);
        }
    }
}
