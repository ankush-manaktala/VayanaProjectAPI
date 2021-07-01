using System;
using System.Threading.Tasks;

namespace VayanaProjectDataContracts
{
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// Commit Data
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();
    }
}
