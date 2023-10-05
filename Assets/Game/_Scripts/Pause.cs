using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused;
    public GameObject panel;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1.0f;
                panel.SetActive(false);
            }
            else
            {
                paused = true;
                Time.timeScale = 0.0f;
                panel.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
