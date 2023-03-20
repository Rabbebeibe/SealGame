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

    //Set win screen active
    public void YouWin()
    {
        youWinScreen.SetActive(true);
    }

    //Set game over screen active
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    //Load scene again
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Close game (works only in builded version)
    public void Quit()
    {
        Application.Quit();
    }
}
