using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("Event")]
    public class Event
    {
        public int ID { get; set; }


        [Column(TypeName ="varchar"),StringLength(100)]
        public string Name { get; set; }


        [Column(TypeName = "varchar"), StringLength(1000)]
        public string Description { get; set; }



        [Column(TypeName = "varchar"), StringLength(150)]
        public string Picture { get; set; }


        public decimal Price { get; set; }


        [Column(TypeName = "varchar"), StringLength(100)]
        public string EventLink { get; set; }


        [Column(TypeName = "varchar"), StringLength(100)]
        public string TicketLink { get; set; }

        public int AgeRangeID { get; set; }
        public AgeRange AgeRange { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }


        public ICollection<PlaceEvent> PlaceEvent { get; set; }

       
       
    }
}
