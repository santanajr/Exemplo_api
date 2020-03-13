using Payment.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application
{
    public class CartaoAppService
    {
        public ICartaoDomainService _CartaoDomainService { get; set; }
    }
}
