
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkoBot.Models
{
    public class PreviousAction
    {
        [Key]
        public int UserId { get; set; }
        public string PrevAction { get; set; }
    }
}
