using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] private InputField UserNameField;
    [SerializeField] private Text ScoresDashboard;

    private void Start()
    {
        var scores = GameInfo.Current.BestScores;
        if (scores?.Count > 0)
        {
            ScoresDashboard.text = string.Join("\n",
                scores
                .Take(5)
                .OrderByDescending(score => score.UserScore)
                .Select((scoreInfo, index) => $"{++index}. {scoreInfo.UserScore} ({scoreInfo.UserName.ToUpper()})")
                .ToArray()
            );
        }
    }

    // Start is called before the first frame update
    public void OnStartGame()
    {
        GameInfo.Current.CurrentUserName = UserNameField.text;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void OnExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
