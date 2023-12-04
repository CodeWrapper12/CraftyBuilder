using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace craftyBuilder.Domain.Interfaces
{
    public interface IAiService
    {
        Task<string> SendMessageAsync(string m, bool isInternalCommunication);

    }
}