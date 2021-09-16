using System;
using System.Collections.Generic;

namespace AppleGallery
{
    public class ImageHandler
    {
        public event EventHandler AssetsLoaded;

        public ImageHandler()
        {
        }

        public List<GalleryItem> CreateGalleryItems()
        {
            return new List<GalleryItem>();
        }
    }
}
