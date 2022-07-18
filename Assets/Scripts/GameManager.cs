using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
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
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    

    private void GameOver()
    {
        lives = 3;
        score = 0;
        Invoke(nameof(Respawn), respawnTime);
    }
}
