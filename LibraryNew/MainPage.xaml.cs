using System;
using System.Collections.ObjectModel;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LibraryNew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<MusicLib> MusicList = new ObservableCollection<MusicLib>();
        

        public MainPage()
        {
            this.InitializeComponent();
            mediaPlayer.TransportControls.IsFullWindowButtonVisible = false;

            mediaPlayer.TransportControls.IsZoomButtonVisible = false;

            mediaPlayer.TransportControls.IsStopButtonVisible = true;

            mediaPlayer.TransportControls.IsStopEnabled = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StorageFolder musicLib = KnownFolders.MusicLibrary;
            var files = await musicLib.GetFilesAsync();
            foreach (var file in files)
            {
                var musicProperties = await file.Properties.GetMusicPropertiesAsync();
                var artist = musicProperties.Artist;
                var album = musicProperties.Album;
                if (file.DisplayName == "1234 Get On The Dance Floor" || file.DisplayName == "Lungi Dance The Thalaiva")
                    album = "Chennai Express";
                if (file.DisplayName == "Dhivara" || file.DisplayName == "Mamathala thali" || file.DisplayName == "Manohari" || file.DisplayName == "Nippule Swasaga" || file.DisplayName == "Pacha Bottasi" || file.DisplayName == "Sivuni Aana")
                    album = "Bahubali";
                if (artist == "")
                    artist = "Artist";
                
                if (album == "")
                    album = "Unkown";
                MusicList.Add(new MusicLib { FileName = file.DisplayName, Artist = artist, Album = album, MusicFile = file });
            }

        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (MusicLib)e.ClickedItem;
            mediaPlayer.Source = MediaSource.CreateFromStorageFile(clickedItem.MusicFile);
            mediaPlayer.MediaPlayer.Play();
           // mediaPlayer.MediaPlayer.Pause();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StorageFolder musicLib = KnownFolders.MusicLibrary;
            var files = await musicLib.GetFilesAsync();
            foreach (var file in files)
            {
                var musicProperties = await file.Properties.GetMusicPropertiesAsync();
                var artist = musicProperties.Artist;
                if (artist == "")
                    artist = "Artist";
                var album = musicProperties.Album;
                if (album == "")
                    album = "Unkown";
                // MusicList.Add(new MusicLib { FileName = file.DisplayName, Artist = artist, Album = album, MusicFile = file });
                MusicList.Add(new MusicLib { FileName = file.DisplayName,Album = album, MusicFile = file });
            }
        }
        private void ExitApp_Click(object sender, RoutedEventArgs e)

        {

            Application.Current.Exit();

        }

        private async void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            StorageFolder musicLib = KnownFolders.MusicLibrary;
            var files = await musicLib.GetFilesAsync();
            foreach (var file in files)
            {
                var musicProperties = await file.Properties.GetMusicPropertiesAsync();
                var artist = musicProperties.Artist;
                var album = musicProperties.Album;
                if (file.DisplayName == "1234 Get On The Dance Floor" || file.DisplayName == "Lungi Dance The Thalaiva")
                    album = "Chennai Express";
                if (file.DisplayName == "Dhivara" || file.DisplayName == "Mamathala thali" || file.DisplayName == "Manohari" || file.DisplayName == "Nippule Swasaga" || file.DisplayName == "Pacha Bottasi" || file.DisplayName == "Sivuni Aana")
                    album = "Bahubali";
                if (artist == "")
                    artist = "Artist";

                if (album == "")
                    album = "Unkown";
                MusicList.Add(new MusicLib {Album = album, MusicFile = file });
            }

        }
    }
}



/*
 * <StackPanel Orientation="Horizontal">
                            <TextBlock Text="Artist: " />
                            <TextBlock Text="{Binding Artist}" />
                        </StackPanel>
                        
     
     <ComboBox Grid.Column="1" HorizontalAlignment="Left" Margin="573,659,0,0" VerticalAlignment="Top" Height="84" Width="291" SelectionChanged="ComboBox_SelectionChanged_1"/>
        <TextBlock  Margin="600,600,0,0" Text="Album" FontSize="30" TextWrapping="Wrap"/>
        
     <TextBox Text="TextBox"/>
     
     <AppBarButton Icon="Setting" Label="Settings" />*/


