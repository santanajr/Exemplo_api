using Payment.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Services
{
    public class CartaoDomainService : ICartaoDomainService
    {
        private PaymentDataContext _Datacontext;

        public CartaoDomainService(PaymentDataContext context)
        {
            _Datacontext = context; 
        }
        public bool Adicionar(Cartao CartaoDomain)
        {
            try
            {
                _Datacontext.DbCartoes.Add(CartaoDomain);
                _Datacontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(Cartao CartaoDomain)
        {
            try
            {
                Cartao ret = _Datacontext.DbCartoes.Find(CartaoDomain.Id);
                if (ret != null)
                {
                    ret.Id = CartaoDomain.Id;
                    ret.NumeroCartao = CartaoDomain.NumeroCartao;
                    ret.Bandeira = CartaoDomain.Bandeira;
                    ret.DataVencimento = CartaoDomain.DataVencimento;
                    _Datacontext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
