using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTour.DAL.Entities
{
    public class Sight
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime FoundingDate { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        public int LikeCount { get; set; }

        public string MainImageURI { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
