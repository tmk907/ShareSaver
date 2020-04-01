using System.IO;
using ShareSaver;
using Xamarin.Forms;
using YouTubeDownloader.Droid.Services;

[assembly: Dependency(typeof(FileService))]
namespace YouTubeDownloader.Droid.Services
{
    public class FileService : IFileService
    {
        public string GetFilePath()
        {
            return Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "SavedSharedData.txt");
        }
    }
}
