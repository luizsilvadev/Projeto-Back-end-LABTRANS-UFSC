using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Entities
{
    [Table("TB_BOOKING")]
    public class Booking : Notifies
    {
        [Column("BOK_ID")]
        public int Id { get; set; }

        [Column("BOK_LOCAL")]
        public Local Local { get; set; }

        [Column("BOK_SALA")]
        public Sala Sala { get; set; }

        [Column("BOK_DATA_HORA_INICIO")]
        public DateTime DataHoraInicio { get; set; }

        [Column("BOK_DATA_HORA_FIM")]
        public DateTime DataHoraFim { get; set; }

        [Column("BOK_RESPONSAVEL")]
        [MaxLength(255)]
        public string Responsavel { get; set; }

        [Column("BOK_CAFE")]
        public bool Cafe { get; set; }

        [Column("BOK_QTD_PESSOAS_CAFE")]
        public int QtdPessoasCafe { get; set; }

        [Column("BOK_DESCRICAO")]
        [MaxLength(255)]
        public string Descricao { get; set; }
    }
}
