using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int IdCartao { get; set; }
        public int IdCliente { get; set; }

        public int IdEstabelecimento { get; set; }
        public Double Valor { get; set; }
        public Boolean Valida { get; set; }
    }
}
