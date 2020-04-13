using System;

using System.Threading.Tasks;
using Firebase.Database.Query;
using Firebase.Database;

namespace Payment.Infra.FireBase
{
    public class Firebase_infra
    {
        private String url        =  "https://cadastro-9d21c.firebaseio.com/";
        private String secret     =  "QMgtr201vP6OnmZaTEgFXh9Ia7SM5GWoVu6YMQCc";
        private FirebaseClient fb = null;

        public Firebase_infra( )
        {
            //this.url = urldatabase;
            //this.secret = senhasecreta;
            if (this.fb == null)
            {
                this.fb = new FirebaseClient(this.url,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(this.secret)

                    }
                );

            }


        }

        public async Task< FirebaseObject< Dto.Estabelecimento > > Adicionar_Firebase(string url, string senhasecreta, string noprincipal, dynamic obj)
        {
            //var result_sequence = await this.fb.Child("Sequence").Child("Sequence_"+noprincipal).
            //                                               OrderByKey().
            //                                             OnceSingleAsync<Sequence_firebase>();
            //return await this.fb.Child(noprincipal).Child(result_sequence.ToString()).PostAsync(obj);
            if (url != "")
                this.url = url;
            if (senhasecreta != "")
                this.secret = senhasecreta;
            
            if (this.fb == null)
            {
                this.fb = new FirebaseClient(this.url,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(this.secret)

                    }
                );

            }


            return await fb.Child(noprincipal).PostAsync(obj);


            //return await this.fb.Child("Sequence").Child('"'+"Sequence_"+noprincipal+'"').PostAsync()
        }


    }
}
