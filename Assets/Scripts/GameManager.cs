using Counters;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject playerGameObject;
    public MenuManager menuManager;
    
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;

    // public delegate void LivesChangedHandler(int lives, int oldLives);
    // public event LivesChangedHandler OnLivesChanged;

    public CounterCollection Counters { get; private set; }// не могу из вне поменять 

    void Start()
    {
        Counters = new CounterCollection
        {
            { "lives", new Counter(3) },
            { "score", new Counter() }
        };
        menuManager.Init();
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        var score = Counters["score"];
        
        if (asteroid.size <= 0.75f)
        {
            score.Add(50);
        }
        else if (asteroid.size <= 1.2f)
        {
            score.Add(25);
        }
        else
        {
            score.Add(10);
        }
        
    }
    
    public void PlayerDied()
    {
        var lives = Counters["lives"];
        
        lives.Add(-1);

        if (lives.Amount != 0)
        {
            Invoke(nameof(Respawn), respawnTime);
        }
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
