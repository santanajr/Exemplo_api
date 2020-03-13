using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain
{
    public class Cartao
    {
        public int Id { get; set; }
        public string NumeroCartao { get; set; }

        public string Bandeira { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
