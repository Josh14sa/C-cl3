using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_Lopez_Alvarez_Jose.Models
{
    public class AddSede
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public string telefono { get; set; }
        public DateTime horaAtencion { get; set; }
        public string director { get; set; }
        public string contacto { get; set; }
        public string emailContacto { get; set; }
        public int numeroConsultorios { get; set; }
        public int numeroCamas { get; set; }
        public string sitioWeb { get; set; }
        public int estado { get; set; }

    }
}
