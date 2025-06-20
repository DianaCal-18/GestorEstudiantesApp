using ConsoleAppGestorEstudiantes.Domain.Base;
using Domain.Base;

namespace Domain.Entities
{
    public class Grupo
    {
        public string? nombreGrupo { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public void AgregarEstudiante(Estudiante estudiante)
        {
            Estudiantes.Add(estudiante);
        }

        public string MostrarListadoNotas()
        {
            return string.Join(Environment.NewLine, Estudiantes.Select(e => e.MostrarInfo()));
        }

        public decimal CalcularPorcentajeAprobados()
        {
            if (!Estudiantes.Any()) return 0;

            int aprobados = Estudiantes.Count(e => e.EstaAprobado());
            return (aprobados * 100m) / Estudiantes.Count;
        }
    }
}
