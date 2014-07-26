using BurnSystems.GallerySlider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.GallerySlider
{
    public class Repository
    {
        /// <summary>
        /// Stores the galleries
        /// </summary>
        private List<Gallery> galleries = new List<Gallery>();

        public Repository()
        {
        }

        public void Add(Gallery gallery)
        {
            this.galleries.Add(gallery);
        }

        public IEnumerable<Gallery> GetAll()
        {
            return this.galleries;
        }
    }
}
