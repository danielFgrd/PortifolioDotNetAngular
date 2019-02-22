using System;
using System.Collections.Generic;

namespace ProjetoOficina.Models
{
    public partial class Estado
    {
        public Estado()
        {
            OrdemServicoIdEstadoNavigation = new HashSet<OrdemServico>();
            OrdemServicoIdEstadoOrcamentoNavigation = new HashSet<OrdemServico>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<OrdemServico> OrdemServicoIdEstadoNavigation { get; set; }
        public virtual ICollection<OrdemServico> OrdemServicoIdEstadoOrcamentoNavigation { get; set; }
    }
}
