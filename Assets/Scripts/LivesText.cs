using Counters;
using TMPro;
using UnityEngine;
public class LivesText : MonoBehaviour
{
    public TMP_Text textGameObject;
    public GameManager gameManager;
    private ICounter _counter;

    private void Start()
    {
        _counter = gameManager.Counters["lives"];
        _counter.OnCounterChanged += OnLivesChanged;
        textGameObject.text = $"Lives: {_counter.Amount}";
    }
    private void OnLivesChanged(int lives, int oldLives)
    {
        textGameObject.text = $"Lives: {lives}";
    }

    private void OnDestroy()
    {
        _counter.OnCounterChanged -= OnLivesChanged;
    }
}
