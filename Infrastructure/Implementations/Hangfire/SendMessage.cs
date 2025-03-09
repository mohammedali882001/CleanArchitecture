using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Hangfire;

namespace Infrastructure.Implementations.Hangfire
{
    public class SendMessage : ISenderMessage
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
