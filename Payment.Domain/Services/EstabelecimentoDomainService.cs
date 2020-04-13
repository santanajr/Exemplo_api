using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payment.Domain.Interface;
using Payment.Dto;

//using FireSharp.Config;
//using FireSharp.Interfaces;
//using FireSharp.Response;

using Firebase.Database;
using System.Threading.Tasks;
using Firebase.Database.Query;


namespace Payment.Domain.Services
{
    public class EstabelecimentoDomainService : IEstabelecimentoDomainService
    {
        //https://cadastro-9d21c.firebaseio.com/
        //"QMgtr201vP6OnmZaTEgFXh9Ia7SM5GWoVu6YMQCc"
        //private FirebaseOptions optfb = new FirebaseOptions();
        private const String url = "https://cadastro-9d21c.firebaseio.com/";
        private const String secret = "QMgtr201vP6OnmZaTEgFXh9Ia7SM5GWoVu6YMQCc";
        private FirebaseClient fbcadastro;  

    //    IFirebaseClient clientfb;

        private PaymentDataContext _context { get; set; }
        private Estabelecimento _estab { get; set; }

        private Estabelecimento Alimentar(Dto.Estabelecimento estabelecimentoDto)
        {
            this._estab = new Estabelecimento();
            this._estab.IdEstabelecimento = estabelecimentoDto.IdEstabelecimento;
            this._estab.NomeEstabelecimento = estabelecimentoDto.NomeEstabelecimento;
            return this._estab;
        }

        public bool Manter(Dto.Estabelecimento estabelecimentoDto)
        {
            bool retorno = false;
            try
            {
                if (estabelecimentoDto.IdEstabelecimento == 0)
                {
                    retorno = this.Adicionar(estabelecimentoDto);
                    estabelecimentoDto.IdEstabelecimento = this._estab.IdEstabelecimento;
                }
                else
                {
                    retorno = this.Editar(estabelecimentoDto);
                }


                return retorno;
            }
            catch
            {
                return false;
            }
        }

        public bool AdicionarFirebase(Dto.Estabelecimento estabelecimento)
        {
            try
            {
                this.Alimentar(estabelecimento);
                var a = this.Insert(_estab);

                return true;
            }
            catch {
                return false;
            
            }

                
        }


        public async Task<FirebaseObject<Estabelecimento> > Insert(Estabelecimento estab)
        {
           return await this.fbcadastro.Child("Estabelecimento/").PostAsync(estab);
           
        }





        public EstabelecimentoDomainService(PaymentDataContext context )
        {
            this._context = context;
            this.fbcadastro = new FirebaseClient(url,
                  new FirebaseOptions
                  {
                      AuthTokenAsyncFactory = () => Task.FromResult(secret)

                  }
                ); 
           //clientfb = new FireSharp.FirebaseClient(config);
        }





        public bool Adicionar(Dto.Estabelecimento estabelecimentoDto)
        {
            try
            {
                this.Alimentar(estabelecimentoDto);
                _estab.IdEstabelecimento = 0;   
                this._context.DbEstabelecimentos.Add(_estab);

                this._context.SaveChanges();

                estabelecimentoDto.IdEstabelecimento = this._estab.IdEstabelecimento;

                var a = this.Insert(_estab);

               // SetResponse response = await clientfb.SetAsync("Estabelecimento/"+ 
               //                                                   this._estab.IdEstabelecimento.ToString() , _estab);
               // var resultado = response.ResultAs<Estabelecimento>();
               

                
        
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Apagar(Dto.Estabelecimento estabelecimentoDto)
        {
            try
            {
                this.Alimentar(estabelecimentoDto);

                this._context.DbEstabelecimentos.Remove(this._estab);
                this._context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<Payment.Dto.Estabelecimento> GetAll()
        {
            
            Payment.Dto.Estabelecimento       dtoestab      = new Payment.Dto.Estabelecimento();
            List<Payment.Dto.Estabelecimento> list_dtoestab = new List<Dto.Estabelecimento>();
            var list_estab = this._context.DbEstabelecimentos.ToList();
            
            foreach (Estabelecimento estab in list_estab)
            {
                dtoestab.IdEstabelecimento = estab.IdEstabelecimento;
                dtoestab.NomeEstabelecimento = estab.NomeEstabelecimento;

                list_dtoestab.Add(dtoestab);
            }

            return list_dtoestab;  
        }

        public Dto.Estabelecimento GetById(Payment.Dto.EstabelecimentoDtoId EstabId)
        {
            
            Dto.Estabelecimento dtoestab = new Dto.Estabelecimento();
            Estabelecimento estab = this._context.DbEstabelecimentos.Find(EstabId.IdEstabelecimento);

            
            if (estab != null)
            {
                dtoestab.IdEstabelecimento = estab.IdEstabelecimento;
                dtoestab.NomeEstabelecimento = estab.NomeEstabelecimento;
            }
            
            return dtoestab; 
        }


        public bool Editar(Dto.Estabelecimento estabelecimentoDto)
        {
            try
            {
                this.Alimentar(estabelecimentoDto);
                    
                Estabelecimento e = this._context.DbEstabelecimentos.Find( this._estab.IdEstabelecimento );

                if (e != null)
                {
                    e.NomeEstabelecimento = this._estab.NomeEstabelecimento;
                    this._context.DbEstabelecimentos.Update(e);
                    this._context.SaveChanges();
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
