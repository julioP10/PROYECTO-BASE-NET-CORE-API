using System.Threading.Tasks;

namespace Domain.Core.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        Task SaveChangesAsync();
    }
}