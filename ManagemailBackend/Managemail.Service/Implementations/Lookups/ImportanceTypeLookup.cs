using Managemail.Common.Extensions;
using Managemail.Common.Infrastructure;
using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Model.Infrastructure;
using Managemail.Repository.Common.Interfaces;
using Managemail.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Service.Implementations.Lookups
{
    public class ImportanceTypeLookup : IImportanceTypeLookup
    {
        public ImportanceTypeLookup(IImportanceTypeRepository repository)
        {
            Repository = repository;
        }

        public IImportanceTypeRepository Repository { get; }

        public Task<IEnumerable<IImportanceTypeModel>> GetAllAsync()
        {
            IOptionsParameters optionsParameters = new OptionsParameters();
            optionsParameters.Sorter = PropertyName.GetPropertyName<IImportanceTypeModel>(c => c.Sort).GetDefaultLookupSorter();
            return Repository.GetAllAsync(optionsParameters);
        }
    }
}
