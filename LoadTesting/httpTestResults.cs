using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadTesting
{
    [Serializable]
    public class testResult
    {
        public long intDownBytes;
        public long intDownTimeMS;
        public long intWaitTimeMS;
        public long intConnectTimeMS;
        public int intHTTPStatus;
    }
}
