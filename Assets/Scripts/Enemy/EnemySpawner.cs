using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnerOn = true;
    public float spawnRadiusMin;
    public float spawnRadiusRange;

    [SerializeField] private GameObject enemy1;
    [SerializeField] private float spawnSpd1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnSpd1, enemy1));
    }

    private IEnumerator spawnEnemy(float spawnSpd, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnSpd);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(spawnRadiusRange * -1, spawnRadiusRange) + transform.position.x, Random.Range(spawnRadiusRange * -1, spawnRadiusRange) + transform.position.y, 0), Quaternion.identity);
        if(spawnerOn == true)
        {
            StartCoroutine(spawnEnemy(spawnSpd1, enemy1));
        }
    }
}
