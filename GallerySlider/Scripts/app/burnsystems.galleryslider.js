var BurnSystems;
(function (BurnSystems) {
    (function (GallerySlider) {
        var GUI = (function () {
            function GUI() {
            }
            GUI.prototype.showGallery = function () {
                $.ajax("/api/Gallery").then(function (data) {
                    for (var n in data) {
                        var item = data[n];

                        var dom = $("<li></li>").text(item.name);
                        $("#gs_galleries").append(dom);
                    }
                });
            };
            return GUI;
        })();
        GallerySlider.GUI = GUI;
    })(BurnSystems.GallerySlider || (BurnSystems.GallerySlider = {}));
    var GallerySlider = BurnSystems.GallerySlider;
})(BurnSystems || (BurnSystems = {}));
//# sourceMappingURL=burnsystems.galleryslider.js.map
