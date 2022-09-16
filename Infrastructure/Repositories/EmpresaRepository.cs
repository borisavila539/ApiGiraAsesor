using Core.DTOs;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly GiraAsesorContext _context;
        public EmpresaRepository(GiraAsesorContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DocumentoFiscalDTO>> GetEmpresa(string empresa)
        {
            var documento = await _context.Empresa.Where(x=>x.EmpresaId==empresa)
                .Select(x=> new DocumentoFiscalDTO { 
                    empresa =x.EmpresaId,
                    documento = x.DocumentoFiscal
                }).ToListAsync();
            return documento;
        }
    }
}
