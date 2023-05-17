using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    private IEnumerator Spawn(Vector2[] positions)
    {
        int waitSeconds = 2;
        var waitForSec = new WaitForSeconds(waitSeconds);

        foreach (Vector2 spawnerVector2 in positions)
        {
            Instantiate(_template, spawnerVector2, Quaternion.identity);

            yield return waitForSec;
        }
    }

    private void Start()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        Vector2[] spawnersPositions = new Vector2[enemySpawners.Length];

        for (int i = 0; i < enemySpawners.Length; i++)
        {
            spawnersPositions[i] = new Vector2(enemySpawners[i].transform.position.x, enemySpawners[i].transform.position.y);
        }

        StartCoroutine(Spawn(spawnersPositions));
    }
}
