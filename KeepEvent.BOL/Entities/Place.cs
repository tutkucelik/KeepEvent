using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("Place")]
    public class Place
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar"), StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "varchar"), StringLength(150)]
        public string Picture { get; set; }

        [Column(TypeName = "varchar"), StringLength(150)]
        public string Address { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }

        public ICollection<PlaceEvent> PlaceEvent { get; set; }
    }
}
