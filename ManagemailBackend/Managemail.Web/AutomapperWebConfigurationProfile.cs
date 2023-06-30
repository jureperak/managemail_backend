using AutoMapper;
using Managemail.Model.Common.Interfaces;
using Managemail.Model.Implementations;

namespace Managemail.Repository
{
    public class AutomapperWebConfigurationProfile : Profile
    {
        public AutomapperWebConfigurationProfile()
        {
            CreateMap<Web.ImportanceTypeController.ImportanceTypeGet, ImportanceTypeModel>().ReverseMap();
            CreateMap<Web.ImportanceTypeController.ImportanceTypeGet, IImportanceTypeModel>().ReverseMap();

            CreateMap<Web.EmailHistoryController.EmailHistoryGet, EmailHistoryModel>().ReverseMap();
            CreateMap<Web.EmailHistoryController.EmailHistoryGet, IEmailHistoryModel>().ReverseMap();
            CreateMap<Web.EmailHistoryController.ImportanceTypeGet, ImportanceTypeModel>().ReverseMap();
            CreateMap<Web.EmailHistoryController.ImportanceTypeGet, IImportanceTypeModel>().ReverseMap();

            CreateMap<Web.EmailHistoryController.EmailHistoryPost, EmailHistoryModel>().ReverseMap();
            CreateMap<Web.EmailHistoryController.EmailHistoryPost, IEmailHistoryModel>().ReverseMap();
        }
    }
}
