using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;

    private void Start()
    {
        bestScore.text = $"Best score: {YandexGame.savesData.bestScore}";
        Debug.Log(YandexGame.savesData.bestScore);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
