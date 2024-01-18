using Fitschool.Forms;


namespace Fitschool.Classes.Activiteiten
{
    //Class to handle starting, running and completing activities. Started from FormActiviteiten.cs
    public class Activity
    {
        private readonly FormActiviteiten form;
        readonly ActivityType chosenActivity;

        private readonly User LoggedInUser;
        public User? SecondUser = null;
        public User? Winner { get; private set; }

        public Activity(ActivityType activity, FormActiviteiten form)
        {
            chosenActivity = activity;
            LoggedInUser = form.loggedInUser;
            this.form = form;
        }

        public void StartActivity()
        {
            switch (chosenActivity)
            {
                case ActivityType.PushUps:
                    PushUps();
                    break;
                case ActivityType.TicTacToe:
                    TicTacToe();
                    break;
                case ActivityType.Math:
                    ActivityMath();
                    break;
                case ActivityType.Language:
                    Language();
                    break;
            }
        }

        public void SetWinner(User winner)
        {
            Winner = winner;
        }

        private void PushUps()
        {
            PushUps pushUps = new();
            if (pushUps.Start())
            {
                ActivityComplete(LoggedInUser);
            }
        }

        private void TicTacToe()
        {
            Winner = null;
            SecondUser = form.secondUser;

            var formTicTacToe = SecondUser == null
                ? new FormTicTacToe(this, LoggedInUser)              //if there is no second user, start a single player game.
                : new FormTicTacToe(this, LoggedInUser, SecondUser); //if there is a second user, start a multiplayer game.

            formTicTacToe.ShowDialog();
            ActivityComplete(Winner); //Winner could be: null (draw), LoggedInUser (win), SecondUser (win), A user with the name "Computer" (Computer won, no points awarded)
        }

        private void ActivityMath()
        {
            FormMathGame formMathGame = new(LoggedInUser.Grade);

            formMathGame.ShowDialog();

            ActivityComplete(LoggedInUser, formMathGame.points);
            formMathGame.Dispose();
        }

        private void Language()
        {
            DDt();

            //Orgineel idee om meerdere games te maken, echter uiteindelijk niet genoeg tijd, dus deze op simpele manier gecombineerd.
            /*FormChooseLanguageGame chooseGame = new();
            chooseGame.ShowDialog();
            LanguageGames game = chooseGame.SelectedGame;
            chooseGame.Dispose();

            switch (game)
            {
                case LanguageGames.DDt:
                    DDt();
                    break;
            }*/
        }

        private void DDt()
        {
            FormDDT formDDT = new();
            formDDT.ShowDialog();
            int punten = formDDT.Punten;
            formDDT.Dispose();
            ActivityComplete(LoggedInUser, punten);
        }

        public void ActivityComplete(User? winner)
        {
            ActivityComplete(winner, null);
        }

        public void ActivityComplete(User? winner, int? amount)
        {
            int points;

            switch (chosenActivity)
            {
                case ActivityType.PushUps:
                    points = 10; // 1 point per pushup
                    break;
                case ActivityType.TicTacToe:
                    points = 3; // 3 for a win, 1 for a draw
                    break;
                case ActivityType.Math:
                    points = (int)Math.Floor((decimal)(amount ?? 0) / 2);
                    break;
                case ActivityType.Language:
                    points = (int)Math.Floor((decimal)(amount ?? 0) * 1.5m);
                    break;
                default:
                    points = 0;
                    break;
            }

            if (winner == null) //if no winner, it's a draw
            {
                HandleDraw(points);
                return;
            }
            else if (winner.Name == "Computer") //if the winner is the computer, no points are awarded.
            {
                new FormMessageBox("Helaas, je hebt verloren van de computer. Je hebt geen punten verdiend.");
                return;
            }
            else
            {
                new FormMessageBox($"Gefeliciteerd {winner.Name}, Je hebt voor het doen van deze activiteit {points}💰 verdiend", "Activiteit voltooid!"); // 1 winner
                winner.UpdatePoints(points); //Update points in database and in the user object

            }
        }

        public void HandleDraw(int points)
        {
            int devidedPoints = (int)Math.Floor(points / 2.0); //devide points by 2, and round down.
            LoggedInUser.UpdatePoints(devidedPoints);          //update points for both users, both get a point for the effort.
            SecondUser?.UpdatePoints(devidedPoints);           //if second user is null, it will not update points, as there is no second user.
            new FormMessageBox($"Gelijkspel!\nJullie kunnen de activiteit opnieuw starten, én hebben allebei {devidedPoints}💰 verdiend!", "Gelijkspel");
            return;
        }
    }
}