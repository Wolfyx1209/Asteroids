using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject game;
    public GameObject pauseMenuPanel;
    public GameObject mainMenuPanel;

    private bool _play = false;
    
    private void Update()
    {
        if (_play)
        {
            game.SetActive(true);
            pauseMenuPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
    }

    public void Play()
    {
        _play = true;
    }
}
