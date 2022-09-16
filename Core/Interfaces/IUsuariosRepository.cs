using Core.DTO;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task PostUsuarioByUser(DatosCorreoDTO datos);
    }}
