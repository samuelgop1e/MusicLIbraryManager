﻿namespace MusicLibraryManager
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
