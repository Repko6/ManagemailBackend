using Managemail.Model.Common.Interfaces;
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
            return Repository.GetAllAsync();
        }
    }
}
