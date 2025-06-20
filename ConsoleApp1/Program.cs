using Application.Services;
using ConsoleAppGestorEstudiantes.Domain.Base;
using Domain.Entities;


namespace ConsoleAppGestorEstudiantes
{
    class Program
    {
        static EstudianteService estudianteService = new EstudianteService();

        static void Main(string[] args)
        {
            // datos iniciales
           estudianteService.AgregarGrupo(new Grupo { nombreGrupo = "Grupo A" });
           estudianteService.AgregarAsignatura(new Asignatura { nombreAsignatura = "Estructura de datos" });

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("  GESTOR DE ESTUDIANTES - MENU");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Listar estudiantes");
                Console.WriteLine("3. Agregar calificacion");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opcion: ");

                string opcion = Console.ReadLine()!;

                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        AgregarEstudiante();
                        break;
                    case "2":
                        ListarEstudiantes();
                        break;
                    case "3":
                        AgregarCalificacion();
                        break;
                    case "4":
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opcion Incorrecta. Intente nuevamente.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione una tecla para volver al menu...");
                    Console.ReadKey();
                }
            }
        }

        static void AgregarEstudiante()
        {
            Console.WriteLine("=== Agregar Estudiante ===");
            Console.WriteLine("Seleccione tipo de estudiante:");
            Console.WriteLine("1. Presencial");
            Console.WriteLine("2. A distancia");
            Console.Write("\nOpción: ");
            var tipo = Console.ReadLine();

            Console.Write("Nombre: ");
            var nombre = Console.ReadLine()?.Trim();

            Console.Write("Matrícula: ");
            var matricula = Console.ReadLine()?.Trim();

            var grupo = estudianteService.ObtenerTodosLosGrupos().FirstOrDefault();
            var asignatura = estudianteService.ObtenerTodasLasAsignaturas().FirstOrDefault();

            if (grupo == null || asignatura == null)
            {
                Console.WriteLine("No hay grupos o asignaturas creados.");
                return;
            }

            Estudiante estudiante;
            if (tipo == "1")
                estudiante = new EstudiantePresencial();
            else if (tipo == "2")
                estudiante = new EstudianteADistancia();
            else
            {
                Console.WriteLine("Tipo invlido. Operacion cancelada.");
                return;
            }

            estudiante.nombre = nombre;
            estudiante.matricula = matricula;

            estudianteService.AgregarEstudiante(estudiante, grupo, asignatura);

            Console.WriteLine($"Estudiante '{nombre}', ha sido agregado correctamente.");
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("=== Lista de Estudiantes ===");
            var estudiantes = estudianteService.ObtenerTodos();

            if (!estudiantes.Any())
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            foreach (var e in estudiantes)
            {
                string tipo = e is EstudiantePresencial ? "Presencial"
                           : e is EstudianteADistancia ? "A distancia"
                           : "Desconocido";

                string grupo = e.grupo?.nombreGrupo ?? "Sin grupo";
                decimal nota = e.CalcularNotaFinal();
                string estado = e.EstaAprobado() ? "Aprobado" : "Reprobado";

                Console.WriteLine($"Matrícula: {e.matricula} | Nombre: {e.nombre} | Grupo: {grupo} | Tipo: {tipo} | Nota: {nota:F2} | Estado: {estado}");
            }

        }

        static void AgregarCalificacion()
        {
            Console.WriteLine("=== Agregar Calificacion ===");

            Console.Write("Ingrese matricula del estudiante: ");
            var matricula = Console.ReadLine()?.Trim();

            var estudiante = estudianteService.BuscarPorMatricula(matricula);

            if (estudiante == null)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            bool agregarOtra = true;

            while (agregarOtra)
            {
                Console.Write("Tipo de calificación (practica/examen): ");
                var tipo = Console.ReadLine()?.ToLower().Trim();

                if (tipo != "practica" && tipo != "examen")
                {
                    Console.WriteLine("Error! Debe ser 'practica' o 'examen'.");
                    continue; // vuelve a pedir el tipo sin salir del bucle
                }

                Console.Write("Valor de la calificacion: ");
                if (!decimal.TryParse(Console.ReadLine(), out var valor))
                {
                    Console.WriteLine("Valor invalido.");
                    continue; // vuelve a pedir calificacin sin salir del bucle
                }

                estudiante.calificaciones.Add(new Calificacion { tipo = tipo, valor = valor });
                Console.WriteLine("Calificación agregada correctamente.");

                Console.Write("\n¿Desea agregar otra calificación para este estudiante? (s/n): ");
                string? respuesta = Console.ReadLine()?.Trim().ToLower();
                agregarOtra = respuesta == "s";
                Console.WriteLine();
            }
        }

    }
}

