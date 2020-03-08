using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class EscuelitaTablas:DbContext
    {

        public EscuelitaTablas(DbContextOptions<EscuelitaTablas> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Cursos>()
                .HasKey(x => x.idCursos);

            modelBuilder.Entity<EstudiantesCursos>().HasKey(x => new { x.IdCursos, x.idEstudiante });

            modelBuilder.Entity<EstudiantesCursos>()
                .HasOne(x => x.Cursos)
                .WithMany(m => m.Alumnos)
                .HasForeignKey(x => x.IdCursos);

            modelBuilder.Entity<EstudiantesCursos>()
               .HasOne(x => x.Alumno)
               .WithMany(m => m.Cursos)
               .HasForeignKey(x => x.idEstudiante);

            modelBuilder.Entity<Cursos>()
               .HasOne(b => b.profesores)
               .WithOne(i => i.Curso)
               .HasForeignKey<Profesores>(b => b.idCursos);

        }

        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<EstudiantesCursos> estudiantesCursos { get; set; }

    }
}
