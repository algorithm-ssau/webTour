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

        [Column(TypeName = "varchar(max)")]
        public string MainImageURI { get; set; }

        public List<Image> Images { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public Sight()
        {
            Images = new List<Image>();
        }

        public Sight(int categoryId, string name, string description, DateTime date, string address, string  mainImageURI)
        {
            Name = name;
            Description = description;
            FoundingDate = date;
            Address = address;
            CategoryId = categoryId;
            MainImageURI = mainImageURI;
            Images = new List<Image>();
        }

        public Sight(int id, int categoryId, string name, string description, DateTime date, string address, string mainImageURI)
        {
            Id = id;
            Name = name;
            Description = description;
            FoundingDate = date;
            Address = address;
            CategoryId = categoryId;
            MainImageURI = mainImageURI;
            Images = new List<Image>();
        }
    }
}
