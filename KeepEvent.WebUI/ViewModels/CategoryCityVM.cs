using KeepEvent.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepEvent.WebUI.ViewModels
{
    public class CategoryCityVM
    {
        public ICollection<City> Cities { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<PlaceEvent> PlaceEvents { get; set; }
        public ICollection<Header> Headers { get; set; }
    }
}