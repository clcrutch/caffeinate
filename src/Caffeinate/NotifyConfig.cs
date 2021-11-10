using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffeinate
{
    internal record NotifyConfig(string URL, string SuccessfulBodyTemplate, string FailedBodyTemplate, Dictionary<string, string[]> Headers, string HttpMethod = "POST")
    {
    }
}
