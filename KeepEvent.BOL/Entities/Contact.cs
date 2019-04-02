using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("Contact")]
    public class Contact
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "varchar"), Required(ErrorMessage = "Ad soyad boş geçilemez"), Display(Name = "Adınız Soyadınız")]
        public string Name { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Mail Adresiniz")]
        public string Email { get; set; }

        [StringLength(60), Column(TypeName = "varchar"), Display(Name = "Mesajınız")]
        public string Subject { get; set; }

        [StringLength(600), Column(TypeName = "varchar"), Required(ErrorMessage = "Mesaj boş geçilemez"), Display(Name = "Mesajınız")]
        public string Message { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Kayıt Tarihi")]
        public DateTime PostDate { get; set; }

    }
}
