using FluentValidation.Results;
using ProJur.Core.Messages;
using System.Threading.Tasks;

namespace ProJur.Core.Communication
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
