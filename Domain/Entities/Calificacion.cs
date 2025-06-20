

using System.Drawing;

namespace Domain.Entities
{
    public class Calificacion
    {
        // propiedad para saber si es examen o practica
        public String? tipo { get; set; }

        //Prop valor para determinar la calificacion del examen/practica
        public decimal valor { get; set; }

        //Metodo para devolver el valor 
        public decimal ObtenerValor(decimal valor)
        {
            return valor;
        }
    }
}
