using Payment.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Interface
{
    public interface IEstabelecimentoDomainService
    {
        public bool Adicionar(Dto.Estabelecimento estabelecimento);
        public bool Editar(Dto.Estabelecimento estabelecimento);
        public bool Manter(Dto.Estabelecimento estabelecimento);
        public bool Apagar(Dto.Estabelecimento estabelecimento);
        public List<Dto.Estabelecimento> GetAll();

        public Dto.Estabelecimento GetById(Payment.Dto.EstabelecimentoDtoId EstabId );
    }
}
