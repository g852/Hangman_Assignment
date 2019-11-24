using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using System.IO;

namespace Hangman_Assignment
{
    [Activity(Label = "ScoreActivity", Theme = "@android:style/Theme.Holo.Light.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ScoreActivity : Activity
    {
        static string dbName = "HangmanDB.sqlite";
        string dbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, dbName);
        DatabaseManager myDatabase;
        List<ScoreToDo> myScoresList;

        ImageView playAgain;

        string playerName1;
        int playerScore1;

        string name;
        int score;

        TextView _1name;
        TextView _1score;
        TextView _2name;
        TextView _2score;
        TextView _3name;
        TextView _3score;
        TextView _4name;
        TextView _4score;
        TextView _5name;
        TextView _5score;

        TextView _6name;
        TextView _6score;
        TextView _7name;
        TextView _7score;
        TextView _8name;
        TextView _8score;
        TextView _9name;
        TextView _9score;
        TextView _10name;
        TextView _10score;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ScoreLayout);
            name = Intent.GetStringExtra("playerName");
            score = Intent.GetIntExtra("playerScores", 0);
            myDatabase = new DatabaseManager();
            myDatabase.writeScores(name, score);




            myDatabase = new DatabaseManager();
            myScoresList = myDatabase.getScores();


            playAgain = FindViewById<ImageView>(Resource.Id.buttonPlayAgain);
            _1name = FindViewById<TextView>(Resource.Id.textView_1Name);
            _1score = FindViewById<TextView>(Resource.Id.textView_1Score);
            _2name = FindViewById<TextView>(Resource.Id.textView_2Name);
            _2score = FindViewById<TextView>(Resource.Id.textView_2Score);
            _3name = FindViewById<TextView>(Resource.Id.textView_3Name);
            _3score = FindViewById<TextView>(Resource.Id.textView_3Score);
            _4name = FindViewById<TextView>(Resource.Id.textView_4Name);
            _4score = FindViewById<TextView>(Resource.Id.textView_4Score);
            _5name = FindViewById<TextView>(Resource.Id.textView_5Name);
            _5score = FindViewById<TextView>(Resource.Id.textView_5Score);

            _6name = FindViewById<TextView>(Resource.Id.textView_6Name);
            _6score = FindViewById<TextView>(Resource.Id.textView_6Score);
            _7name = FindViewById<TextView>(Resource.Id.textView_7Name);
            _7score = FindViewById<TextView>(Resource.Id.textView_7Score);
            _8name = FindViewById<TextView>(Resource.Id.textView_8Name);
            _8score = FindViewById<TextView>(Resource.Id.textView_8Score);
            _9name = FindViewById<TextView>(Resource.Id.textView_9Name);
            _9score = FindViewById<TextView>(Resource.Id.textView_9Score);
            _10name = FindViewById<TextView>(Resource.Id.textView_10Name);
            _10score = FindViewById<TextView>(Resource.Id.textView_10Score);





            playerScore1 = myScoresList[0].Score;
            playerName1 = myScoresList[0].UserName;
            _1name.Text = playerName1;
            _1score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[1].Score;
            playerName1 = myScoresList[1].UserName;
            _2name.Text = playerName1;
            _2score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[2].Score;
            playerName1 = myScoresList[2].UserName;
            _3name.Text = playerName1;
            _3score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[3].Score;
            playerName1 = myScoresList[3].UserName;
            _4name.Text = playerName1;
            _4score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[4].Score;
            playerName1 = myScoresList[4].UserName;
            _5name.Text = playerName1;
            _5score.Text = playerScore1.ToString();


            playerScore1 = myScoresList[5].Score;
            playerName1 = myScoresList[5].UserName;
            _6name.Text = playerName1;
            _6score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[6].Score;
            playerName1 = myScoresList[6].UserName;
            _7name.Text = playerName1;
            _7score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[7].Score;
            playerName1 = myScoresList[7].UserName;
            _8name.Text = playerName1;
            _8score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[8].Score;
            playerName1 = myScoresList[8].UserName;
            _9name.Text = playerName1;
            _9score.Text = playerScore1.ToString();

            playerScore1 = myScoresList[9].Score;
            playerName1 = myScoresList[9].UserName;
            _10name.Text = playerName1;
            _10score.Text = playerScore1.ToString();




            playAgain.Click += delegate
            {
                StartActivity(typeof(MainActivity));
                Finish();
            };
        }
    }
}
