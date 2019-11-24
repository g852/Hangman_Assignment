using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hangman_Assignment
{
    [Activity(Label = "GamePageActivity", Theme = "@android:style/Theme.Holo.Light.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GamePageActivity : Activity
    {

        static string dbName = "HangmanDB.sqlite";
        string dbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, dbName);

        int healthLeft = 9;
        bool gameOver = false;
        Button replay;
        ImageView animation;
        bool won = false;
        int lettersFound = 0;
        int numberIncorrect = 0;
        string name;
        DatabaseManager myDatabase;
        List<WordToDo> myWordsList;

        TextView correctOrIncorrect;
        TextView lines;
        string word;
        string wordUpper;
        char guess;
        StringBuilder displayToPlayer;
        bool guessIsCorrect = false;
        int randomNumber;
        Random rnd;
        int playerScore = 0;
        TextView updateScore;


        #region imageViewSetup
        ImageView healthLeftImage;
        ImageView _A;
        ImageView _B;
        ImageView _C;
        ImageView _D;
        ImageView _E;
        ImageView _F;
        ImageView _G;
        ImageView _H;
        ImageView _I;
        ImageView _J;
        ImageView _K;
        ImageView _L;
        ImageView _M;
        ImageView _N;
        ImageView _O;
        ImageView _P;
        ImageView _Q;
        ImageView _R;
        ImageView _S;
        ImageView _T;
        ImageView _U;
        ImageView _V;
        ImageView _W;
        ImageView _X;
        ImageView _Yx;
        ImageView _Zx;


        #endregion


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.GameLayoutx);
            CopyDatabase();
            getWord();

            name = Intent.GetStringExtra("playerName");
            lines = FindViewById<TextView>(Resource.Id.textViewWordLines);


            displayToPlayer = new StringBuilder(word.Length);
            for (int i = 0; i < word.Length; i++)
                displayToPlayer.Append('_');

            lines.Text = displayToPlayer.ToString();

            #region findViews
            _A = FindViewById<ImageView>(Resource.Id.imageView_A);
            _B = FindViewById<ImageView>(Resource.Id.imageView_B);
            _C = FindViewById<ImageView>(Resource.Id.imageView_C);
            _D = FindViewById<ImageView>(Resource.Id.imageView_D);
            _E = FindViewById<ImageView>(Resource.Id.imageView_E);
            _F = FindViewById<ImageView>(Resource.Id.imageView_F);
            _G = FindViewById<ImageView>(Resource.Id.imageView_G);
            _H = FindViewById<ImageView>(Resource.Id.imageView_H);
            _I = FindViewById<ImageView>(Resource.Id.imageView_I);
            _J = FindViewById<ImageView>(Resource.Id.imageView_J);
            _K = FindViewById<ImageView>(Resource.Id.imageView_K);
            _L = FindViewById<ImageView>(Resource.Id.imageView_L);
            _M = FindViewById<ImageView>(Resource.Id.imageView_M);
            _N = FindViewById<ImageView>(Resource.Id.imageView_N);
            _O = FindViewById<ImageView>(Resource.Id.imageView_O);
            _P = FindViewById<ImageView>(Resource.Id.imageView_P);
            _Q = FindViewById<ImageView>(Resource.Id.imageView_Q);
            _R = FindViewById<ImageView>(Resource.Id.imageView_R);
            _S = FindViewById<ImageView>(Resource.Id.imageView_S);
            _T = FindViewById<ImageView>(Resource.Id.imageView_T);
            _U = FindViewById<ImageView>(Resource.Id.imageView_U);
            _V = FindViewById<ImageView>(Resource.Id.imageView_V);
            _W = FindViewById<ImageView>(Resource.Id.imageView_W);
            _X = FindViewById<ImageView>(Resource.Id.imageView_X);
            _Yx = FindViewById<ImageView>(Resource.Id.imageView_Yx);
            _Zx = FindViewById<ImageView>(Resource.Id.imageView_Zx);


            replay = FindViewById<Button>(Resource.Id.buttonReplay);
            healthLeftImage = FindViewById<ImageView>(Resource.Id.imageViewHealthLeft);
            correctOrIncorrect = FindViewById<TextView>(Resource.Id.textViewDisplayAnswer);
            animation = FindViewById<ImageView>(Resource.Id.imageViewAnimation);
            updateScore = FindViewById<TextView>(Resource.Id.textViewScore);
            #endregion





            #region clickSetup
            _A.Click += delegate
            {
                guess = 'A';
                _A.Alpha = 0.1f;
                _A.Enabled = false;
                checkForAnswer();
            };
            _B.Click += delegate
            {
                guess = 'B';
                _B.Alpha = 0.1f;
                _B.Enabled = false;
                checkForAnswer();
            };
            _C.Click += delegate
            {
                guess = 'C';
                _C.Alpha = 0.1f;
                _C.Enabled = false;
                checkForAnswer();
            };
            _D.Click += delegate
            {
                guess = 'D';
                _D.Alpha = 0.1f;
                _D.Enabled = false;
                checkForAnswer();
            };
            _E.Click += delegate
            {
                guess = 'E';
                _E.Alpha = 0.1f;
                _E.Enabled = false;
                checkForAnswer();
            };
            _F.Click += delegate
            {
                guess = 'F';
                _F.Alpha = 0.1f;
                _F.Enabled = false;
                checkForAnswer();
            };
            _G.Click += delegate
            {
                guess = 'G';
                _G.Alpha = 0.1f;
                _G.Enabled = false;
                checkForAnswer();
            };
            _H.Click += delegate
            {
                guess = 'H';
                _H.Alpha = 0.1f;
                _H.Enabled = false;
                checkForAnswer();
            };
            _I.Click += delegate
            {
                guess = 'I';
                _I.Alpha = 0.1f;
                _I.Enabled = false;
                checkForAnswer();
            };
            _J.Click += delegate
            {
                guess = 'J';
                _J.Alpha = 0.1f;
                _J.Enabled = false;
                checkForAnswer();
            };
            _K.Click += delegate
            {
                guess = 'K';
                _K.Alpha = 0.1f;
                _K.Enabled = false;
                checkForAnswer();
            };
            _L.Click += delegate
            {
                guess = 'L';
                _L.Alpha = 0.1f;
                _L.Enabled = false;
                checkForAnswer();
            };
            _M.Click += delegate
            {
                guess = 'M';
                _M.Alpha = 0.1f;
                _M.Enabled = false;
                checkForAnswer();
            };
            _N.Click += delegate
            {
                guess = 'N';
                _N.Alpha = 0.1f;
                _N.Enabled = false;
                checkForAnswer();
            };
            _O.Click += delegate
            {
                guess = 'O';
                _O.Alpha = 0.1f;
                _O.Enabled = false;
                checkForAnswer();
            };
            _P.Click += delegate
            {
                guess = 'P';
                _P.Alpha = 0.1f;
                _P.Enabled = false;
                checkForAnswer();
            }; _Q.Click += delegate
            {
                guess = 'Q';
                _Q.Alpha = 0.1f;
                _Q.Enabled = false;
                checkForAnswer();
            }; _R.Click += delegate
            {
                guess = 'R';
                _R.Alpha = 0.1f;
                _R.Enabled = false;
                checkForAnswer();
            }; _S.Click += delegate
            {
                guess = 'S';
                _S.Alpha = 0.1f;
                _S.Enabled = false;
                checkForAnswer();
            };
            _T.Click += delegate
            {
                guess = 'T';
                _T.Alpha = 0.1f;
                _T.Enabled = false;
                checkForAnswer();
            };
            _U.Click += delegate
            {
                guess = 'U';
                _U.Alpha = 0.1f;
                _U.Enabled = false;
                checkForAnswer();
            };
            _V.Click += delegate
            {
                guess = 'V';
                _V.Alpha = 0.1f;
                _V.Enabled = false;
                checkForAnswer();
            };
            _W.Click += delegate
            {
                guess = 'W';
                _W.Alpha = 0.1f;
                _W.Enabled = false;
                checkForAnswer();
            }; _X.Click += delegate
            {
                guess = 'X';
                _X.Alpha = 0.1f;
                _X.Enabled = false;
                checkForAnswer();
            };
            _Yx.Click += delegate
            {
                guess = 'Y';
                _Yx.Alpha = 0.1f;
                _Yx.Enabled = false;
                checkForAnswer();
            };
            _Zx.Click += delegate
            {
                guess = 'Z';
                _Zx.Alpha = 0.1f;
                _Zx.Enabled = false;
                checkForAnswer();
            };

            #endregion

        }
        public void CopyDatabase()
        {
            if (!File.Exists(dbPath))

            {
                using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))

                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))

                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)

                        {
                            bw.Write(buffer, 0, len);
                        }


                    }

                }

            }
        }
        public void setAnimations()
        {
            if (numberIncorrect == 1)
            {
                animation.Visibility = ViewStates.Visible;
                animation.SetImageResource(Resource.Drawable.Hangman_2x);

            }
            else if (numberIncorrect == 2)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_3x);

            }
            else if (numberIncorrect == 3)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_4x);

            }
            else if (numberIncorrect == 4)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_5x);

            }
            else if (numberIncorrect == 5)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_6x);

            }
            else if (numberIncorrect == 6)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_7x);

            }
            else if (numberIncorrect == 7)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_8x);

            }
            else if (numberIncorrect == 8)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_9x);

            }
            else if (numberIncorrect == 9)
            {
                animation.SetImageResource(Resource.Drawable.Hangman_10x);

            }

        }

        public void getWord()
        {
            try
            {
                myDatabase = new DatabaseManager();
                myWordsList = myDatabase.getWords();

                rnd = new Random(DateTime.Now.Millisecond);
                randomNumber = rnd.Next(0, myWordsList.Count);

                word = myWordsList[randomNumber].WordBank;

                wordUpper = word.ToUpper();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void checkHealthLeft()
        {
            if (healthLeft == 9)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_9);
            }
            else if (healthLeft == 8)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_8);
            }
            else if (healthLeft == 7)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_7);
            }
            else if (healthLeft == 6)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_6);
            }
            else if (healthLeft == 5)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_5);
            }
            else if (healthLeft == 4)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_4);
            }
            else if (healthLeft == 3)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_3);
            }
            else if (healthLeft == 2)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_2);
            }
            else if (healthLeft == 1)
            {
                healthLeftImage.SetImageResource(Resource.Drawable.Heart_1);
            }
            else if (healthLeft == 0)
            {
                healthLeftImage.SetImageBitmap(null);
                gameOver = true;
                GameOver();
            }

        }

        public void GameOver()
        {

            if (gameOver == true && healthLeft == 0)
            {
                disableButtons();
                correctOrIncorrect.Text = "YOU LOSE";
                correctOrIncorrect.Text = "Answer was : " + wordUpper;
                replay.Visibility = ViewStates.Visible;
                updateScore.Visibility = ViewStates.Invisible;
                replay.Text = "GAMEOVER";
                replay.Click += delegate
                {
                    Intent i = new Intent(this, typeof(ScoreActivity));

                    i.PutExtra("playerName", name);
                    i.PutExtra("playerScores", playerScore);
                    StartActivity(i);
                    Finish();
                };

            };



        }

        public void restartGame()
        {

            replay.Visibility = ViewStates.Visible;
            replay.Click += delegate
            {
                replay.Text = "Restart";
                if (replay.Text == "Restart")
                {
                    numberIncorrect = 0;
                    updateScore.Text = "0";
                    animation.Visibility = ViewStates.Invisible;
                    replay.Visibility = ViewStates.Invisible;
                    enableButtons();
                    correctOrIncorrect.Text = "";
                    healthLeft = 9;
                    checkHealthLeft();
                    lines.Text = "";
                    lettersFound = 0;
                    getWord();
                    updateScore.Visibility = ViewStates.Visible;
                    displayToPlayer = new StringBuilder(word.Length);
                    for (int i = 0; i < word.Length; i++)
                        displayToPlayer.Append('_');
                    lines.Text = displayToPlayer.ToString();
                }

            };
        }
        public void checkWin()
        {
            if (won == true)
            {
                disableButtons();
                updateScore.Visibility = ViewStates.Invisible;
                correctOrIncorrect.Text = "YOU WON";
                nextLevel();
            }
        }

        public void nextLevel()
        {
            healthLeftImage.SetImageBitmap(null);
            replay.Visibility = ViewStates.Visible;
            replay.Text = "Continue";
            replay.Click += delegate
            {
                numberIncorrect = 0;
                updateScore.Text = playerScore.ToString();
                animation.Visibility = ViewStates.Invisible;
                replay.Visibility = ViewStates.Invisible;
                enableButtons();
                correctOrIncorrect.Text = "";
                healthLeft = 9;
                updateScore.Visibility = ViewStates.Visible;
                checkHealthLeft();
                lines.Text = "";
                lettersFound = 0;
                getWord();
                displayToPlayer = new StringBuilder(word.Length);
                for (int i = 0; i < word.Length; i++)
                    displayToPlayer.Append('_');
                lines.Text = displayToPlayer.ToString();
            };

        }

        public void checkForAnswer()
        {
            if (wordUpper.Contains(guess.ToString()))
            {
                guessIsCorrect = true;

                guessCorrect();
                for (int i = 0; i < wordUpper.Length; i++)
                {
                    if (wordUpper[i] == guess)
                    {
                        displayToPlayer[i] = wordUpper[i];
                        lettersFound++;
                    }

                }
                if (lettersFound == wordUpper.Length)
                {
                    won = true;
                    checkWin();
                }

            }
            else if (!wordUpper.Contains(guess.ToString()))
            {
                guessIsCorrect = false;
                guessIncorrect();
            }

            lines.Text = displayToPlayer.ToString();


        }

        public void guessCorrect()
        {
            if (guessIsCorrect == true)
            {
                correctOrIncorrect.Text = "Correct";
                playerScore += 100;
                updateScore.Text = playerScore.ToString();
            }


        }

        public void guessIncorrect()
        {

            if (guessIsCorrect == false)
            {
                healthLeft--;
                numberIncorrect++;
                setAnimations();
                correctOrIncorrect.Text = "Incorrect";
            }
            checkHealthLeft();

        }


        public void disableButtons()
        {
            _A.Enabled = false;
            _B.Enabled = false;
            _C.Enabled = false;
            _D.Enabled = false;
            _E.Enabled = false;
            _F.Enabled = false;
            _G.Enabled = false;
            _H.Enabled = false;
            _I.Enabled = false;
            _J.Enabled = false;
            _K.Enabled = false;
            _L.Enabled = false;
            _M.Enabled = false;
            _N.Enabled = false;
            _O.Enabled = false;
            _P.Enabled = false;
            _Q.Enabled = false;
            _R.Enabled = false;
            _S.Enabled = false;
            _T.Enabled = false;
            _U.Enabled = false;
            _V.Enabled = false;
            _W.Enabled = false;
            _X.Enabled = false;
            _Yx.Enabled = false;
            _Zx.Enabled = false;
            _A.Alpha = 0.1f;
            _B.Alpha = 0.1f;
            _C.Alpha = 0.1f;
            _D.Alpha = 0.1f;
            _E.Alpha = 0.1f;
            _F.Alpha = 0.1f;
            _G.Alpha = 0.1f;
            _H.Alpha = 0.1f;
            _I.Alpha = 0.1f;
            _J.Alpha = 0.1f;
            _K.Alpha = 0.1f;
            _L.Alpha = 0.1f;
            _M.Alpha = 0.1f;
            _N.Alpha = 0.1f;
            _O.Alpha = 0.1f;
            _P.Alpha = 0.1f;
            _Q.Alpha = 0.1f;
            _R.Alpha = 0.1f;
            _S.Alpha = 0.1f;
            _T.Alpha = 0.1f;
            _U.Alpha = 0.1f;
            _V.Alpha = 0.1f;
            _W.Alpha = 0.1f;
            _X.Alpha = 0.1f;
            _Yx.Alpha = 0.1f;
            _Zx.Alpha = 0.1f;

        }
        public void enableButtons()
        {
            _A.Enabled = true;
            _B.Enabled = true;
            _C.Enabled = true;
            _D.Enabled = true;
            _E.Enabled = true;
            _F.Enabled = true;
            _G.Enabled = true;
            _H.Enabled = true;
            _I.Enabled = true;
            _J.Enabled = true;
            _K.Enabled = true;
            _L.Enabled = true;
            _M.Enabled = true;
            _N.Enabled = true;
            _O.Enabled = true;
            _P.Enabled = true;
            _Q.Enabled = true;
            _R.Enabled = true;
            _S.Enabled = true;
            _T.Enabled = true;
            _U.Enabled = true;
            _V.Enabled = true;
            _W.Enabled = true;
            _X.Enabled = true; ;
            _Yx.Enabled = true;
            _Zx.Enabled = true;
            _A.Alpha = 1;
            _B.Alpha = 1;
            _C.Alpha = 1;
            _D.Alpha = 1; ;
            _E.Alpha = 1;
            _F.Alpha = 1;
            _G.Alpha = 1;
            _H.Alpha = 1;
            _I.Alpha = 1;
            _J.Alpha = 1;
            _K.Alpha = 1;
            _L.Alpha = 1;
            _M.Alpha = 1;
            _N.Alpha = 1;
            _O.Alpha = 1;
            _P.Alpha = 1;
            _Q.Alpha = 1;
            _R.Alpha = 1;
            _S.Alpha = 1;
            _T.Alpha = 1;
            _U.Alpha = 1; ;
            _V.Alpha = 1;
            _W.Alpha = 1;
            _X.Alpha = 1;
            _Yx.Alpha = 1;
            _Zx.Alpha = 1;

        }
    }
}
