using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Interface
{
    public interface IEstabelecimentoFirebaseAppService
    {
        // bool Adicionar_Firebase(string noprincipal, Payment.Dto.Estabelecimento EstabDto);
        public Task<FirebaseObject<Dto.Estabelecimento>> Adicionar_Firebase(
             string url, string senhasecreta, string noprincipal, Dto.Estabelecimento estabelecimento);

    }
}
