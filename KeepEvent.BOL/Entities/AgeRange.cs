﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.BOL.Entities
{
    [Table("AgeRange")]
    public class AgeRange
    {
        public int ID { get; set; }


        [Column(TypeName = "varchar"), StringLength(50)]
        public string Name { get; set; }

        public ICollection<Event> Event { get; set; }

    }
}
