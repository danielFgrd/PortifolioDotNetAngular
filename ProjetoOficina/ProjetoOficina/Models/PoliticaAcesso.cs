using System;
using System.Collections.Generic;

namespace ProjetoOficina.Models
{
    public partial class PoliticaAcesso
    {
        public PoliticaAcesso()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
