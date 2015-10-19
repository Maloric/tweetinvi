using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examplinvi.Web.StreamManagers
{
    public interface IStreamManager
    {
        void Start();
        void Stop();
    }
}
