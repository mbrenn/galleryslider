using BurnSystems.GallerySlider;
using BurnSystems.GallerySlider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GallerySlider.Providers
{
    public static class GalleryProvider
    {
        public static Repository Repository
        {
            get;
            set;
        }

        public static void Init()
        {
            Repository = new Repository();
            var galleryColor = new Gallery(1, "Farben", "Ein paar Farben",
                new Image[]{
                    new Image ("Rot", "images/g/colors/red.png" ),
                    new Image ("Blau", "images/g/colors/blue.png" ),
                    new Image ("Grün", "images/g/colors/green.png" ),
                    new Image ("Gelb", "images/g/colors/yellow.png" ),
                    new Image ("Grün", "images/g/colors/green.png" )
                });
            var galleryShapes = new Gallery(2, "Formen", "Wir zeigen Rechtecke, Kreise, Rauten und Vielecke",
                new Image[]{
                    new Image ("Kreis", "images/g/shapes/kreis.png" ),
                    new Image ("Rechteck", "images/g/shapes/rechteck.png" ),
                    new Image ("Quadrat", "images/g/shapes/quadrat.png" ),
                    new Image ("Dreieck", "images/g/shapes/dreieck.png" ),
                    new Image ("Raute", "images/g/shapes/raute.png" ),
                    new Image ("Raute", "images/g/shapes/hexagon.png" ),
                    new Image ("Raute", "images/g/shapes/octagon.png" ),
                    new Image ("Parallelogramm", "images/g/shapes/parallelogramm.png" )
                });

            Repository.Add(galleryColor);
            Repository.Add(galleryShapes);
        }
    }
}