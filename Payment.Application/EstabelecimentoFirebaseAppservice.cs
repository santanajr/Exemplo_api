using Payment.Application.Interface;
using Payment.Dto;
using Payment.Infra.FireBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application
{
    public class EstabelecimentoFirebaseAppservice : IEstabelecimentoFirebaseAppService
    {

        public IFirebase_interface _EstabelecimentoFBService { get; set; }

        public EstabelecimentoFirebaseAppservice(IFirebase_interface EstabelecimentoFBService )
        {
            _EstabelecimentoFBService = EstabelecimentoFBService;
        }

        public Task<Firebase.Database.FirebaseObject<Dto.Estabelecimento>> Adicionar_Firebase(string url, string senhasecreta, string noprincipal, Estabelecimento estabelecimento)
        {
            
            return _EstabelecimentoFBService.Adicionar_Firebase(url, senhasecreta ,"Estabelecimento", estabelecimento);
            
        }
    }
}
