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
    [Activity(Label = "固定資產APP", MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstActivity:Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //載入頁面
            SetContentView(Resource.Layout.Login);

            Button button = FindViewById<Button>(Resource.Id.btnLogin);

            button.Click += delegate { StartActivity(typeof(TabSample)); };

        }
    }
}