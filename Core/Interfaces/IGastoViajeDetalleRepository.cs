using Core.DTO;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGastoViajeDetalleRepository
    {
        Task<IEnumerable<GastosViajeDetalleEntity>> GetGastoViajeDetalle();
        Task PostGastoViajeDetalle(GastosViajeDetalleEntity gastoviajedetalle);
        Task<IEnumerable<HistorialDTO>> GetGastoViajeDetalle(string UsuarioAsesor, DateTime inicio, DateTime fin, int page, int size, int estado);
        Task<IEnumerable<HistorialDetalleDTO>> GetGastoViajeDetalle(int id);
        Task<IEnumerable<ImagenDTO>> GetGastoViajeDetalleImagen(int id);
        int GetGastoViajeDetalle(string UsuarioAsesor, int id);
        Task<IEnumerable<noSync>> GetGastoViajeDetalle(string UsuarioAsesor, int idEstado, int page, int size);
        Task<IEnumerable<GastosPendientesDTO>> GetGastoViajeDetalle(string UsuarioAsesor, int page, int size);
        Task<IEnumerable<GastosPendientesDTO>> GetGastoViajeDetalle(int idEstado,int page, int size, string empresa);
        Task PutGastoViajeDetalle(int id, GastosViajeDetalleEntity gasto);
        Task<Boolean> GetGastoViajeDetalleVerificar(string noFactura);
    }
}
