using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // Public UI elements to update score and win text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    // Game parameters
    public int totalOrbs;
    public GameObject orbPrefab;
    public Vector2 randomXRange;
    public Vector2 randomZRange;

    private int currentScore = 0;

    void Start()
    {
        SpawnOrbs();
    }

    // Spawns orbs randomly on the floor
    private void SpawnOrbs()
    {
        int spawnedOrbs = 0;

        while (spawnedOrbs < totalOrbs)
        {
            Vector3 randomPosition = GetRandomSpawnPosition();
            if (IsValidSpawnPosition(randomPosition, out Vector3 groundPosition))
            {
                Instantiate(orbPrefab, groundPosition, Quaternion.identity);
                spawnedOrbs++;
            }
        }
    }

    // Generates a random position within the specified range
    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(randomXRange.x, randomXRange.y);
        float randomZ = Random.Range(randomZRange.x, randomZRange.y);
        return new Vector3(randomX, 20, randomZ); // 20 is the height from which ray is cast
    }

    // Checks if the raycast hits the floor and returns a valid ground position
    private bool IsValidSpawnPosition(Vector3 startPosition, out Vector3 groundPosition)
    {
        Ray ray = new Ray(startPosition, Vector3.down); // Cast downwards
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
        {
            if (hitInfo.collider.gameObject.CompareTag("Floor"))
            {
                groundPosition = new Vector3(hitInfo.point.x, 1, hitInfo.point.z); // 1 is the y-offset for orbs
                return true;
            }
        }

        groundPosition = Vector3.zero;
        return false;
    }

    // Updates the score and checks for win condition
    public void IncreaseScore()
    {
        currentScore++;
        scoreText.text = $"Score: {currentScore}";

        if (currentScore >= totalOrbs)
        {
            winText.text = "You Win!";
        }
    }
}
