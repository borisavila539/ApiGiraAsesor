using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TipoGastoViajeRepository :ITipoGastoViajeRepository
    {
        private readonly GiraAsesorContext _context;
        public TipoGastoViajeRepository(GiraAsesorContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoGastoViajeEntity>> GetTipoGastoViajeEntities()
        {
            var tipo = await _context.TipoGastoViaje.ToListAsync();
            return tipo;
        }
        public async Task<IEnumerable<TipoGastoViajeEntity>> GetTipoGastoViajeEntities(string empresa)
        {
            var tipo = await _context.TipoGastoViaje.Where(x=>(x.Empresa == empresa && x.Activo == true)).ToListAsync();
            return tipo;
        }

        public async Task PostTipoGastoViaje(TipoGastoViajeEntity tipo)
        {
            _context.TipoGastoViaje.Add(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task PutTipoGastoViaje(int id, TipoGastoViajeEntity tipo)
        {
            if(id == tipo.IdTipoGastoViaje)
            {
                _context.Entry(tipo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
