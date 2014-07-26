using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.GallerySlider.Entities
{
    public class Gallery
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public IEnumerable<Image> Images
        {
            get;
            set;
        }

        public Gallery()
        {
        }

        public Gallery(int id, string name, string description, IEnumerable<Image> images)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Images = images;
        }
    }
}
