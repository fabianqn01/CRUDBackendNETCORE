using System.Collections.Generic;
using System.Threading.Tasks;
using SystemPro.Core.Entities;

namespace SystemPro.Core.Interfaces
{
    public interface ITypeIdentificationRepository
    {
        Task<IEnumerable<TypeIdentification>> GetTypesIdentification();
    }
}
