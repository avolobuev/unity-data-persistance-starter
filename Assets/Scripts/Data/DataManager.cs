using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class DataManager
{
    private static string SettingsFileName => "savefile.sq";
    private static string SettingsFilePath => $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}{SettingsFileName}";

    public static GameInfo LoadGameInfo()
    {
        if (File.Exists(SettingsFilePath))
        {
            var bf = new BinaryFormatter();
            using var file = File.Open(SettingsFilePath, FileMode.Open);

            return (GameInfo)bf.Deserialize(file);
        }

        return null;
    }

    public static void SaveGameInfo(int newScore)
    {
        GameInfo.Current.BestScores.Add(new ScoreInfo
        {
            UserName = GameInfo.Current.CurrentUserName,
            UserScore = newScore
        });

        var bf = new BinaryFormatter();
        using var file = File.Create(SettingsFilePath);
        bf.Serialize(file, GameInfo.Current);
    }
}

