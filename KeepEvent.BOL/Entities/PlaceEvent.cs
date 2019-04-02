using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("PlaceEvent")]
    public class PlaceEvent
    {
        [Key, Column(Order = 1)]
        public int PlaceID { get; set; }
        public Place Place { get; set; }


        [Key, Column(Order = 2)]
        public DateTime DateTime { get; set; }


        [Key, Column(Order = 3)]
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}
