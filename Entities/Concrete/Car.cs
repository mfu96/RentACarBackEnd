using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
       

    }
}
