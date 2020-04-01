namespace ShareSaver
{
    public interface IClipboardService
    {
        string GetText();
        void SaveText(string text);
    }
}
