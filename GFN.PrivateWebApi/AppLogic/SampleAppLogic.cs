using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFN.PrivateWebApi.AppLogic
{
    public class SampleAppLogic
    {

        ISampleRepository sampleRpository;

        public SampleAppLogic(ISampleRepository sampleRpository)
        {
            this.sampleRpository = sampleRpository;
        }    

        public List<string> GetLastValues(int count)
        {
            return this.sampleRpository.GetLastValues(count);
        }
    }
}
