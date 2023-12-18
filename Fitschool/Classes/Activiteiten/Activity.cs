using Fitschool.Forms;


namespace Fitschool.Classes.Activiteiten
{
    //Class to handle starting, running and completing activities. Started from FormActiviteiten.cs
    public class Activity
    {
        private FormActiviteiten form;
        ActivityType chosenActivity;

        private User LoggedInUser;
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
                    //Math();
                    break;
                case ActivityType.Language:
                    //Language();
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
            pushUps.Start();
            ActivityComplete(LoggedInUser);
        }

        private void TicTacToe()
        {
            Winner = null;
            SecondUser = form.secondUser;

            var formTicTacToe = SecondUser == null
                ? new FormTicTacToe(this, LoggedInUser)              //if there is no second user, start a single player game.
                : new FormTicTacToe(this, LoggedInUser, SecondUser); //if there is a second user, start a multiplayer game.

            formTicTacToe.ShowDialog();
            ActivityComplete(Winner);
        }


        public void ActivityComplete(User? winner)
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
                    points = 5; // to be assigned
                    break;
                case ActivityType.Language:
                    points = 5; // to be assigned
                    break;
                default:
                    points = 0;
                    break;
            }

            if (winner == null) //if no winner, it's a draw, or a single player game where the user lost.
            {
                if (SecondUser != null) //if there is a second user, it's a draw
                {
                    HandleDraw(points);
                    return;
                }
                else //if there is no second user, the user lost.
                {
                    MessageBox.Show($"Helaas {LoggedInUser.Name}, Je hebt geen punten verdiend");
                    return;
                }
            }
            MessageBox.Show($"Gefeliciteerd {winner.Name}, Je hebt voor het doen van deze activiteit {points}💰 verdiend"); // 1 winner
            winner.UpdatePoints(points); //Update points in database and in the user object
        }

        public void HandleDraw(int points)
        {
            MessageBox.Show("Gelijkspel!\nJullie kunnen de activiteit opnieuw starten, én hebben allebei 1💰 verdiend!");
            int devidedPoints = (int)Math.Floor(points / 2.0); //devide points by 2, and round down.
            LoggedInUser.UpdatePoints(devidedPoints);          //update points for both users, both get a point for the effort.
            SecondUser?.UpdatePoints(devidedPoints);           //if second user is null, it will not update points, as there is no second user.
            return;
        }
    }
}