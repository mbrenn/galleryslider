using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.GallerySlider.Entities
{
    public class Image
    {
        public string Name
        {
            get;
            set                ;
        }

        public string Description
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public Image()
        {
        }

        public Image(string name, string imagePath, string description = "")
        {
            this.Name = name;
            this.ImagePath = imagePath;
            this.Description = description;
        }
    }
}
