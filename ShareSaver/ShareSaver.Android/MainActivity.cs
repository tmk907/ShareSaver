using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using Plugin.CurrentActivity;

namespace ShareSaver.Droid
{
    [Activity(Label = "ShareSaver", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionSend }, Categories = new[] { Intent.CategoryDefault }, DataMimeTypes = new[] { "text/plain", })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            HandleIntent();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void HandleIntent()
        {
            App.DebugLog("");
            Intent intent = Intent;
            var shareAction = intent.Action;
            var type = intent.Type;
            App.DebugLog($"{intent.Action} {intent.Type}");

            if (Intent.ActionSend.Equals(shareAction))
            {
                App.DebugLog("shareAction");

                if (type.Contains("text/plain"))
                {
                    var sharedText = intent.GetStringExtra(Intent.ExtraText);
                    App.SaveSharedData(sharedText);
                    App.DebugLog(sharedText);
                }
            }
        }
    }
}