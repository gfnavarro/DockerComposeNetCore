using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFN.PrivateWebApi.AppLogic
{
    public interface ISampleRepository
    {
        List<string> GetLastValues(int count);
    }
}
