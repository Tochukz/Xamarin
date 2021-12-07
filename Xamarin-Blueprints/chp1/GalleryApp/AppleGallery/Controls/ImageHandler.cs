using System;
using System.Collections.Generic;
using AppleGallery.Models;

namespace AppleGallery.Controls
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
