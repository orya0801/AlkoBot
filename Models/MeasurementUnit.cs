using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkoBot.Models
{
    public class MeasurementUnit
    {
        [Key]
        public int UnitId { get; set; }
        public string Name { get; set; }
        public double Coefficient { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
