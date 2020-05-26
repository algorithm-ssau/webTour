using System;
using System.Collections.Generic;
using System.Text;

namespace WebTour.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Sight> Sights { get; set; }
 

        public Category()
        {
            Sights = new List<Sight>();
        }

        public Category(string name)
        {
            Name = name;
            Sights = new List<Sight>();
        } 

        public enum Types
        {
            Музей,
            Храм,
            Театр
        }
    }
}
