using BurnSystems.GallerySlider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.GallerySlider.Model
{
    public class GalleryModel
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

        public GalleryModel(Gallery gallery)
        {
            this.Id = gallery.Id;
            this.Name = gallery.Name;
            this.Description = gallery.Description;
            this.Images = gallery.Images;
        }
    }
}
