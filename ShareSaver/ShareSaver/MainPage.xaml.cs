using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShareSaver
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly FileHelper _fileHelper;

        public MainPage()
        {
            InitializeComponent();
            var fileService = DependencyService.Resolve<IFileService>();
            _fileHelper = new FileHelper(fileService.GetFilePath());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            sharedText.Text = App.LastSharedText;
            await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.StorageWrite>();
        }

        private async void ClearSavedData(object sender, EventArgs e)
        {
            ShowActivityIndicator();
            await _fileHelper.Clear();
            HideActivityIndicator();
        }

        private void ShowClipboardClicked(object sender, EventArgs e)
        {
            copiedText.Text = GetClipboardText();
        }

        private async void SaveClipboardClicked(object sender, EventArgs e)
        {
            ShowActivityIndicator();
            var text = GetClipboardText();
            if (text != null)
            {
                await _fileHelper.Add(text);
            }
            ShowSavedClicked(null, null);
            HideActivityIndicator();
        }

        private async void ShowSavedClicked(object sender, EventArgs e)
        {
            ShowActivityIndicator();
            savedListView.ItemsSource = await _fileHelper.ReadAll();
            HideActivityIndicator();
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clipboardService = DependencyService.Resolve<IClipboardService>();
            clipboardService.SaveText(e.Item as string);
        }

        private string GetClipboardText()
        {
            var clipboardService = DependencyService.Resolve<IClipboardService>();
            return clipboardService.GetText();
        }
        
        private void ShowActivityIndicator()
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
        }

        private void HideActivityIndicator()
        {
            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
        }
    }
}
