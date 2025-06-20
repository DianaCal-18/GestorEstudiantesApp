namespace Domain.Entities
{
    public class Docente
    {
        public string? nombre { get; set; }
        public List<Asignatura> asignaturas { get; set; } = new();

        public void AgregarAsignatura(Asignatura asignatura)
        {
            asignaturas.Add(asignatura);
        }

        public Asignatura? ObtenerAsignatura(string codigo)
        {
            return asignaturas.FirstOrDefault(a => a.codigo == codigo);
        }

        public string MostrarResumenDocente()
        {
            var resumen = $"Docente: {nombre}";
            foreach (var asignatura in asignaturas)
            {
                resumen += asignatura.MostrarResumen();
            }
            return resumen;
        }
    }
}
