using ProJur.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Core.Communication
{
    public interface IMediatrHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
