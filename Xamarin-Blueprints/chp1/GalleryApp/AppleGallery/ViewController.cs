using Foundation;
using System;
using UIKit;
using CoreGraphics;
using AppleGallery.DataSources;

namespace AppleGallery
{

    public partial class ViewController : UIViewController
    {
        private UITableView tableView;

        private TableSource tableSource;

        private ImageHandler imageHandler;

        public ViewController(IntPtr handle) : base(handle)
        { 
            tableSource = new TableSource();
            imageHandler = new ImageHandler();
            imageHandler.AssetsLoaded += handleAssetsLoaded;

        }

        private void handleAssetsLoaded(object sender, EventArgs e)
        {
            tableSource.UpdateGalleryItems(imageHandler.CreateGalleryItems());
            tableView.ReloadData();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var width = View.Bounds.Width;
            var height = View.Bounds.Height;

            tableView = new UITableView(new CGRect(0, 0, width, height));
            tableView.AutoresizingMask = UIViewAutoresizing.All;
            tableView.Source = tableSource;

            Add(tableView);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
