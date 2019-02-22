using System;
using System.Collections.Generic;

namespace ProjetoOficina.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            OrdemServicoIdMecanicoResponsavelNavigation = new HashSet<OrdemServico>();
            OrdemServicoIdProprietarioNavigation = new HashSet<OrdemServico>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public int IdPoliticaAcesso { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public virtual PoliticaAcesso IdPoliticaAcessoNavigation { get; set; }
        public virtual ICollection<OrdemServico> OrdemServicoIdMecanicoResponsavelNavigation { get; set; }
        public virtual ICollection<OrdemServico> OrdemServicoIdProprietarioNavigation { get; set; }
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
