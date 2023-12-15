﻿using Fitschool.Forms;


namespace Fitschool.Classes
{
    //Class to handle starting, running and completing activities. Started from FormActiviteiten.cs
    public class Activity
    {
        private FormActiviteiten form;
        ActivityType chosenActivity;

        private User LoggedInUser;
        public User? SecondUser;
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
            FormTicTacToe formTicTacToe = new(this ,LoggedInUser, SecondUser ?? new(1));
            formTicTacToe.ShowDialog();
            //activity is ran from FormTicTacToe.cs, when the game is over, the winner is set and the form is closed. coming back here.
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
                    points = 3; // to be assigned
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

            if (winner == null) //if no winner, it's a draw.
            {
                MessageBox.Show("Gelijkspel!\nJullie kunnen de activiteit opnieuw starten, én hebben allebei 1💰 verdient!");
                int devidedPoints = (int)Math.Floor(points / 2.0); //deel de punten door 2, en rond af naar beneden.
                LoggedInUser.UpdatePoints(devidedPoints); //update points for both users, both get a point for the effort.
                SecondUser?.UpdatePoints(devidedPoints); //if second user is null, it will not update points, as there is no second user.
                return;
            }
            MessageBox.Show($"Gefeliciteerd {winner.Name}, Je hebt voor het doen van deze activiteit {points}💰 verdiend"); // 1 winner
            winner.UpdatePoints(points); //Update de punten in de applicatie.
        }
    }
}
