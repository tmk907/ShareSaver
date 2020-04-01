using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ShareSaver
{
    class FileHelper
    {
        private readonly string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<string>> ReadAll()
        {
            await Permissions.RequestAsync<Permissions.StorageWrite>();
            return File.ReadAllLines(_filePath).ToList();
        }

        public async Task Clear()
        {
            await Permissions.RequestAsync<Permissions.StorageWrite>();
            File.Delete(_filePath);
        }

        public async Task Add(string text)
        {
            await Permissions.RequestAsync<Permissions.StorageWrite>();
            using (var streamWriter = File.AppendText(_filePath))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
