

namespace RockPaperScissorsGame.Pages
{
    public partial class Statistics : ContentPage
    {
        public Statistics()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            if (Preferences.ContainsKey("TotalGames"))
            {
                TotalGamesLabel.Text = $"Total Games Played: {Preferences.Get("TotalGames", 0)}";
                PlayerWinsLabel.Text = $"Player Wins: {Preferences.Get("PlayerWins", 0)}";
                AIWinsLabel.Text = $"AI Wins: {Preferences.Get("AIWins", 0)}";
                RockChosenLabel.Text = $"Rock Chosen: {Preferences.Get("RockChosen", 0)}";
                PaperChosenLabel.Text = $"Paper Chosen: {Preferences.Get("PaperChosen", 0)}";
                ScissorsChosenLabel.Text = $"Scissors Chosen: {Preferences.Get("ScissorsChosen", 0)}";
            }
            else
            {
                // Handle the case where the keys don't exist (e.g., first time app launch)
                TotalGamesLabel.Text = "Total Games Played: 0";
                PlayerWinsLabel.Text = "Player Wins: 0";
                AIWinsLabel.Text = "AI Wins: 0";
                RockChosenLabel.Text = "Rock Chosen: 0";
                PaperChosenLabel.Text = "Paper Chosen: 0";
                ScissorsChosenLabel.Text = "Scissors Chosen: 0";
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Pages.Game();
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Quit();
        }
    }
}
