using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficina.Responses
{
    public class Response<T>
    {
        public T Dados { get; set; }

        private List<string> Erros;

        public List<string> getErros()
        {
            if (this.Erros == null)
                this.Erros = new List<string>();
            return this.Erros;
        }
        
        public void setErros(List<string> erros)
        {
            this.Erros = erros;
        }
    }
}
