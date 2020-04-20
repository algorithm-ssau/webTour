using System;
using System.Collections.Generic;
using System.Text;
using WebTour.DAL.Entities;

namespace WebTour.BLL.DTO
{
    public class SightDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime FoundingDate { get; set; }

        public string Address { get; set; }

        public int LikeCount { get; set; }

        public string MainImageURI { get; set; }

        public List<string> ImageURIs { get; set; }


        public static SightDTO Map(Sight entity) => new SightDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            FoundingDate = entity.FoundingDate,
            Address = entity.Address,
            LikeCount = entity.LikeCount,
            MainImageURI = entity.MainImageURI
        };
    }
}
