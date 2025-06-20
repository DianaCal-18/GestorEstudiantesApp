using ConsoleAppGestorEstudiantes.Domain.Base;
using Domain.Base;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IEstudianteService
    {
        void AgregarEstudiante(Estudiante estudiante, Grupo grupo, Asignatura asignatura);
        List<Estudiante> ObtenerTodos();
        Estudiante? BuscarPorMatricula(string matricula);
        List<Estudiante> ObtenerEstudiantesPorGrupo(string nombreGrupo);
        decimal CalcularPorcentajeAprobados(string nombreGrupo);
        void AgregarGrupo(Grupo grupo);
        List<Grupo> ObtenerTodosLosGrupos();
        void AgregarAsignatura(Asignatura asignatura);
        List<Asignatura> ObtenerTodasLasAsignaturas();
    }
}
