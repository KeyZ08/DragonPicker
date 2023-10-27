using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TextMeshProUGUI achivments;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Initialize()
    {
        bestScore.text = $"Best score: {YandexGame.savesData.bestScore}";
        achivments.text = string.Join(",\n", YandexGame.savesData.achievments ?? new string[0]);
    }
}
