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
        }
    }
}
