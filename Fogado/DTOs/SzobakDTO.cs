using System.ComponentModel.DataAnnotations;

namespace Fogado.DTOs
{
    public class SzobakDTO
    {
        public int Szazon { get; set; }
        public string Sznev { get; set; }
        public int Agy { get; set; }
        public int Potagy { get; set; }
    }
}
