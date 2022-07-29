using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject playerGameObject;
    public ScoreText scoreText;
    public LivesText livesText;


    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;

    
    
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        if (asteroid.size <= 0.75f)
        {
            score += 50;
        }
        else if (asteroid.size <= 1.2f)
        {
            score += 25;
        }
        else
        {
            score += 10;
        }
        scoreText.DisplayScore(score);
    }
    
    public void PlayerDied()
    {
        lives--;

        if (lives != 0)
        {
            Invoke(nameof(Respawn), respawnTime);
        }
        livesText.DisplayLives(lives);
    }

    private void Respawn()
    {
        playerTransform.position = Vector3.zero;
        playerGameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        playerGameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        playerGameObject.layer = LayerMask.NameToLayer("Player");
    }
}
