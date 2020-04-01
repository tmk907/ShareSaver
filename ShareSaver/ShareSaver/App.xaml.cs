using System;
using System.Linq;
using Xamarin.Forms;

namespace ShareSaver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static void DebugLog(string arg, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            var callerTypeName = filePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();
            callerTypeName = callerTypeName.Remove(callerTypeName.Length - 3);
            System.Diagnostics.Debug.WriteLine("{0} LOG: {1}.{2}() {3}", DateTime.Now.ToString("hh:mm:ss.fff"), callerTypeName, methodName, arg);
        }

        public static void SaveSharedData(string data)
        {
            LastSharedText = data;
            var fileService = DependencyService.Resolve<IFileService>();
            var fileHelper = new FileHelper(fileService.GetFilePath());
            fileHelper.Add(data).Wait();
        }

        public static string LastSharedText = "";
    }
}
