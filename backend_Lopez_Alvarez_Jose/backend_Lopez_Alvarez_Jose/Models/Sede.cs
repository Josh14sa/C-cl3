using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_Lopez_Alvarez_Jose.Models
{
    public class Sede
    {

        [Key]

        public Guid idSede { get; set; }

        [StringLength(250)]
        public string nombre { get; set; }

        [StringLength(250)]
        public string direccion { get; set; }

        [StringLength(250)]
        public string referencia { get; set; }

        [StringLength(24)]
        public string telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime horaAtencion { get; set; }

        [StringLength(250)]
        public string director {  get; set; }

        [StringLength(250)]
        public string contacto { get; set; }

        [StringLength(250)]
        public string emailContacto { get; set; }
        public int numeroConsultorios { get; set; }
        public int numeroCamas { get; set; }

        [StringLength(250)]
        public string sitioWeb { get; set; }
        public int estado { get; set; }


    }
}
