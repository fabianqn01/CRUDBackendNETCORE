using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemPro.Core.Entities;

namespace SystemPro.Core.Interfaces
{
    public interface ITypeIdentificationService
    {
        Task<IEnumerable<TypeIdentification>> GetTypesIdentification();
    }
}
