using TMPro;
using UnityEngine;

public class LivesText : MonoBehaviour
{
    public TMP_Text textGameObject;

    public void DisplayLives(int lives)
    {
        textGameObject.text = $"Lives: {lives}";
    }
    
}
