module BurnSystems {
    export module GallerySlider {
        export class GUI {
            showGallery() {
                $.ajax("/api/Gallery")
                    .then(function (data) {
                        for (var n in data) {
                            var item = data[n];

                            var dom = $("<li></li>").text(item.name);
                            $("#gs_galleries").append(dom);
                        }
                    });
            }
        }
    }
}