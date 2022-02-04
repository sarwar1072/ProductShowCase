using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.Entities
{
    public class ProductCategory : IEntity<int>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Id { get; set; }
    }
}
