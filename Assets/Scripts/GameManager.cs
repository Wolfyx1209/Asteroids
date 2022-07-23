using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    private Transform _playerTransform;
    private GameObject _playerGameObject;
    public ScoreText scoreText;

    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;

    private void Awake()
    {
        _playerTransform = player.transform;
        _playerGameObject = player.gameObject;
    }
    

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

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
        
    }

    private void Respawn()
    {
        _playerTransform.position = Vector3.zero;
        _playerGameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        _playerGameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        _playerGameObject.layer = LayerMask.NameToLayer("Player");
    }
    

    private void GameOver()
    {
        lives = 3;
        score = 0;
        Invoke(nameof(Respawn), respawnTime);
    }
}
