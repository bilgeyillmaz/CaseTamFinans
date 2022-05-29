using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Book:IEntity
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public string WriterFullName { get; set; }
        public string PublishingHouse { get; set; }
        public int NumberOfPages { get; set; }
        public bool Status { get; set; }

    }
}
