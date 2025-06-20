
namespace Domain.Base
{
    //Clase OperationResult: Maneja los errores 
    public class OperationResult
    {
        // Propiedades
        public String? message { get; set; }
        public bool success { get; set; }
        public dynamic? data { get; set; }
    }
}
