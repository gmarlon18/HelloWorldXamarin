using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using static Android.Resource;
using System.Collections.Generic;

namespace HelloWorldAndroid
{
    [Activity(Label = "HelloWorldAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        protected override void OnCreate(Bundle bundle)
        {


            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            AppCenter.Start("0ad2cb10-59eb-4a70-b476-2942a83d520c", typeof(Analytics), typeof(Crashes));
            AppCenter.LogLevel = LogLevel.Verbose;

            //bool isEnabled = await Analytics.IsEnabledAsync();


            TextView textV1 = FindViewById<TextView>(Resource.Id.textView2);
            Button button1 = FindViewById<Button>(Resource.Id.button1);

            /*if (isEnabled)
            {
                textV1.Text = "Habilitado";
            }
            else
            {
                textV1.Text = "Deshabilitado";
            }*/

            //button1.Click += Button1_Click;
            button1.Click += delegate {
                button1.Text = string.Format("{0} Clicks !", count++);
                Analytics.TrackEvent("clicked");

            };

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "Holi";
        }


    }
}

