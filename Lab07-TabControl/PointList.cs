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
{ [Activity]
    class PointList:Activity
    {
        private List<data> datas;
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PointList);
            // Get our button from the layout resource,
            // and attach an event to it

            listView = FindViewById<ListView>(Resource.Id.listView2);
            //載入假資料
            datas = new List<data>();
            datas.Add(new data
            {
                Title = "任務編號:A345",
                detail = "任務名稱:XXXXXXXXX",
                Image = Resource.Drawable.Icon
            });
            datas.Add(new data
            {
                Title = "豬哥亮",
                detail = "0911******",
                Image = Resource.Drawable.a1
            });
            datas.Add(new data
            {
                Title = "林志玲",
                detail = "0912******",
                Image = Resource.Drawable.a2
            });
            listView.Adapter = new CustomListAdapter(this, datas);

            listView.ItemClick += listView_Click;

           
        }
        void listView_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}