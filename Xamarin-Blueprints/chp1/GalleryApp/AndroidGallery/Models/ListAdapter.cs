using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.App;
using SharedGallery.Models;

namespace AndroidGallery.Models
{
    public class ListAdapter: BaseAdapter
    {
        private List<GalleryItem> items;

        private Activity context;

        public ListAdapter(Activity cxt) : base()
        {
            context = cxt;
            items = new List<GalleryItem>();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an exiting view, if one is available
            if  (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomCell, null);
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }
    }
}
