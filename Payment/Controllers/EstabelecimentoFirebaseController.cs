using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Application.Interface;
using Payment.Infra.FireBase;

namespace Payment.web.Controllers
{
    public class EstabelecimentoFirebaseController : ControllerBase
    {
        private IFirebase_interface _EstabelecimentoFBAppService { get; set; }

        public EstabelecimentoFirebaseController(IFirebase_interface EstabelecimentoFbAppService)
        {
            _EstabelecimentoFBAppService = EstabelecimentoFbAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Dto.Estabelecimento EstabDto)
        {
            string url = "https://cadastro-9d21c.firebaseio.com/";
            string senhasecreta = "QMgtr201vP6OnmZaTEgFXh9Ia7SM5GWoVu6YMQCc";
            var ret = _EstabelecimentoFBAppService.Adicionar_Firebase(url, senhasecreta ,"Estabelecimento", EstabDto);
            return Ok("Adicionar Firebase!");
            //else
              //  return BadRequest();
        }



    }
}