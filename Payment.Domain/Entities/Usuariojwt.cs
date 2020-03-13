using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payment.Domain.Jwttoken;

namespace Payment.Domain.Entities
{
    public static class Usuariojwt
    {
        public static Usuario Get(string nome, string password)//essa parte deve acessar o banco de dados
        {
            var user = new List<Usuario>();
            user.Add(new Usuario { Id = 1, Username = "Batman", Password = "batman", role = "gerente" });
            user.Add(new Usuario { Id = 2, Username = "Robin",  Password = "robin", role = "funcionario" });
            return user.Where(x =>
                                x.Username.ToLower() == nome.ToLower() &&
                                x.Password.ToLower() == password.ToLower()
                             ).FirstOrDefault();
        }

    }
}
