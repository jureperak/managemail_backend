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
using System.Threading.Tasks;

namespace Managemail.Repository.Implementations
{
    public class ImportanceTypeRepository : BaseRepository, IImportanceTypeRepository
    {
        public ImportanceTypeRepository(ManagemailDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


        public async Task<IEnumerable<IImportanceTypeModel>> GetAllAsync(IOptionsParameters optionsParameters)
        {
            var list = DbContext.ImportanceTypes.AsQueryable();
            var orderedList = await OnSorterAsync(list, optionsParameters);
            return Mapper.Map<IEnumerable<IImportanceTypeModel>>(await orderedList.ToListAsync());
        }

    }
}
