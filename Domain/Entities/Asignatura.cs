namespace Domain.Entities
{
    public class Asignatura
    {
        public string? nombreAsignatura { get; set; }
        public string? codigo { get; set; }
        public List<Grupo> grupos { get; set; } = new();

        public void AgregarGrupo(Grupo grupo)
        {
            grupos.Add(grupo);
        }

        public Grupo? ObtenerGrupo(string nombreGrupo)
        {
            return grupos.FirstOrDefault(g => g.nombreGrupo == nombreGrupo);
        }

        public string MostrarResumen()
        {
            var resumen = $"Asignatura: {nombreAsignatura} ({codigo})\n";
            foreach (var grupo in grupos)
            {
                resumen += $"Grupo: {grupo.nombreGrupo}\n";
                resumen += grupo.MostrarListadoNotas();
                resumen += $"\nPorcentaje aprobados: {grupo.CalcularPorcentajeAprobados():F2}%\n\n";
            }

            return resumen;
        }
    }
}
