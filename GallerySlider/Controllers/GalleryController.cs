using BurnSystems.GallerySlider.Model;
using GallerySlider.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GallerySlider.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            var gallery = GalleryProvider.Repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if (gallery == null)
            {
                throw new InvalidOperationException("Gallery not found");
            }

            var galleryModel = new GalleryModel(gallery);

            this.ViewBag.GalleryModel = JsonConvert.SerializeObject(galleryModel);

            return View(galleryModel);
        }

        // GET: api/Gallery
        public JsonResult GetAll()
        {
            return Json(
                GalleryProvider.Repository.GetAll().Select(x => new GalleryModel(x)), 
                JsonRequestBehavior.AllowGet);
        }

        // GET: api/Gallery/5
        public JsonResult Get(int id)
        {
            return Json(
                GalleryProvider.Repository.GetAll().Where(x => x.Id == id).SelectMany(x => x.Images).Select(x => new ImageModel(x)), 
                JsonRequestBehavior.AllowGet);
        }
    }
}