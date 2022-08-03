using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public float size = 1.0f;
    public float minsize = 0.5f;
    public float maxsize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;
    
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public GameManager gameManager;
    

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        transform.localScale = Vector3.one * size;
        rigidBody.mass = size;
    }
    public void SetTrajectory(Vector2 direction)
    {
        rigidBody.AddForce(direction * speed);
        Destroy(gameObject, maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (size * 0.5f >= minsize)
            {
                CreateSplit();
                CreateSplit(); // сделать цикл
            }
            gameManager.AsteroidDestroyed(this);
            Destroy(gameObject);
        }
    }

    private void CreateSplit()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position, transform.rotation);
        half.size = size * 0.5f;
        
        half.SetTrajectory(Random.insideUnitCircle.normalized * speed);
    }
}
