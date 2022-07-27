using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenuPanel;
    public GameObject game;

    private bool _isPaused = false;
    private bool _toMenu = false;
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
        if (_isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pauseMenu.SetActive(_isPaused);

        if (_toMenu)
        {
            game.SetActive(false);
            mainMenuPanel.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }

    public void Pause()
    {
        _isPaused = !_isPaused;
    }

    public void ToMenu()
    {
        _toMenu = true;
    }
}
