using System;
using Counters;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TMP_Text textGameObject;
    public GameManager gameManager;
    private ICounter _counter;


    private void Start()
    {
        _counter = gameManager.Counters["score"];
        _counter.OnCounterChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score, int oldScore)
    {
        textGameObject.text = $"Score: {score}";
    }

    private void OnDestroy()
    {
        _counter.OnCounterChanged -= OnScoreChanged;
    }
}
