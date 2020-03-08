using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public partial class Profesores
    {
        [Key]
        public int idProfesores { get; set; }
        public string Nombre { get; set; }
        public int idCursos { get; set; }
        public Cursos Curso { get; set; }
    }
}
