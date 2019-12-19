using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int xPos;
    private int yPos;
    private int enemyCount;
    void Start()
    {
        StartCoroutine(enemyDrop());
    }

    IEnumerator enemyDrop()
    {
        while ( enemyCount < 10 ) {
            xPos = Random.Range(-13, 18);
            yPos = Random.Range(-13, 5);

            Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(.5f);
            enemyCount++;
        }

        yield return new WaitForSeconds(8f);
        enemyCount = 0;
        StartCoroutine(enemyDrop());
    }
}
