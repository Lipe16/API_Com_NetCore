using System;

namespace netCore.api.Models
{
    public class FundoCapital{
        public FundoCapital(){
            id = Guid.NewGuid();
        }

        public Guid id {get; }
        public String nome {set; get;}
        public decimal valorNecessario { get; set; }
        public decimal valorAtual { get; set; }
        public DateTime? dataResgate { get; set; }
    }
}
