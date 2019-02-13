namespace projeto_oficina.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public int IdProprietario { get; set; }
        public int idVeiculoManutencao { get; set; }
        public int IdMecanicoResponsavel { get; set; }
        public string DefeitoEspecificado { get; set; }
        public int IdEstado { get; set; }
        public string AvaliacaoMecanico { get; set; }
        public string ObsLiberacao { get; set; }
        public double Orcamento { get; set; }
        public int IdEstadoOrcamento { get; set; }
    }
}