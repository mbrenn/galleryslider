using BurnSystems.GallerySlider.Entities;
using BurnSystems.GallerySlider.Model;
using GallerySlider.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GallerySlider.Controllers
{
    public class GalleryController : ApiController
    {
        // GET: api/Gallery
        public IEnumerable<GalleryModel> Get()
        {
            return GalleryProvider.Repository.GetAll().Select(x => new GalleryModel(x));
        }

        // GET: api/Gallery/5
        public IEnumerable<ImageModel> Get(int id)
        {
            return GalleryProvider.Repository.GetAll().Where(x => x.Id == id).SelectMany(x=>x.Images).Select(x => new ImageModel(x));
        }

        /*
        // POST: api/Gallery
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Gallery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gallery/5
        public void Delete(int id)
        {
        }*/
    }
}
