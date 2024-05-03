using RockPaperScissorsGame.Pages;

namespace RockPaperScissorsGame
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }


        private void NewGameButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Pages.Game();
        }
        private void StatisticsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statistics());
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Quit();
        }
    }

}
