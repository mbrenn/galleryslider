﻿var BurnSystems;
(function (BurnSystems) {
    (function (GallerySlider) {
        var GUI = (function () {
            function GUI() {
            }
            GUI.prototype.showGalleries = function () {
                var tthis = this;

                $.ajax("/Gallery/GetAll").then(function (data) {
                    for (var n in data) {
                        var item = data[n];

                        (function (i) {
                            var dom = $("<li></li>").append($("<a></a>").text(i.name).attr("href", "/Gallery/Show/" + i.id));

                            /*dom.click(function (e) {
                            tthis.openGallery(item);
                            });*/
                            $("#gs_galleries").append(dom);
                        })(item);
                    }
                });
            };
            return GUI;
        })();
        GallerySlider.GUI = GUI;

        function startGallery(gallery) {
            var g = new Gallery(gallery);
            g.start();
        }
        GallerySlider.startGallery = startGallery;

        var Gallery = (function () {
            function Gallery(gallery) {
                this.gallery = gallery;
            }
            Gallery.prototype.start = function () {
                var tthis = this;
                this.imageDom = $("#galleryimage");
                this.labelDom = $("#gallerylabel");

                $("#gallerynext").click(function (e) {
                    tthis.showNext();
                    return false;
                });

                $("#galleryprev").click(function (e) {
                    tthis.showPrevious();
                    return false;
                });

                // Preload images
                this.preloadedImages = new Array();
                for (var n = 0; n < this.gallery.images.length; n++) {
                    this.preloadedImages[this.preloadedImages.length] = $("<img></img>").attr("src", this.getSourceOfImage(n));
                }

                this.showImage(0);
            };

            Gallery.prototype.showImage = function (nr) {
                this.currentImageNr = nr;
                var image = this.gallery.images[nr];
                if (image === undefined) {
                    throw "Undefined Image";
                }

                this.labelDom.text(image.name);

                /*
                this.imageDom.attr("src", this.getSourceOfImage(nr));*/
                this.imageDom.empty();
                this.imageDom.append(this.preloadedImages[nr]);
            };

            Gallery.prototype.getSourceOfImage = function (nr) {
                var w = Math.floor(window.innerWidth);
                var h = Math.floor(window.innerHeight);

                return "/Gallery/Image/" + this.gallery.id + "?i=" + nr + "&w=" + w + "&h=" + h;
            };

            Gallery.prototype.showNext = function () {
                this.currentImageNr++;
                if (this.currentImageNr >= this.gallery.images.length) {
                    this.currentImageNr = 0;
                }

                this.showImage(this.currentImageNr);
            };

            Gallery.prototype.showPrevious = function () {
                this.currentImageNr--;
                if (this.currentImageNr < 0) {
                    this.currentImageNr = this.gallery.images.length - 1;
                }

                this.showImage(this.currentImageNr);
            };
            return Gallery;
        })();
        GallerySlider.Gallery = Gallery;
    })(BurnSystems.GallerySlider || (BurnSystems.GallerySlider = {}));
    var GallerySlider = BurnSystems.GallerySlider;
})(BurnSystems || (BurnSystems = {}));
//# sourceMappingURL=burnsystems.galleryslider.js.map
