using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("Header")]
    public class Header
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Site Logosu")]
        public string Logo { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Baş Resim")]
        public string Picture { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Üst Başlık")]
        public string Title { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Alt Başlık")]
        public string SubTitle { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
