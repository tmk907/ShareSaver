using Android.Content;
using Plugin.CurrentActivity;
using ShareSaver;
using Xamarin.Forms;
using YouTubeDownloader.Droid.Services;

[assembly: Dependency(typeof(ClipboardService))]
namespace YouTubeDownloader.Droid.Services
{
    public class ClipboardService : IClipboardService
    {
        public string GetText()
        {
            ClipboardManager clipboard = (ClipboardManager)CrossCurrentActivity.Current.AppContext.GetSystemService(Context.ClipboardService);
            return clipboard.Text;
        }

        public void SaveText(string text)
        {
            ClipboardManager clipboard = (ClipboardManager)CrossCurrentActivity.Current.AppContext.GetSystemService(Context.ClipboardService);
            clipboard.Text = text;
        }
    }
}