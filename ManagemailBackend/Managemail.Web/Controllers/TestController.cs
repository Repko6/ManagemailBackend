using System.Collections.Generic;
using System.Threading.Tasks;
using Managemail.Common;
using Managemail.Model.Common.Interfaces;
using Managemail.Service.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Managemail.Web
{
    [ApiController]
    [Route(StringConstants.DefaultApiRoute + "[controller]")]
    public class TestController : ControllerBase
    {
        public TestController(IImportanceTypeLookup importanceTypeLookup)
        {
            ImportanceTypeLookup = importanceTypeLookup;
        }

        public IImportanceTypeLookup ImportanceTypeLookup { get; }

        [HttpGet]
        public Task<IEnumerable<IImportanceTypeModel>> GetAsync()
        {
            return ImportanceTypeLookup.GetAllAsync();
        }
    }
}
