using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Model.Common.Infrastructure
{
    public interface IOptionsParameters
    {
        List<String> Includes { get; set; }
    }
}
