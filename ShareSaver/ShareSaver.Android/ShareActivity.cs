using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace ShareSaver.Droid
{
    [Activity]
    //[IntentFilter(new[] { Intent.ActionSend }, Categories = new[] { Intent.CategoryDefault }, DataMimeTypes = new[] { "text/plain", })]

    public class ShareActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            HandleIntent();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
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
                    String sharedText = intent.GetStringExtra(Intent.ExtraText);
                    SaveSharedData(sharedText);
                    App.DebugLog(sharedText);
                }
            }
        }

        public void SaveSharedData(string data)
        {
        }
    }
}