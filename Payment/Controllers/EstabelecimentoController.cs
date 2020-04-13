using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Interface;
using Payment.Domain.Jwttoken;

namespace Payment.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private IEstabelecimentoAppService EstabelecimentoAppService { get; set; }

        public EstabelecimentoController(IEstabelecimentoAppService _EstabelecimentoAppService)
        {
            EstabelecimentoAppService = _EstabelecimentoAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Dto.Estabelecimento EstabDto)
        {
            if (EstabelecimentoAppService.Adicionar(EstabDto))
                return Ok(EstabDto);
            else
                return BadRequest();
        }

        [HttpPost("AdicionarFirebase")]
        public IActionResult AdicionarFirebase([FromBody] Dto.Estabelecimento EstabDto)
        {
            if (EstabelecimentoAppService.AdicionarFireBase(EstabDto))
                return Ok(EstabDto);
            else
                return BadRequest();
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Payment.Dto.Estabelecimento EstabDto)
        {
            if (EstabelecimentoAppService.Editar(EstabDto))
                return Ok(EstabDto);
            else
                return BadRequest();
        }



       /* [HttpPost]
        public IActionResult Manter([FromBody] Payment.Dto.Estabelecimento EstabDto)
        {
            if (EstabelecimentoAppService.Manter(EstabDto))
                return Ok(EstabDto);
            else
                return BadRequest();
        }
        */

        [HttpDelete]
        public IActionResult Delete([FromBody] Payment.Dto.Estabelecimento EstabDtoId )
        {
            if (EstabelecimentoAppService.Apagar(EstabDtoId) )
                return Ok("Sucesso - Exclusão Estabelecimento");
            else
                return BadRequest("Problema - Exclusão Estabelecimento");
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll( )
        {
            var all =  EstabelecimentoAppService.GetAll();
            return Ok( all );
        }

        [HttpGet("getbyid")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetById([FromQuery] Payment.Dto.EstabelecimentoDtoId EstabDtoId)
        {
            var all = EstabelecimentoAppService.GetById(EstabDtoId);
            return Ok(all);
        }


    }
}