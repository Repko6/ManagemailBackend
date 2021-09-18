using AutoMapper;
using Managemail.DAL.Entities;
using Managemail.Model.Common.Interfaces;
using Managemail.Model.Implementations;
using Managemail.Repository.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Repository.Implementations
{
    public class ImportanceTypeRepository : IImportanceTypeRepository
    {
        public ImportanceTypeRepository(ManagemailContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public ManagemailContext DbContext { get; }
        public IMapper Mapper { get; }

        public async Task<IEnumerable<IImportanceTypeModel>> GetAllAsync()
        {
            var list = await DbContext.ImportanceTypes.ToListAsync();
            return Mapper.Map<IEnumerable<IImportanceTypeModel>>(list);
        }
    }
}
