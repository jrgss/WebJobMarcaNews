using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobMarcaNews.Models
{
    [Table("NEWS")]
    public class Noticia
    {
        [Key]
        [Column("LINK")]
        public string Link { get; set; }
        [Column("TITULAR")]
        public string Titular { get; set; }
   
    }
}
