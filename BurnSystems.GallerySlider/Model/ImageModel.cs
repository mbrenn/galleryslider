using BurnSystems.GallerySlider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.GallerySlider.Model
{
    public class ImageModel
    {
        public string Name
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public ImageModel()
        {
        }

        public ImageModel(Image image)
        {
            this.Name = image.Name;
            this.ImagePath = image.ImagePath;
        }
    }
}
