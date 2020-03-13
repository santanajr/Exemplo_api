using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Entities;
using Payment.Domain.Jwttoken;

namespace Payment.web.Controllers
{
    public class TokenController : ControllerBase
    {
        [HttpPost]
        [Route("logintoken")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario modelusuario)
        {
            var usuarioencontrado = Usuariojwt.Get(modelusuario.Username, modelusuario.Password);

            if (usuarioencontrado == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            var tokengerado = Jwttoken.GenerateToken(modelusuario);
            modelusuario.Password = "";
            return new
            {
                usuario = usuarioencontrado,
                token = tokengerado
            };

        }
    }
}