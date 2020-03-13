using System;
using System.Collections.Generic;
using System.Text;
using Payment.Dto;


namespace Payment.Application.Interface
{
    public interface IEstabelecimentoAppService 
    {
        public bool Adicionar(Payment.Dto.Estabelecimento  estabelecimentoDto );

        public bool Editar(Payment.Dto.Estabelecimento estabelecimentoDto);
        public bool Manter(Payment.Dto.Estabelecimento estabelecimentoDto);

        public bool Apagar(Payment.Dto.Estabelecimento estabelecimentoDto);
        public List<Payment.Dto.Estabelecimento> GetAll();
        public Payment.Dto.Estabelecimento GetById(Payment.Dto.EstabelecimentoDtoId EstabId);
        public List<Payment.Dto.Estabelecimento> GetAllWithDapper(); 
    }
}
