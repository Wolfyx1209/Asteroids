using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    
    

    public void Project(Vector2 direction)
    {
        rigidBody.AddForce(direction * speed);
        Destroy(gameObject, maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
