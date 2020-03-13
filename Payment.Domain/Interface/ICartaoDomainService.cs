using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Interface
{
    public interface ICartaoDomainService
    {
        public bool Adicionar(Payment.Domain.Cartao CartaoDomain);

        public bool Editar(Payment.Domain.Cartao CartaoDomain);
    }
}
