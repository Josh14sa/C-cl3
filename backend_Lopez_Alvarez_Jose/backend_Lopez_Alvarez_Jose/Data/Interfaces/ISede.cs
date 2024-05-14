using backend_Lopez_Alvarez_Jose.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace backend_Lopez_Alvarez_Jose.Data.Interfaces
{
    public interface ISede
    {

        Task<IEnumerable<Sede>> listarSede();
        Task<Sede> obtenerSede(Guid id);
        Task<Sede> registrarSede(AddSede addSedes);
        Task<Sede> actualizarSede(Guid id, UpdateSede updateSedes);
        Task<Sede> eliminarSede(Guid id);
    }
}
