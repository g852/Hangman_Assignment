using System;
using System.Collections.Generic;
using System.IO;

namespace Hangman_Assignment
{
    public class DatabaseManager
    {
        static string dbName = "HangmanDB.sqlite";
        string dbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, dbName);

        public DatabaseManager()
        {

        }
        public List<WordToDo> getWords()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "Select * from WordsTable";
                    var wordList = cmd.ExecuteQuery<WordToDo>();
                    return wordList;
                }

            }
            catch (Exception ex)
            {

                throw ex;


            }

        }

        public List<ScoreToDo> getScores()
        {
            try
            {

                using (var conn2 = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd2 = new SQLite.SQLiteCommand(conn2);
                    cmd2.CommandText = "Select * from ScoreTable order by Score desc limit 100";
                    var scoreList = cmd2.ExecuteQuery<ScoreToDo>();
                    return scoreList;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void writeScores(string playersName, int playersScore)
        {
            try
            {

                using (var conn2 = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd2 = new SQLite.SQLiteCommand(conn2);
                    cmd2.CommandText = "Insert into ScoreTable (UserName,Score) Values ('" + playersName + "', " + playersScore.ToString() + ")";
                    var executeCmd = cmd2.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
