using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour
{
    static public Database current;

    private string path;
    private IDbConnection dbConnection;

    private void Awake()
    {
        if (current != null) Destroy(this.gameObject);
        current = this;

        path = $"URI=file:{Application.dataPath}/Ranking.s3db";
    }



    private void StablishConnection()
    {
        dbConnection = new SqliteConnection(path);
    }

    private void SetQueries(string query)
    {
        try
        {
            StablishConnection();
            dbConnection.Open();

            IDbCommand command = dbConnection.CreateCommand();
            command.CommandText = query;
            command.ExecuteReader();

            command.Dispose();
            command = null;
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
            throw;
        }
        finally
        {
            dbConnection.Close();
            dbConnection = null;
        }
    }

    public List<string> GetQueries(string query, int atributeCount)
    {
        var list = new List<string>();

        try
        {
            StablishConnection();
            dbConnection.Open();

            IDbCommand command = dbConnection.CreateCommand();
            command.CommandText = query;
            IDataReader result = command.ExecuteReader();

            while (result.Read())
            {
                string tupla = string.Empty;

                for (int i = 0; i < atributeCount; i++)
                {
                    tupla += result.GetValue(i).ToString() + '/';
                }
                list.Add(tupla);
            }

            command.Dispose();
            command = null;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
        finally
        {
            dbConnection.Close();
            dbConnection = null;
        }

        return list;
    }

    public void CreateTableRanking()
    {
        string query = "CREATE TABLE IF NOT EXISTS Ranking (" +
                        "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "Score INTEGER NOT NULL)";

        SetQueries(query);
    }
    public void DropTableRanking()
    {
        string query = "DROP TABLE IF EXISTS Ranking";
        SetQueries(query);
    }
    public void InsertPlayer(PlayerInfo player)
    {
        string query = $"INSERT INTO Ranking(Score) VALUES ('{player.Score});";
        SetQueries(query);
    }

    public List<PlayerInfo> SelectAllPlayers()
    {
        var query = "SELECT Score FROM Ranking";
        var list = GetQueries(query, 2);

        var players = new List<PlayerInfo>();

        foreach (var tupla in list)
        {
            var aux = tupla.Split('/');
            players.Add(new PlayerInfo()
            {
                Score = int.Parse(aux[0])
            });
        }

        return players;
    }

    public PlayerInfo SelectLastPlayer()
    {
        var query = "SELECT Score FROM Ranking ORDER BY ID DESC LIMIT 1";
        var list = GetQueries(query, 2);

        var aux = list[0].Split('/');

        var player = new PlayerInfo()
        {
            Score = int.Parse(aux[0])
        };

        return player;
    }
}