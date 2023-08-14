using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.DataAccess.Repository
{
    public class BookRepository
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Price { get; set; }
    }
    public class BookRepository2
    {
        public string Barcode { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Price { get; set; }
    }
}
