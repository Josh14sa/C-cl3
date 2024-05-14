using Microsoft.EntityFrameworkCore;
using backend_Lopez_Alvarez_Jose.Data.Interfaces;
using backend_Lopez_Alvarez_Jose.Models;

namespace backend_Lopez_Alvarez_Jose.Data.DAO
{
    public class SedeDAO : ISede
    {

        private readonly APIDbContext dbContext;
        public SedeDAO(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Sede> actualizarSede(Guid id, UpdateSede updateSedes)
        {
            var sed = await dbContext.sede.FindAsync(id);

            if (sed != null)
            {
                sed.nombre = updateSedes.nombre;
                sed.direccion = updateSedes.direccion;
                sed.referencia = updateSedes.referencia;
                sed.telefono = updateSedes.telefono;
                sed.horaAtencion = updateSedes.horaAtencion;
                sed.director = updateSedes.director;
                sed.contacto = updateSedes.contacto;
                sed.emailContacto = updateSedes.emailContacto;
                sed.numeroConsultorios = updateSedes.numeroConsultorios;
                sed.numeroCamas = updateSedes.numeroCamas;
                sed.sitioWeb = updateSedes.sitioWeb;
                sed.estado = updateSedes.estado;

                await dbContext.SaveChangesAsync();
            }
            return sed;
        }

        public async Task<Sede> eliminarSede(Guid id)
        {
            var sed = await dbContext.sede.FindAsync(id);

            if (sed != null)
            {
                dbContext.Remove(sed);
                await dbContext.SaveChangesAsync();
            }
            return sed;
           
        }

        public async Task<IEnumerable<Sede>> listarSede()
        {
            return await dbContext.sede.ToListAsync();
        }

        public async Task<Sede> obtenerSede(Guid id)
        {
            var Sede = await dbContext.sede.FindAsync(id);
            return Sede;
        }

        public async Task<Sede> registrarSede(AddSede addSedes)
        {
            Sede sed = new Sede();
            sed.idSede = Guid.NewGuid();
            sed.nombre = addSedes.nombre;
            sed.direccion = addSedes.direccion;
            sed.referencia = addSedes.referencia;
            sed.telefono = addSedes.telefono;
            sed.horaAtencion = addSedes.horaAtencion;
            sed.director = addSedes.director;
            sed.contacto = addSedes.contacto;
            sed.emailContacto = addSedes.emailContacto;
            sed.numeroConsultorios = addSedes.numeroConsultorios;
            sed.numeroCamas = addSedes.numeroCamas;
            sed.sitioWeb = addSedes.sitioWeb;
            sed.estado = addSedes.estado;

            await dbContext.sede.AddAsync(sed);
            await dbContext.SaveChangesAsync();

            return sed;
        }
    }
}
