using Entities.Enums;

namespace WebAPIs.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public Local Local { get; set; }
        public Sala Sala { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Responsavel { get; set; }
        public bool Cafe { get; set; }
        public int QtdPessoasCafe { get; set; }
        public string Descricao { get; set; }
    }
}
