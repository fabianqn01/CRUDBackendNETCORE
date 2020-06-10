using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemPro.Core.Entities;
using SystemPro.Core.Interfaces;
using SystemPro.Infrastructure.Data;

namespace SystemPro.Infrastructure.Repositories
{
    public class TypeIdentificationRepository : ITypeIdentificationRepository
    {
        //inyecccion de dependencias pra el contexto de base de datos, lo inyectamos por constructor
        private readonly SystemPro2Context _context;

        public TypeIdentificationRepository(SystemPro2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeIdentification>> GetTypesIdentification()
        {
            //implementacion conectando directamente a db
            //listado asincrono por la firma, por eso lleva el await en el metodo
            var types = await _context.TypeIdentification.ToListAsync();
            return types;
        }
    }
}
