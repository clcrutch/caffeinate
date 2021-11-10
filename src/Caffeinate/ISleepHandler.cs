using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffeinate
{
    internal interface ISleepHandler : IDisposable, IAsyncDisposable
    {
        Task AllowSleepAsync();
        Task PreventSleepAsync();
    }
}
