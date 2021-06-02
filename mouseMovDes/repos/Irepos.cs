using System;
using System.Collections.Generic;
using System.Text;

namespace mouseMovDes.repos
{
    public interface Irepos 
    {
        void SenderVoid(string msg);

        void SetIp(string ip);
    }
}
