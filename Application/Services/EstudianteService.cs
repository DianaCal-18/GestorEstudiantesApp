using Application.Interfaces;
using ConsoleAppGestorEstudiantes.Domain.Base;
using Domain.Base;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly List<Grupo> _grupos = new();
        private readonly List<Asignatura> _asignaturas = new();

        public void AgregarEstudiante(Estudiante estudiante, Grupo grupo, Asignatura asignatura)
        {
            estudiante.grupo = grupo;
            estudiante.asignatura = asignatura;
            grupo.Estudiantes.Add(estudiante);
        }

        public List<Estudiante> ObtenerTodos()
        {
            return _grupos.SelectMany(g => g.Estudiantes).ToList();
        }

        public Estudiante? BuscarPorMatricula(string matricula)
        {
            return _grupos.SelectMany(g => g.Estudiantes)
                          .FirstOrDefault(e => e.matricula == matricula);
        }

        public List<Estudiante> ObtenerEstudiantesPorGrupo(string nombreGrupo)
        {
            var grupo = _grupos.FirstOrDefault(g => g.nombreGrupo == nombreGrupo);
            return grupo?.Estudiantes ?? new List<Estudiante>();
        }

        public decimal CalcularPorcentajeAprobados(string nombreGrupo)
        {
            var estudiantes = ObtenerEstudiantesPorGrupo(nombreGrupo);
            if (estudiantes.Count == 0) return 0;

            int aprobados = estudiantes.Count(e => e.EstaAprobado());
            return (decimal)aprobados / estudiantes.Count * 100;
        }

        public void AgregarGrupo(Grupo grupo)
        {
            if (!_grupos.Any(g => g.nombreGrupo == grupo.nombreGrupo))
                _grupos.Add(grupo);
        }

        public List<Grupo> ObtenerTodosLosGrupos() => _grupos;

        public void AgregarAsignatura(Asignatura asignatura)
        {
            if (!_asignaturas.Any(a => a.nombreAsignatura == asignatura.nombreAsignatura))
                _asignaturas.Add(asignatura);
        }

        public List<Asignatura> ObtenerTodasLasAsignaturas() => _asignaturas;
    }
}
