using Firebase.Database;
using Payment.Dto;
using System.Threading.Tasks;

namespace Payment.Infra.FireBase
{
    public class FireBaseClass : IFirebase_interface
    {

        private Estabelecimento _estab { get; set; }
        private Firebase_infra _fireb { get; set; }

        public FireBaseClass(string url, string senha)
        {
            this._fireb = new Firebase_infra( );
            this._estab = new Estabelecimento();
        }



        Task<FirebaseObject<Estabelecimento>> IFirebase_interface.Adicionar_Firebase(string url, string senhasecreta, string noprincipal, Estabelecimento estabelecimento)
        {
            this._estab.IdEstabelecimento = 0;
            this._estab.NomeEstabelecimento = estabelecimento.NomeEstabelecimento;

            return this._fireb.Adicionar_Firebase(url, senhasecreta, noprincipal, this._estab);
        }
    }
}
