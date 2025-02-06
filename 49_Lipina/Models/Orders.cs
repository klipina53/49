using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _49_Lipina.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }
    }
}
