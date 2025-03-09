using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Hangfire
{
    public interface ISenderMessage
    {
        public void Send(string message);
    }
}
