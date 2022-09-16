using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EstadoRepository : IEstadosRepository
    {
        private readonly GiraAsesorContext _context;
        public EstadoRepository(GiraAsesorContext context)
        {
            _context = context;
        }
        public async Task< IEnumerable<EstadoEntity>> GetEstados()
        {
            var estados = await _context.Estado.ToListAsync();
            return estados;
        }
    }
}
