using AutoMapper;
using Managemail.DAL.Entities;
using Managemail.Model.Common.Interfaces;
using Managemail.Model.Implementations;

namespace Managemail.Repository
{
    public class AutomapperRepositoryConfigurationProfile : Profile
    {
        public AutomapperRepositoryConfigurationProfile()
        {
            CreateMap<ImportanceType, IImportanceTypeModel>().ReverseMap();
            CreateMap<ImportanceType, ImportanceTypeModel>().ReverseMap();

            CreateMap<IEmailHistoryModel, EmailHistory>().ReverseMap();
            CreateMap<EmailHistoryModel, EmailHistory>().ReverseMap();
        }
    }
}
