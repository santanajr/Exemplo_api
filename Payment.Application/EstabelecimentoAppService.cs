using Payment.Application.Interface;
using Payment.Domain.Interface;
using Payment.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application
{
    public class EstabelecimentoAppService : IEstabelecimentoAppService
    {
        public IEstabelecimentoDomainService _EstabelecimetnoService { get; set; }

        public EstabelecimentoAppService(IEstabelecimentoDomainService EstabelecimetnoService)
        {
            _EstabelecimetnoService = EstabelecimetnoService;
        }

        public bool Adicionar(Estabelecimento estabelecimentoDto)
        {
            return _EstabelecimetnoService.Adicionar(estabelecimentoDto);
        }

        public bool Apagar(Estabelecimento id)
        {
            return _EstabelecimetnoService.Apagar( id );
        }

        public bool Editar(Estabelecimento estabelecimentoDto)
        {
            return  _EstabelecimetnoService.Editar(estabelecimentoDto);
            
        }

        public List<Payment.Dto.Estabelecimento> GetAll()
        {
            return _EstabelecimetnoService.GetAll();
        }

        public List<Estabelecimento> GetAllWithDapper()
        {
            throw new NotImplementedException();
        }

        public Dto.Estabelecimento GetById(Payment.Dto.EstabelecimentoDtoId EstabId)
        {
           return _EstabelecimetnoService.GetById( EstabId );
        }

        public bool Manter(Estabelecimento estabelecimentoDto)
        {
            return _EstabelecimetnoService.Manter(estabelecimentoDto);
        }

        public bool AdicionarFireBase(Estabelecimento estabelecimentoDto)
        {
            _EstabelecimetnoService.AdicionarFirebase(estabelecimentoDto);
            return true;
        }
    }
}
