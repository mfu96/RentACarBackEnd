﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard: IEntity
    {
        [Key]
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public int CVV  { get; set; }
        public string ExpirationDate { get; set; }
    }
}
