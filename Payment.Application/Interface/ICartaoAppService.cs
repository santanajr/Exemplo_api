using Payment.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application.Interface
{
    public interface ICartaoAppService
    {
        public bool Adicionar(CartaoDto cartaoDto );
        public bool Editar(CartaoDto cartaoDto);

        public bool Delete(int indice);

        public List<CartaoDto> GetAll();

        public List<CartaoDto> GetById(int indice);

    }
}
