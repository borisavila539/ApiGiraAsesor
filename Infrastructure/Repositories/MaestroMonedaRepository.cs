using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MaestroMonedaRepository : IMaestroMonedaRepository
    {
        
        private readonly GiraAsesorContext _context;
        public MaestroMonedaRepository(GiraAsesorContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MaestroMonedaEntity>> GetMaestroMoneda(string empresa)
        {
            var abreviatura = await  _context.MonedasxEmpresa
                .Join(_context.MaestroMoneda,
                monedasxEmpresa => monedasxEmpresa.IdMoneda,
                maestroMoneda => maestroMoneda.IdMoneda,
                (monedasxEmpresa, maestroMoneda) => new { MonedasxEmpresa = monedasxEmpresa, MaestroMoneda= maestroMoneda }
                )
                .Where(x=> x.MonedasxEmpresa.EmpresaId== empresa && x.MonedasxEmpresa.IdMoneda != "USD")
                .Select(x => new MaestroMonedaEntity
                {
                    IdMoneda = x.MaestroMoneda.IdMoneda,
                    Moneda = x.MaestroMoneda.Moneda,
                    Abreviacion = x.MaestroMoneda.Abreviacion
                })
                .ToListAsync();
            return abreviatura;
        }
    }
}
