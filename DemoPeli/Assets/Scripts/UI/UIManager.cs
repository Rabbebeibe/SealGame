using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] public GameObject youWinScreen;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        youWinScreen.SetActive(false);
    }

    public void YouWin()
    {
        youWinScreen.SetActive(true);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
