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
                    new Image ("Rot", "images/g/colors/red.png"),
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
                    new Image ("Sechseck", "images/g/shapes/hexagon.png", "Auch Hexagon" ),
                    new Image ("Achteck", "images/g/shapes/octagon.png", "Auch Oktagon" ),
                    new Image ("Parallelogramm", "images/g/shapes/parallelogramm.png" )
                });

            var galleryPets = new Gallery(3, "Haustiere", "Bilder aus Wikipedia",
                new Image[] {
                    new Image ( "Schwein", "images/g/pets/pig.jpg", 
                        "http://commons.wikimedia.org/wiki/File:Sow_with_piglet.jpg" ),
                        
                    new Image ( "Kuh", "images/g/pets/cow.jpg", 
                        "http://commons.wikimedia.org/wiki/Domesticated_animals?uselang=de#mediaviewer/File:Koe_in_weiland_bij_Gorssel.JPG" ),
                        
                    new Image ( "Esel", "images/g/pets/donkey.jpg", 
                        "http://commons.wikimedia.org/wiki/Domesticated_animals?uselang=de#mediaviewer/File:Osiol001xx.jpg" ),
                        
                    new Image ( "Katze", "images/g/pets/cat.jpg", 
                        "http://de.wikipedia.org/wiki/Katze#mediaviewer/Datei:Gr%C3%BCne_Augen_einer_Katze.JPG" ),
                        
                    new Image ( "Schaf", "images/g/pets/sheep.jpg", 
                        "http://de.wikipedia.org/wiki/Hausschaf#mediaviewer/Datei:SchafSeite.JPG" ),
                        
                    new Image ( "Ziege", "images/g/pets/goat.jpg", 
                        "http://de.wikipedia.org/wiki/Hausziege#mediaviewer/Datei:Hausziege_04.jpg" ),
                        
                    new Image ( "Hund", "images/g/pets/dog.jpg", 
                        "http://de.wikipedia.org/wiki/Hund#mediaviewer/Datei:Sennenhund.jpg" )                        
                });

            Repository.Add(galleryColor);
            Repository.Add(galleryShapes);
            Repository.Add(galleryPets);
        }
    }
}