using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab07_TabControl
{
    class CustomListAdapter : BaseAdapter<data>
    {
        List<data> items;
        Activity context;

        //建構子,傳入Activity物件以與資料集合
        public CustomListAdapter(Activity context, List<data> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override data this[int position]
        {
            get { return items[position]; }
        }


        public override int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// 系統會呼叫 並且render.
        /// </summary>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;

            if (view == null)
            {
                //使用自訂的Customlayout
                view = context.LayoutInflater.Inflate(Resource.Layout.Customlayout, null);
            }
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.detail;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.Image);
            return view;
        }
    }
}