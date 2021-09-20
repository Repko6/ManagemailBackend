using Managemail.Model.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Model.Infrastructure
{
    public class OptionsParameters : IOptionsParameters
    {
        public List<String> Includes { get; set; }
    }
}
