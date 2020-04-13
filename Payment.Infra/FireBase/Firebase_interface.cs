using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Payment.Infra.FireBase
{
    public interface IFirebase_interface
    {


        // bool Adicionar_Firebase(string url, string senhasecreta ,string noprincipal, Payment.Dto.Estabelecimento EstabDto );
        Task<FirebaseObject<Dto.Estabelecimento>> Adicionar_Firebase(string url, string senhasecreta, string noprincipal, Dto.Estabelecimento estabelecimento);


    }
}
