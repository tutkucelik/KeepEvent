using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }


        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }


        [Column(TypeName = "varchar"), StringLength(80), Display(Name = "Kategori İkonu")]
        public string Icon { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int PIndex { get; set; }

        public int? ParentID { get; set; }

        [ForeignKey("ParentID")]
        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
