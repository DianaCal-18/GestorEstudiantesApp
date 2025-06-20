using Domain.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppGestorEstudiantes
{
    namespace Domain.Base
    {
        /// <summary>
        /// Clase base abstracta para estudiantes (presencial o a distancia).
        /// </summary>
        public abstract class Estudiante
        {
            // Propiedades del estudiante
            public string? nombre { get; set; }
            public string? matricula { get; set; }
            public Grupo? grupo { get; set; }
            public Asignatura? asignatura { get; set; }


            // Lista de calificaciones por estudiante
            public List<Calificacion> calificaciones { get; set; } = new();

            /// <summary>
            /// Método virtual para calcular la nota final.
            /// Puede ser sobrescrito por clases derivadas si la lógica cambia.
            /// </summary>
            public virtual decimal CalcularNotaFinal()
            {
                decimal sumaPracticas = 0, sumaExamenes = 0;
                int countPracticas = 0, countExamenes = 0;

                foreach (var c in calificaciones)
                {
                    switch (c.tipo?.ToLower())
                    {
                        case "practica":
                            sumaPracticas += c.valor;
                            countPracticas++;
                            break;
                        case "examen":
                            sumaExamenes += c.valor;
                            countExamenes++;
                            break;
                    }
                }

                decimal promedioPracticas = countPracticas > 0 ? sumaPracticas / countPracticas : 0;
                decimal promedioExamenes = countExamenes > 0 ? sumaExamenes / countExamenes : 0;

                return (promedioPracticas * 0.7m) + (promedioExamenes * 0.3m);
            }


            /// <summary>
            /// Devuelve true si la nota final es mayor o igual a 70.
            /// </summary>
            public bool EstaAprobado() => CalcularNotaFinal() >= 70;

            public virtual string MostrarInfo()
            {
                return $"{nombre} - Nota Final: {CalcularNotaFinal():F2} - {(EstaAprobado() ? "Aprobado" : "Reprobado")}";
            }
        }

    }
}