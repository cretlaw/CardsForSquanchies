using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardsForSquanchies.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FrontText { get; set; }

        [Required]
        [StringLength(255)]
        public string BackText { get; set; }

        [StringLength(255)]
        public string CardCommand { get; set; }
    }
}