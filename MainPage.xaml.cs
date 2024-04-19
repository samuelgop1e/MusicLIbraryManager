namespace MusicLibraryManager
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editMusicId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetSongs());
        }


        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (_editMusicId == 0)
            {
                await _dbService.Create(new Music
                {
                    Name = nameEntryField.Text,
                    Artist = artistEntryField.Text,
                    Album = albumEntryField.Text,
                    Time = Convert.ToInt32(durationEntryField.Text)
                });
            }
            else
            {
                await _dbService.Update(new Music
                {
                    ID = _editMusicId,
                    Name = nameEntryField.Text,
                    Artist = artistEntryField.Text,
                    Album = albumEntryField.Text,
                    Time = Convert.ToInt32(durationEntryField.Text)
                });
                _editMusicId = 0;
            }
            nameEntryField.Text = string.Empty;
            artistEntryField.Text = string.Empty;
            albumEntryField.Text = string.Empty;
            durationEntryField.Text = string.Empty;
            listView.ItemsSource = await _dbService.GetSongs();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var music = (Music)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");
            switch (action)
            {
                case "Edit":
                    _editMusicId = music.ID;
                    nameEntryField.Text = music.Name;
                    artistEntryField.Text = music.Artist;
                    albumEntryField.Text = music.Album;
                    durationEntryField.Text = Convert.ToString(music.Time);
                    break;
                case "Delete":
                    await _dbService.Delete(music);
                    listView.ItemsSource = await _dbService.GetSongs();
                    break;
            }
        }

    }
}


