using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Eums;

namespace VemDeZap.Domain.Entities
{
    public class Contato : EntityBase
    {
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnumNicho Nicho { get; set; }
    }
}