declare module BurnSystems {
    module GallerySlider {
        interface GalleryModel {
            id: string;
            name: string;
            description: string;
            images: ImageModel[];
        }
        interface ImageModel {
            name: string;
            imagePath: string;
        }
        class GUI {
            public showGalleries(): void;
        }
        function startGallery(gallery: GalleryModel): void;
        class Gallery {
            public gallery: GalleryModel;
            public imageDom: JQuery;
            public labelDom: JQuery;
            public currentImageNr: number;
            constructor(gallery: GalleryModel);
            public start(): void;
            public showImage(nr: number): void;
            public showNext(): void;
            public showPrevious(): void;
        }
    }
}
