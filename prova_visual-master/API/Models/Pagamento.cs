using System;

namespace API.Models
{
    public class Pagamento
    {
        public Pagamento() => CriadoEm = DateTime.Now;
        public int PagamentoId { get; set; }

        public string Forma { get; set;}

        public int Desconto { get; set;}

        public int Juros { get; set;}
        public DateTime CriadoEm { get; set; }
    }
}