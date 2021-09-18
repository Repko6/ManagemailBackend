using AutoMapper;
using Managemail.DAL.Entities;
using Managemail.Model.Common.Interfaces;
using Managemail.Repository.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managemail.Repository.Implementations
{
    public class ImportanceTypeRepository : IImportanceTypeRepository
    {
        public ImportanceTypeRepository(ManagemailDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public ManagemailDbContext DbContext { get; }
        public IMapper Mapper { get; }

        public async Task<IEnumerable<IImportanceTypeModel>> GetAllAsync()
        {
            var list = await DbContext.ImportanceTypes.ToListAsync();
            return Mapper.Map<IEnumerable<IImportanceTypeModel>>(list);
        }
    }
}
