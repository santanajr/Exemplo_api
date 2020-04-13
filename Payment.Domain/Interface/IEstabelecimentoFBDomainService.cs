using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Interface
{
    public interface IEstabelecimentoFBDomainService
    {
        //bool Adicionar_Firebase(string noprincipal , Dto.Estabelecimento estabelecimento);

        public Task<FirebaseObject<Dto.Estabelecimento>> Adicionar_Firebase(string url, string senhasecreta,  string noprincipal, Dto.Estabelecimento estabelecimento);


    }
}
