module BurnSystems {
    export module GallerySlider {
        export interface GalleryModel {
            id: string;
            name: string;
            description: string;
            images: Array<ImageModel>;
        }

        export interface ImageModel {
            name: string;
            description: string;
            imagePath: string;
        }

        export class GUI {
            showGalleries() {
                var tthis = this;

                $.ajax("/Gallery/GetAll")
                    .then(function (data) {
                        for (var n in data) {
                            var item = data[n];

                            (function (i) {

                                var dom = $("<li></li>")
                                    .append($("<a></a>")
                                        .append($("<span></span>")
                                            .text(i.name))
                                        .attr("href", "/Gallery/Show/" + i.id)
                                        .prepend($("<img></img>")
                                            .attr("src", "/Gallery/Image/" + i.id + "?i=2&h=50&w=50"))
                                        .prepend($("<img></img>")
                                            .attr("src", "/Gallery/Image/" + i.id + "?i=1&h=50&w=50")));

                                $("#gs_galleries").append(dom);
                            })(item);
                        }
                    });
            }
        }

        export function startGallery(gallery : GalleryModel) {
            var g = new Gallery(gallery);
            g.start();
        }

        export class Gallery {
            gallery: GalleryModel;
            imageDom: JQuery;
            labelDom: JQuery;
            descriptionDom: JQuery;
            currentImageNr: number;

            preloadedImages: Array<JQuery>;

            constructor(gallery: GalleryModel) {
                this.gallery = gallery;
            }

            start() {
                var tthis = this;
                this.imageDom = $("#galleryimage");
                this.labelDom = $("#gallerylabel");
                this.descriptionDom = $("#gallerydescription");

                $("#galleryoverview").click(function (e) {
                    document.location.href = "/";
                    return false;
                });

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
                    this.preloadedImages[this.preloadedImages.length] =
                        $("<img></img>").attr("src", this.getSourceOfImage(n));
                }

                this.showImage(0);
            }

            showImage(nr: number) {
                this.currentImageNr = nr;
                var image = this.gallery.images[nr];
                if (image === undefined) {
                    throw "Undefined Image";
                }

                this.labelDom.text(image.name);
                this.descriptionDom.text(image.description);

                /*
                this.imageDom.attr("src", this.getSourceOfImage(nr));*/
                this.imageDom.empty();
                this.imageDom.append(this.preloadedImages[nr]);
            }

            getSourceOfImage(nr): string {
                var w = Math.floor(window.innerWidth);
                var h = Math.floor(window.innerHeight);

                return "/Gallery/Image/" + this.gallery.id + "?i=" + nr + "&w=" + w + "&h=" + h;
            }

            showNext() {
                this.currentImageNr++;
                if (this.currentImageNr >= this.gallery.images.length) {
                    this.currentImageNr = 0;
                }

                this.showImage(this.currentImageNr);
            }

            showPrevious() {
                this.currentImageNr--;
                if (this.currentImageNr < 0) {
                    this.currentImageNr = this.gallery.images.length - 1;
                }

                this.showImage(this.currentImageNr);
            }
        }
    }
}