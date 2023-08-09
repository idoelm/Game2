using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform tr;
    public int speed = 7;
    private bool right = true;
    private EnemySpawner spawner;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        rb.velocity = transform.right * speed;
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            spawner.DecreaseEnemy();
            Debug.Log("bullet");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawner.DecreaseEnemy();
        }
        if (collision.gameObject.tag.Equals("RightWall"))
        {
            // Debug.Log("RightWall");
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            tr.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (collision.gameObject.tag.Equals("leftWall"))
        {
            // Debug.Log("LeftWall")
            rb.velocity = new Vector2(speed, rb.velocity.y);
            tr.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (collision.gameObject.tag.Equals("ceiling") || collision.gameObject.tag.Equals("floor"))
        {
            //  Debug.Log("floor/ceiling");
            Destroy(gameObject);
        }
    }
}
