using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Eums;

namespace VemDeZap.Domain.Entities
{
    public class Grupo : EntityBase
    {
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public EnumNicho Nicho { get; set; }
    }
}