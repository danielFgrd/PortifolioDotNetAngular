using System;
using System.Collections.Generic;

namespace ProjetoOficina.Models
{
    public partial class OrdemServico
    {
        public int Id { get; set; }
        public int IdProprietario { get; set; }
        public int IdVeiculoManutencao { get; set; }
        public int? IdMecanicoResponsavel { get; set; }
        public string DefeitoEspecificado { get; set; }
        public string AvaliacaoMecanico { get; set; }
        public int? IdEstado { get; set; }
        public string ObsLiberacao { get; set; }
        public double? Orcamento { get; set; }
        public int? IdEstadoOrcamento { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Estado IdEstadoOrcamentoNavigation { get; set; }
        public virtual Usuario IdMecanicoResponsavelNavigation { get; set; }
        public virtual Usuario IdProprietarioNavigation { get; set; }
        public virtual Veiculo IdVeiculoManutencaoNavigation { get; set; }
    }
}
