using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmpresaRepository
    {
        public Task<IEnumerable<DocumentoFiscalDTO>> GetEmpresa(string empresa);
    }
}
