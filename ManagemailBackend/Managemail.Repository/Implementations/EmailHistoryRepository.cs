using AutoMapper;
using Managemail.DAL.Entities;
using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Repository.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Repository.Implementations
{
    public class EmailHistoryRepository : BaseRepository, IEmailHistoryRepository
    {
        public EmailHistoryRepository(ManagemailDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<IEmailHistoryModel>> FindAsync(IOptionsParameters options)
        {
            var list = DbContext.EmailHistories.AsQueryable();
            list = await OnIncludeAsync(list, options);
            var orderedList = await OnSorterAsync(list, options);

            return Mapper.Map<IEnumerable<IEmailHistoryModel>>(await orderedList.ToListAsync());
        }

        public async Task<bool> InsertAsync(IEmailHistoryModel model)
        {
            EmailHistory entity = Mapper.Map<EmailHistory>(model);
            await DbContext.AddAsync(entity);
            return await DbContext.SaveChangesAsync() == 1; //there is only one that needs to be saved in database so this is only one operation
        }
    }
}
