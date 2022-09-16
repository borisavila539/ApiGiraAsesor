using Core.DTO;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public  class GastoViajeDetalleRepository : IGastoViajeDetalleRepository
    {
        private readonly GiraAsesorContext _context;
        public GastoViajeDetalleRepository(GiraAsesorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GastosViajeDetalleEntity>> GetGastoViajeDetalle()
        {
            var historial = await _context.GastosViajeDetalle.ToListAsync();
            return historial;
        }

        public async Task<IEnumerable<HistorialDTO>> GetGastoViajeDetalle(string UsuarioAsesor , DateTime inicio, DateTime fin, int page, int size, int estado)
        {
            var historial = await _context.GastosViajeDetalle
                .Join(_context.CategoriaTipoGastoViaje,
                    gasto => gasto.IdCategoriaTipoGastoViaje,
                    categoria => categoria.IdCategoriaTipoGastoViaje,
                    (gasto, categoria) => new { Gasto = gasto, Categoria = categoria }
                )
                .Join(_context.TipoGastoViaje,
                    gastocategoria => gastocategoria.Categoria.IdTipoGastoViaje,
                    tipo => tipo.IdTipoGastoViaje,
                    (gastocategoria, tipo) => new { GastoCategoria = gastocategoria, Tipo = tipo }
                )
                .Join(_context.Estado,
                gastoEstado => gastoEstado.GastoCategoria.Gasto.IdEstado,
                estado => estado.IdEstado,
                (gastoEstado , Estado) => new { GastoEstado = gastoEstado, Estado = Estado }
                )
                .Where(x => x.GastoEstado.GastoCategoria.Gasto.UsuarioAsesor == UsuarioAsesor
                                && (inicio <= x.GastoEstado.GastoCategoria.Gasto.FechaFactura)
                                && (fin >= x.GastoEstado.GastoCategoria.Gasto.FechaFactura )
                                )
                .Where(x => estado != 0 ? x.GastoEstado.GastoCategoria.Gasto.IdEstado == estado : true)
                .Select(x => new HistorialDTO
                {
                    IdGastoViajeDetalle = x.GastoEstado.GastoCategoria.Gasto.IdGastoViajeDetalle,
                    categoria = x.GastoEstado.GastoCategoria.Categoria.Nombre,
                    ValorFactura = x.GastoEstado.GastoCategoria.Gasto.ValorFactura,
                    FechaFactura = x.GastoEstado.GastoCategoria.Gasto.FechaFactura,
                    FechaCreacion = x.GastoEstado.GastoCategoria.Gasto.FechaCreacion,
                    Estado = x.Estado.Nombre
                })
                .OrderByDescending(x => x.FechaFactura)
                .ThenByDescending(x => x.FechaCreacion)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return historial;
        }

        public async Task<IEnumerable<HistorialDetalleDTO>> GetGastoViajeDetalle(int id)
        {
            var detalleGasto = await _context.GastosViajeDetalle
                .Join(_context.CategoriaTipoGastoViaje,
                    gasto => gasto.IdCategoriaTipoGastoViaje,
                    categoria => categoria.IdCategoriaTipoGastoViaje,
                    (gasto, categoria) => new { Gasto = gasto, Categoria = categoria }
                )
                .Join(_context.TipoGastoViaje,
                    gastocategoria => gastocategoria.Categoria.IdTipoGastoViaje,
                    tipo => tipo.IdTipoGastoViaje,
                    (gastocategoria, tipo) => new { GastoCategoria = gastocategoria, Tipo = tipo }
                )
                .Where(x => x.GastoCategoria.Gasto.IdGastoViajeDetalle == id)
                .Select(x => new HistorialDetalleDTO
                {
                    IdGastoViajeDetalle = x.GastoCategoria.Gasto.IdGastoViajeDetalle,
                    Tipo = x.Tipo.Nombre,
                    categoria = x.GastoCategoria.Categoria.Nombre,
                    UsuarioAsesor = x.GastoCategoria.Gasto.UsuarioAsesor,
                    Proveedor = x.GastoCategoria.Gasto.Proveedor,
                    NoFactura = x.GastoCategoria.Gasto.NoFactura,
                    Descripcion = x.GastoCategoria.Gasto.Descripcion,
                    DescripcionAdmin = x.GastoCategoria.Gasto.DescripcionAdmin != null ? x.GastoCategoria.Gasto.DescripcionAdmin:"" ,
                    ValorFactura = x.GastoCategoria.Gasto.ValorFactura,
                    FechaFactura = x.GastoCategoria.Gasto.FechaFactura,
                    FechaCreacion = x.GastoCategoria.Gasto.FechaCreacion,
                    imagen = x.GastoCategoria.Gasto.Imagen,
                    Admin = x.GastoCategoria.Gasto.Administrador != null ? x.GastoCategoria.Gasto.Administrador:"",
                    serie = x.GastoCategoria.Gasto.serie
                })
                .ToListAsync();

            return detalleGasto;
        }

        public async Task<IEnumerable<noSync>> GetGastoViajeDetalle(string UsuarioAsesor, int idEstado,int page, int size)
        {

            var noSincronizado = await _context.GastosViajeDetalle
                .Join(_context.CategoriaTipoGastoViaje,
                    gasto => gasto.IdCategoriaTipoGastoViaje,
                    categoria => categoria.IdCategoriaTipoGastoViaje,
                    (gasto, categoria) => new { Gasto = gasto, Categoria = categoria }
                )
                .Where(x => x.Gasto.UsuarioAsesor == UsuarioAsesor && x.Gasto.IdEstado == idEstado)
                .Select(x => new noSync
                {
                    IdGastoViajeDetalle = x.Gasto.IdGastoViajeDetalle,
                    categoria = x.Categoria.Nombre,
                    ValorFactura = x.Gasto.ValorFactura,
                    FechaFactura = x.Gasto.FechaFactura,
                    FechaCreacion = x.Gasto.FechaCreacion
                })
                .OrderByDescending(x => x.FechaFactura)
                .ThenByDescending(x => x.FechaCreacion)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return noSincronizado;
        }

        public async Task<IEnumerable<GastosPendientesDTO>> GetGastoViajeDetalle(int idEstado, int page, int size, string empresa)
        {
            var pendientes = await _context.GastosViajeDetalle
                .Join(_context.CategoriaTipoGastoViaje,
                    gasto => gasto.IdCategoriaTipoGastoViaje,
                    categoria => categoria.IdCategoriaTipoGastoViaje,
                    (gasto, categoria) => new { Gasto = gasto, Categoria = categoria }
                )
                .Join(_context.TipoGastoViaje,
                    gastocategoria => gastocategoria.Categoria.IdTipoGastoViaje,
                    tipo => tipo.IdTipoGastoViaje,
                    (gastocategoria, tipo) => new { GastoCategoria = gastocategoria, Tipo = tipo }
                )
                .Where(x=>x.GastoCategoria.Gasto.IdEstado==idEstado && x.Tipo.Empresa == empresa)
                .Select(x=> new GastosPendientesDTO { 
                    IdGastoViajeDetalle = x.GastoCategoria.Gasto.IdGastoViajeDetalle,
                    categoria = x.GastoCategoria.Categoria.Nombre,
                    UsuarioAsesor = x.GastoCategoria.Gasto.UsuarioAsesor,
                    Proveedor = x.GastoCategoria.Gasto.Proveedor,
                    NoFactura = x.GastoCategoria.Gasto.NoFactura,
                    Descripcion =x.GastoCategoria.Gasto.Descripcion,
                    ValorFactura = x.GastoCategoria.Gasto.ValorFactura,
                    FechaFactura = x.GastoCategoria.Gasto.FechaFactura,
                    FechaCreacion = x.GastoCategoria.Gasto.FechaCreacion
                })
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return pendientes;
        }

        public async Task<IEnumerable<GastosPendientesDTO>> GetGastoViajeDetalle(string UsuarioAsesor, int page, int size)
        {
            var historial = await _context.GastosViajeDetalle
                .Join(_context.CategoriaTipoGastoViaje,
                    gasto => gasto.IdCategoriaTipoGastoViaje,
                    categoria => categoria.IdCategoriaTipoGastoViaje,
                    (gasto, categoria) => new { Gasto = gasto, Categoria = categoria }
                )
                .Join(_context.TipoGastoViaje,
                    gastocategoria => gastocategoria.Categoria.IdTipoGastoViaje,
                    tipo => tipo.IdTipoGastoViaje,
                    (gastocategoria, tipo) => new { GastoCategoria = gastocategoria, Tipo = tipo }
                )
                .Where(x => x.GastoCategoria.Gasto.UsuarioAsesor == UsuarioAsesor)
                .Select(x => new GastosPendientesDTO
                {
                    IdGastoViajeDetalle = x.GastoCategoria.Gasto.IdGastoViajeDetalle,
                    categoria = x.GastoCategoria.Categoria.Nombre,
                    UsuarioAsesor = x.GastoCategoria.Gasto.UsuarioAsesor,
                    Proveedor = x.GastoCategoria.Gasto.Proveedor,
                    NoFactura = x.GastoCategoria.Gasto.NoFactura,
                    Descripcion = x.GastoCategoria.Gasto.Descripcion,
                    ValorFactura = x.GastoCategoria.Gasto.ValorFactura,
                    FechaFactura = x.GastoCategoria.Gasto.FechaFactura,
                    FechaCreacion = x.GastoCategoria.Gasto.FechaCreacion
                })
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return historial;
        }

        public int GetGastoViajeDetalle(string UsuarioAsesor, int id)
        {
            var num =  _context.GastosViajeDetalle.Count(x => x.UsuarioAsesor == UsuarioAsesor && x.IdEstado == id);
            return num;
        }

        public async Task<IEnumerable<ImagenDTO>> GetGastoViajeDetalleImagen(int id)
        {
            var imagen = await _context.GastosViajeDetalle.Where(x=>x.IdGastoViajeDetalle==id)
                .Select(x=> new ImagenDTO { 
                    idGastoViajeDetalle = x.IdGastoViajeDetalle,
                    imagen = x.Imagen
                })
                .ToListAsync();
            return imagen;
        }

        public async Task<Boolean> GetGastoViajeDetalleVerificar(string noFactura)
        {
            var factura = await _context.GastosViajeDetalle.Where(x => x.NoFactura.Replace("-", "").Replace("-", "").Replace("-", "") == noFactura)
                .Select(x => new
                {
                    noFactura = x.NoFactura
                }).ToListAsync();
            var num = 0;
            factura.ForEach(x =>
            {
                num++;
            });

            if(num == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public async Task PostGastoViajeDetalle(GastosViajeDetalleEntity gastoviajedetalle)
        {
            var estado =  _context.Estado.FirstOrDefault(x => x.Nombre == "Pendiente");

            gastoviajedetalle.IdEstado = estado.IdEstado;
            if (gastoviajedetalle.Imagen != null)
            {
                string s = Convert.ToBase64String(gastoviajedetalle.Imagen);
                gastoviajedetalle.Imagen = Convert.FromBase64String(s);
            }
            _context.GastosViajeDetalle.Add(gastoviajedetalle);
            await _context.SaveChangesAsync();
        }


        public async Task PutGastoViajeDetalle(int id, GastosViajeDetalleEntity gasto)
        {
            if(id == gasto.IdGastoViajeDetalle)
            {
                _context.Entry(gasto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
