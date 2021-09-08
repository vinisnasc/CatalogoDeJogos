using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.DTO.ViewModel
{
    public class PlataformaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Desenvolvedor { get; set; }
        public int Ano { get; set; }
    }
}
