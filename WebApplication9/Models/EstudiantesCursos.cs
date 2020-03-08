using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class EstudiantesCursos
    {
        public int idEstudiante { get; set; }
        public int IdCursos { get; set; }
        public Alumnos Alumno { get; set; }
        public Cursos Cursos { get; set; }
    }
}
