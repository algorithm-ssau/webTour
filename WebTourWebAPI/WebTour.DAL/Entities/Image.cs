using System.ComponentModel.DataAnnotations.Schema;

namespace WebTour.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        
        public int SightId { get; set; }

        public string Path { get; set; }

        //public string ImageURI { get; set; }


        public Sight Sight { get; set; }


        public Image(int sightId, string path)
        {
            SightId = sightId;
            Path = path;
        }

        public Image()
        { }
    }
}
