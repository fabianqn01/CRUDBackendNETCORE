using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemPro.Core.Entities;
using SystemPro.Core.Interfaces;

namespace SystemPro.Core.Services
{
    public class TypeIdentificationService: ITypeIdentificationService
    {
        private readonly ITypeIdentificationRepository _ITypeIdentificationRepository;

        public TypeIdentificationService(ITypeIdentificationRepository ITypeIdentificationRepository)
        {
            _ITypeIdentificationRepository = ITypeIdentificationRepository;
        }

        public async Task<IEnumerable<TypeIdentification>> GetTypesIdentification()
        {
            return await _ITypeIdentificationRepository.GetTypesIdentification();
        }
    }
}
