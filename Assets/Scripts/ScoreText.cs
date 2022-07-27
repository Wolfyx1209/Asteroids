using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TMP_Text textGameObject;

    public void DisplayScore(int score)
    {
        textGameObject.text = $"Score: {score}";
    }
}
