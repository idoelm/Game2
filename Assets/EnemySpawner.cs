using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 20f;
    private int maxEnemies = 10; // Maximum number of enemies allowed
    private int enemyCount = 0; // Current number of enemies
    private float timer = 0f;

    private void Start()
    {

    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new enemy and the maximum count hasn't been reached
        if (timer >= spawnInterval && enemyCount < maxEnemies)
        {
            // Reset the timer
            timer = 0f;

            // Spawn a new enemy
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {

        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-5f, 5f);
        Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, 0f);

        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        enemyCount++;
        Debug.Log("Enemy Count: " + enemyCount);
    }

    public void DecreaseEnemy()
    {
        enemyCount--;
        Debug.Log("Enemy Count: " + enemyCount);
    }
}
