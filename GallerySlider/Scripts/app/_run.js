﻿$(function () {
    app.initialize();

    // "Knockout" aktivieren
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);

    var gallery = new BurnSystems.GallerySlider.GUI();
    gallery.showGallery();
});
