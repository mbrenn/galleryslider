using BurnSystems.GallerySlider.Model;
using GallerySlider.Providers;
using ImageResizer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Returns the image at the given location
        /// </summary>
        /// <param name="id">Id of the gallery</param>
        /// <param name="i">Id of the image</param>
        /// <param name="w">Width of the image</param>
        /// <param name="h">Height of the image</param>
        /// <returns>Created result</returns>
        public ActionResult Image(int id, int i, int w, int h)
        {
            w = Math.Min(2000, w);
            h = Math.Min(2000, h);

            var gallery = GalleryProvider.Repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if (gallery == null)
            {
                throw new InvalidOperationException();
            }

            if (i >= gallery.Images.Count() || i < 0)
            {
                throw new InvalidOperationException();
            }

            var imagePath = gallery.Images.ElementAt(i).ImagePath;
            var absolutePath = Path.Combine(this.Request.PhysicalApplicationPath, imagePath);
            if ( !System.IO.File.Exists(absolutePath))
            {
                throw new InvalidOperationException();
            }

            var extension = Path.GetExtension(absolutePath).ToLower();

            // Check for existing file in images
            ResizeSettings resizeSettings;
            using (var memory = new MemoryStream())
            {
                switch (extension)
                {
                    case ".jpg":
                        resizeSettings = new ResizeSettings(w, h, FitMode.Pad, "jpg");
                        resizeSettings.BackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        resizeSettings.Scale = ScaleMode.Both;
                        ImageBuilder.Current.Build(absolutePath, memory, resizeSettings);
                        return File(memory.GetBuffer(), "image/jpeg");
                    case ".png":
                        resizeSettings = new ResizeSettings(w, h, FitMode.Pad, "png");
                        resizeSettings.BackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        resizeSettings.Scale = ScaleMode.Both;
                        ImageBuilder.Current.Build(absolutePath, memory, resizeSettings);
                        return File(memory.GetBuffer(), "image/png");
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
}