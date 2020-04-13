using Firebase.Database;
using Payment.Domain.Interface;
using Payment.Dto;
using Payment.Infra.FireBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Services
{
    public class EstabelecimentoFBDomainService : IEstabelecimentoFBDomainService
    {

        private Estabelecimento _estab { get; set; }
        private Firebase_infra _fireb { get; set; }

        public EstabelecimentoFBDomainService()
        {
            this._fireb = new Firebase_infra();
            this._estab = new Estabelecimento();    
        }


        public Task<FirebaseObject<Dto.Estabelecimento>> Adicionar_Firebase(string url, string senhasecreta, string noprincipal, Dto.Estabelecimento estabelecimento)
        {
            this._estab.IdEstabelecimento = 0;
            this._estab.NomeEstabelecimento = estabelecimento.NomeEstabelecimento;

            return this._fireb.Adicionar_Firebase(url, senhasecreta ,noprincipal, this._estab);


        }

    }
}
