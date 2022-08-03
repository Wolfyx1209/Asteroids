using System;
using Counters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject game;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameManager gameManager;
    public GameObject gameOverPanel;
    private SceneManager _sceneManager;

    private ICounter _lives;
    private bool _inGame;
    private bool _isPaused;

    public delegate void PauseChangedHandler();
    public event PauseChangedHandler OnPauseChanged;

    public delegate void PlayGameHandler();
    public event PlayGameHandler OnPlaying;
    
    public void Init()
    {
        _lives = gameManager.Counters["lives"];
        _lives.OnCounterChanged += OnLivesChanged;
        OnPauseChanged += PauseChanged;
        OnPlaying += Playing;
    }

    private void Playing()
    {
        mainMenu.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1;
    }

    private void PauseChanged()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pauseMenu.SetActive(_isPaused);
    }

    private void OnLivesChanged(int amount, int oldAmount)
    {
        if (amount == 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (_inGame && Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    public void Play()
    {
        _inGame = true;
        OnPlaying?.Invoke();
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Pause()
    {
        OnPauseChanged?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        _lives.OnCounterChanged -= OnLivesChanged;
        OnPauseChanged -= PauseChanged;
        OnPlaying -= Playing;
    }
}
