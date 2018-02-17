using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Lab07_TabControl
{
   [Activity]
    public class TabSample : TabActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //載入頁面
            SetContentView(Resource.Layout.Main);

            //宣告可重覆指定的TabSpec及Intent變數
            TabHost.TabSpec spec;
            Intent intent;

            // 建立Intent, 用來載入新的Activity到Tab控制項
            intent = new Intent(this, typeof(ArtistsActivity));

            //宣告被載入的Activity是一個新的task.
            intent.AddFlags(ActivityFlags.NewTask);

            //新增Tab, 設定Tab的圖片及內容(裝載的Activity), 然後將TabSpec加入到TabHost
            spec = TabHost.NewTabSpec("供應商管理");
            spec.SetIndicator("供應商管理", Resources.GetDrawable(Resource.Drawable.ic_tab_artists));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            // 依照上述的做法, 將AlbumActivity及SongsActivity加入到TabHost
            intent = new Intent(this, typeof(AlbumsActivity));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("料件管理");
            spec.SetIndicator("料件管理", Resources.GetDrawable(Resource.Drawable.ic_tab_artists));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            intent = new Intent(this, typeof(SongsActivity));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("請購管理");
            spec.SetIndicator("請購管理", Resources.GetDrawable(Resource.Drawable.ic_tab_artists));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            intent = new Intent(this, typeof(PurchaseOrderActivity));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("採購管理");
            spec.SetIndicator("採購管理", Resources.GetDrawable(Resource.Drawable.ic_tab_artists));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            //設定目前的Tab
            TabHost.CurrentTab = 2;

        }
    }

    [Activity]
    public class ArtistsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TextView textview = new TextView(this);
            textview.Text = "供應商管理頁面";
            SetContentView(textview);

        }
    }

    [Activity]
    public class AlbumsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TextView textview = new TextView(this);
            textview.Text = "料件管理頁面";
            SetContentView(textview);
        }
    }

    [Activity]
    public class PurchaseOrderActivity : Activity
    {
        string[] items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //TextView textview = new TextView(this);
            //textview.Text = "採購管理頁面";
            SetContentView(Resource.Layout.CallPage);
            //陣列宣告
            items = new string[] { "北區調度員", "中區調度員", "南區調度員" };
            var myAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleExpandableListItem1, items);

            var mylistview = FindViewById<ListView>(Resource.Id.listView1);
            mylistview.Adapter = myAdapter;
            mylistview.ItemClick += listView_ItemClick;

        }
        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Android.Widget.Toast.MakeText(this, items[e.Position].ToString(), Android.Widget.ToastLength.Short).Show();
            Intent callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel://0975023826"));
            StartActivity(callIntent);
        }
    }

    [Activity]
    public class SongsActivity : Activity
    {
        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;
        int previousGroup = -1;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.exmain);
            expListView = FindViewById<ExpandableListView>(Resource.Id.lvExp);

            // Prepare list data
            FnGetListData();
            //Bind list
            listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);

            FnClickEvents();
        }
        void FnClickEvents()
        {
            //Listening to child item selection
            expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e)
            {
                // Toast.MakeText(this, "child clicked", ToastLength.Short).Show();

                StartActivity(typeof(PointList));

            };

            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            expListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e)
            {

                if (e.GroupPosition != previousGroup)
                    expListView.CollapseGroup(previousGroup);
                previousGroup = e.GroupPosition;
            };

            //Listening to group collapse
            expListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e)
            {
                Toast.MakeText(this, "group collapsed", ToastLength.Short).Show();
            };

        }
        void FnGetListData()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();

            // Adding child data
            listDataHeader.Add("執行中");
            listDataHeader.Add("已結案");
            listDataHeader.Add("Mechanical");

            // Adding child data
            var lstCS = new List<string>();
            lstCS.Add("Data structure");
            lstCS.Add("C# Programming");
            lstCS.Add("Java programming");
            lstCS.Add("ADA");
            lstCS.Add("Operation reserach");
            lstCS.Add("OOPS with C");
            lstCS.Add("C++ Programming");

            var lstEC = new List<string>();
            lstEC.Add("Field Theory");
            lstEC.Add("Logic Design");
            lstEC.Add("Analog electronics");
            lstEC.Add("Network analysis");
            lstEC.Add("Micro controller");
            lstEC.Add("Signals and system");

            var lstMech = new List<string>();
            lstMech.Add("Instrumentation technology");
            lstMech.Add("Dynamics of machinnes");
            lstMech.Add("Energy engineering");
            lstMech.Add("Design of machine");
            lstMech.Add("Turbo machine");
            lstMech.Add("Energy conversion");

            // Header, Child data
            listDataChild.Add(listDataHeader[0], lstCS);
            listDataChild.Add(listDataHeader[1], lstEC);
            listDataChild.Add(listDataHeader[2], lstMech);
        }
    }
}

