using System;
using prmToolkit.NotificationPattern;
using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Extensions;

namespace VemDeZap.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(string primeiroNome, string ultimoNome, string email, string senha)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 150)
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 150)
                .IfNotEmail(x => x.Email)
                .IfNullOrInvalidLength(x => x.Senha, 3, 32);

            if (!string.IsNullOrEmpty(this.Senha))
            {
                this.Senha = Senha.ConvertToMD5();
            }

            DataCadastro = DateTime.Now;
            Ativo = false;
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public bool Ativo { get; private set; }
    }
}