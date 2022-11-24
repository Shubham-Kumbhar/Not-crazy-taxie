using UnityEngine.SceneManagement;
using UnityEngine;

public class scenemanagers : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(4);
    }
    public void mainGame()
    {
        SceneManager.LoadScene(1);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void restart_menu()
    {
        SceneManager.LoadScene(3);
    }
    public void credits()
    {
        SceneManager.LoadScene(5);
    }

    public void ads()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    public GameObject pausemenus;
    public GameObject canvas1;
    public void pause()
    {
        pausemenus.SetActive(true);
        canvas1.SetActive(false);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pausemenus.SetActive(false);
        canvas1.SetActive(true);
        Time.timeScale = 1f;
    }
    
}
