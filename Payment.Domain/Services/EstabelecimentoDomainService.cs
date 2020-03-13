using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payment.Domain.Interface;
using Payment.Dto;

namespace Payment.Domain.Services
{
    public class EstabelecimentoDomainService : IEstabelecimentoDomainService
    {
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


        public EstabelecimentoDomainService(PaymentDataContext context )
        {
            this._context = context;
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
