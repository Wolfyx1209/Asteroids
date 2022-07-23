using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TMP_Text _textGameObject;
    private void Awake()
    {
        _textGameObject = gameObject.GetComponent<TMP_Text>();
    }

    public void DisplayScore(int score)
    {
        _textGameObject.text = $"Score: {score}";
    }
}
