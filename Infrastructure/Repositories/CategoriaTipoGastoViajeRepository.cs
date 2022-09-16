using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public  class CategoriaTipoGastoViajeRepository : ICategoriaTipoGastoViajeRepository
    {
        private readonly GiraAsesorContext _context;
        public CategoriaTipoGastoViajeRepository(GiraAsesorContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoriaTipoGastoViajeEntity>> GetCategoriaTipoGastoViajeEntities()
        {
            var categoria = await _context.CategoriaTipoGastoViaje.ToListAsync();
            return categoria;
        }
        public async Task<IEnumerable<CategoriaTipoGastoViajeEntity>> GetCategoriaTipoGastoViajeEntities(string empresa)
        {
            var categoria = await _context.TipoGastoViaje
                .Join(_context.CategoriaTipoGastoViaje,
                tipo => tipo.IdTipoGastoViaje,
                categoria => categoria.IdTipoGastoViaje,
                (tipo, categoria) => new { Tipo = tipo, Categoria = categoria})
                .Where(x => x.Tipo.Empresa == empresa && x.Categoria.Activo == true)
                .Select(x=> new CategoriaTipoGastoViajeEntity
                {
                    IdCategoriaTipoGastoViaje = x.Categoria.IdCategoriaTipoGastoViaje,
                    IdTipoGastoViaje = x.Categoria.IdTipoGastoViaje,
                    Nombre = x.Categoria.Nombre,
                    ProveedorPredefinido = x.Categoria.ProveedorPredefinido,
                    FacturaObligatoria = x.Categoria.FacturaObligatoria,
                    Descripcion = x.Categoria.Descripcion,
                    ImagenObligatoria = x.Categoria.ImagenObligatoria,
                    Activo = x.Categoria.Activo
                })
                .ToListAsync();
            return categoria;
        }

        public async Task PostCategoriaTipoGastoViaje(CategoriaTipoGastoViajeEntity categoriaTipoGastoViaje)
        {
            _context.CategoriaTipoGastoViaje.Add(categoriaTipoGastoViaje);
            await _context.SaveChangesAsync();
        }

        public async Task PutCategoriaGastoViajeDetalle(int id, CategoriaTipoGastoViajeEntity categoria)
        {
            if(id == categoria.IdCategoriaTipoGastoViaje)
            {
                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
