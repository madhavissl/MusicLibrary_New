using Windows.Storage;

namespace LibraryNew
{
    public class MusicLib
    {
        public string FileName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public StorageFile MusicFile { get; set; }
       

    }
}