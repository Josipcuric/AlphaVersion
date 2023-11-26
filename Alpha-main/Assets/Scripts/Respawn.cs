using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Array of monster prefabs

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 40;

    private float pushBackDistance = 1.0f; // Distance to push the respawned monster back

    private float startDelay = 1.0f;
    private float spawnInterval = -14.0f;
    private int currentWave = 1; // Current wave count

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsterWave());
    }

    IEnumerator SpawnMonsterWave()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            int numberOfMonsters = currentWave;

            for (int i = 0; i < numberOfMonsters; i++)
            {
                SpawnRandomMonster();
                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitForSeconds(spawnInterval * 2); // Wait between waves

            currentWave++;
        }
    }

    void SpawnRandomMonster()
    {
        if (monsterPrefabs.Length == 0)
        {
            Debug.LogError("No monster prefabs assigned.");
            return;
        }

        int monsterIndex = Random.Range(0, monsterPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        if (IsPositionValid(spawnPos))
        {
            Instantiate(monsterPrefabs[monsterIndex], spawnPos, Quaternion.identity);
        }
        else
        {
            // Retry spawning if the position is invalid
            Invoke("SpawnRandomMonster", 0.1f); // Try again after a short delay
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        return position.x >= spawnLimitXLeft && position.x <= spawnLimitXRight;
    }
}
