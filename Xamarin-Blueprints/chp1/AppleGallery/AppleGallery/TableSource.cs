using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace AppleGallery
{
    public class TableSource: UITableViewSource
    {
        protected List<GalleryItem> galleryItems;

        protected string cellIdentifier = "GalleryCell";

        public TableSource()
        {
            galleryItems = new List<GalleryItem>();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return galleryItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (GalleryCell)tableView.DequeueReusableCell(cellIdentifier);
            var galleryItem = galleryItems[indexPath.Row];
            if (cell == null)
            {
                cell = new GalleryCell(cellIdentifier);
            }
            cell.UpdateCell(galleryItem);
            return cell;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            //return base.NumberOfSections(tableView);
            return 1;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            //return base.GetHeightForRow(tableView, indexPath);
            return 100;
        }

        public void UpdateGalleryItems(List<GalleryItem> galleryItems)
        {
            
        }
    } 
}
