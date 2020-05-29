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

        public string Category { get; set; }

        public string Description { get; set; }

        public int FoundingDate { get; set; }

        public string Address { get; set; }

        public int LikeCount { get; set; }

        public string MainImageURI { get; set; }

        public List<string> ImageURIs { get; set; }


        public SightDTO()
        {
            ImageURIs = new List<string>();
        }


        public static SightDTO Map(Sight entity)
        {
            var dto = new SightDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Category = entity.Category.Name,
                Description = entity.Description,
                FoundingDate = entity.FoundingDate.Year,
                Address = entity.Address,
                LikeCount = entity.LikeCount,
                MainImageURI = entity.MainImageURI
            };
            foreach(var image in entity.Images)
            {
                dto.ImageURIs.Add(image.Path);
            }
            return dto;
        }
    }
}
