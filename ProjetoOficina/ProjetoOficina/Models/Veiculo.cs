using System;
using System.Collections.Generic;

namespace ProjetoOficina.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            OrdemServico = new HashSet<OrdemServico>();
        }

        public int Id { get; set; }
        public int IdProprietario { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public virtual Usuario IdProprietarioNavigation { get; set; }
        public virtual ICollection<OrdemServico> OrdemServico { get; set; }
    }
}
