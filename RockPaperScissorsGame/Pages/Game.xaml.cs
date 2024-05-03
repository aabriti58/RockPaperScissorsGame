namespace RockPaperScissorsGame.Pages;

public partial class Game : ContentPage
{
    private Random random = new Random();
	public Game()
	{
		InitializeComponent();
	}

    
    private void result_display(object sender, EventArgs e)
    {
        //generate AI's choice randomly
        string[] choices = { "Rock", "Paper", "Scissors" };
        int aiChoiceIndex = random.Next(choices.Length);
        string aiChoice = choices[aiChoiceIndex];

        //user's choice
        Button button = (Button)sender;
        string userChoice = button.Text;

        

        //determine winner
        string result;
        if ((userChoice == "Rock" && aiChoice == "Scissors") ||
            (userChoice == "Paper" && aiChoice == "Rock") ||
            (userChoice == "Scissors" && aiChoice == "Paper"))
        {
            result = "You Win!";
        }
        else if ((userChoice == "Scissors" && aiChoice == "Rock") ||
                 (userChoice == "Rock" && aiChoice == "Paper") ||
                 (userChoice == "Paper" && aiChoice == "Scissors"))
        {
            result = "AI Wins!";
        }
        else
        {
            result = "It's a Draw!";
        }

        // Update statistics
        UpdateStatistics(userChoice, result);

        //display result
        ResultLabel.Text = $"Your choice: {userChoice} \nAI choice: {aiChoice}\nResult: {result}";
    }

    private void RockButton_Clicked(object sender, EventArgs e)
    {
        result_display(sender, e);
    }

    private void PaperButton_Clicked(object sender, EventArgs e)
    {
        result_display(sender, e);
    }

    private void ScissorsButton_Clicked(object sender, EventArgs e)
    {
        result_display(sender, e);
    }

    private void UpdateStatistics(string userChoice, string result)
    {
        // Increment total games played
        int totalGames = Preferences.Get("TotalGames", 0) + 1;
        Preferences.Set("TotalGames", totalGames);

        // Update player wins, AI wins, and other statistics based on result and user choice
        if (result == "You Win!")
        {
            int playerWins = Preferences.Get("PlayerWins", 0) + 1;
            Preferences.Set("PlayerWins", playerWins);
        }
        else if (result == "AI Wins!")
        {
            int aiWins = Preferences.Get("AIWins", 0) + 1;
            Preferences.Set("AIWins", aiWins);
        }

        // Update statistics based on user choice
        switch (userChoice)
        {
            case "Rock":
                int rockChosen = Preferences.Get("RockChosen", 0) + 1;
                Preferences.Set("RockChosen", rockChosen);
                break;
            case "Paper":
                int paperChosen = Preferences.Get("PaperChosen", 0) + 1;
                Preferences.Set("PaperChosen", paperChosen);
                break;
            case "Scissors":
                int scissorsChosen = Preferences.Get("ScissorsChosen", 0) + 1;
                Preferences.Set("ScissorsChosen", scissorsChosen);
                break;
            default:
                break;
        }
    }

    private void StatisticsButton_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Pages.Statistics();
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        App.Current.Quit();
    }
}