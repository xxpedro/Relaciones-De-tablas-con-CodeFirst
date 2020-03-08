using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public partial class Cursos
    {
        [Key]
        public int idCursos { get; set; }
        public string Nombre { get; set; }
        public virtual List<EstudiantesCursos> Alumnos { get; set; }
        public Profesores profesores { get; set; }
    }
}
