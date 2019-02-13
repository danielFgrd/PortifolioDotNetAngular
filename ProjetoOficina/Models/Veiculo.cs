using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_oficina.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int IdProprietario { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}