using System;
using System.Collections.Generic;

namespace BaltaDataAccess.Models{
    public class Carreer {
        public Carreer()
        {
            Items = new List<CarreerItem>();
        }

        public Guid Id { get; set;}
        public string Title { get; set;}
        public IList<CarreerItem> Items { get; set;}
    }
}