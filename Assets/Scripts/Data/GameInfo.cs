using System;
using System.Collections.Generic;

[Serializable]
public class GameInfo
{
    [NonSerialized] public string CurrentUserName;

    public List<ScoreInfo> BestScores { get; set; }

    public static GameInfo Current
    {
        get
        {
            if (_gameInfo == null)
            {
                _gameInfo = DataManager.LoadGameInfo() ?? Default;
            }

            return _gameInfo;
        }
    }

    private static GameInfo _gameInfo = null;
    private static GameInfo Default => new GameInfo
    {
        CurrentUserName = "Default",
        BestScores = new List<ScoreInfo>()
    };
}
