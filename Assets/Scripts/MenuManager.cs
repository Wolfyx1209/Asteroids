using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject game;
    public GameObject mainMenu;
    public GameObject pauseMenu;

    private bool _inGame = false;
    private bool _isPaused = false;


    private void Update()
    {
        if (_inGame)
        {
            mainMenu.SetActive(false);
            game.SetActive(true);
        }
        else
        {
            _isPaused = false;
            mainMenu.SetActive(true);
            game.SetActive(false);

        }

        if (_isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pauseMenu.SetActive(_isPaused);
        
        if (_inGame && Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    public void Play()
    {
        _inGame = true;
    }
    
    public void Pause()
    {
        _isPaused = !_isPaused;
    }
    
    public void ToMenu()
    {
        _inGame = false;
    }
}
