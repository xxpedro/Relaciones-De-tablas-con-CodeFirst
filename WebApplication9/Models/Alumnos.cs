using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public partial class Alumnos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual List<EstudiantesCursos> Cursos { get; set; }
    }
}
