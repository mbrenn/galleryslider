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
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public IEnumerable<ImageModel> images
        {
            get;
            set;
        }

        public GalleryModel(Gallery gallery)
        {
            this.id = gallery.Id;
            this.name = gallery.Name;
            this.description = gallery.Description;
            this.images = gallery.Images.Select(x => new ImageModel(x));
        }
    }
}
