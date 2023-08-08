using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract17.Database
{
    public class Участники
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Column(TypeName ="nvarchar")]
        public string? ФИО { get; set; }

        [StringLength(150)]
        [Column(TypeName = "nvarchar")]
        public string? Город { get; set; }

        [StringLength(150)]
        [Column(TypeName = "nvarchar")]
        public string? Фамилия_тренера { get; set; }

        public int? Оценка { get; set; }

    }
}
