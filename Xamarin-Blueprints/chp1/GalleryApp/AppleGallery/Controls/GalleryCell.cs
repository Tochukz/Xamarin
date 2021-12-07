using System;
using UIKit;
using Foundation;
using SharedGallery.Models;
using AppleGallery.Models;

namespace AppleGallery.Controls
{
    public class GalleryCell : UITableViewCell
    {
        private UIImageView imageView;

        private UILabel titleLabel;

        private UILabel dateLabel;

        public GalleryCell(string cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            imageView = new UIImageView()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            titleLabel = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            dateLabel = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };

            ContentView.Add(imageView);
            ContentView.Add(titleLabel);
            ContentView.Add(dateLabel);
        }

        public void UpdateCell(GalleryItem gallery)
        {
            imageView.Image = UIImage.LoadFromData(NSData.FromArray(gallery.ImageData));
            titleLabel.Text = gallery.Title;
            dateLabel.Text = gallery.Date;
        }

        // This method is equivalent to the ViewDidLoad methods of a UIViewController
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            ContentView.TranslatesAutoresizingMaskIntoConstraints = false;
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[imageView(100)]|", NSLayoutFormatOptions.DirectionLeftToRight, null, new NSDictionary("imageView", imageView)));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[titleLabel]|", NSLayoutFormatOptions.DirectionLeftToRight, null, new NSDictionary("titleLabel", titleLabel)));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-10-[imageView(100]-10-[titleLabel]-10-|", NSLayoutFormatOptions.AlignAllTop, null, new NSDictionary("imageView", imageView, "titleLabel", titleLabel)));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-10-[imageView(100)-10-[dateLabel]-10-|", NSLayoutFormatOptions.AlignAllTop, null, new NSDictionary("imageView", imageView, "dateLabel", dateLabel)));
        }
    }
}
