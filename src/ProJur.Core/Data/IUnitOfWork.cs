using System.Threading.Tasks;

namespace ProJur.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
