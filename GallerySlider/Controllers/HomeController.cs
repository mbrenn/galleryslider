using BurnSystems.GallerySlider.Model;
using GallerySlider.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GallerySlider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery(int id)
        {
            var gallery = GalleryProvider.Repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if (gallery == null)
            {
                throw new InvalidOperationException("Gallery not found");
            }

            var galleryModel = new GalleryModel(gallery);

            this.ViewBag.GalleryModel = JsonConvert.SerializeObject(
                galleryModel,
                GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings);

            return View(galleryModel);
        }
    }
}
